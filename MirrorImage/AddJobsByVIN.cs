using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MirrorImage
{
    public partial class AddJobsByVIN : Form

    {
        DataTable JobsByCompanyDt;
        DataTable selectedTable;
        private string conStr = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        SqlTransaction trn;
        public AddJobsByVIN()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string VIN = txtVIN.Text; //"1C4RJEBG6LC118522"; //3C4NJDAB8MT566152
            
            string url = "https://vpic.nhtsa.dot.gov/api/vehicles/DecodeVin/"+ VIN + "?format=JSON";

            try
            {
               var api = new APIAccess();
               var obj = api.GenericGet(url);
               if( obj.Result.IsSucess)
                {
                    var Make = obj.Result.Results.FirstOrDefault(s => s.Variable == "Make").Value.ToString();
                    var Model = obj.Result.Results.FirstOrDefault(s => s.Variable == "Model").Value.ToString();
                    var Year = obj.Result.Results.FirstOrDefault(s => s.Variable == "Model Year").Value.ToString();

                    txtMake.Text = Make;
                    txtModel.Text = Model;
                    txtYear.Text = Year;
                }
               else
                {
                    MessageBox.Show("Error Occured While Retrieving Vehicle Information");
                }
               

            }
            catch (Exception)
            {

                MessageBox.Show("Error Occured While Retrieving Vehicle Information");
            }
           

        }

        private void AddJobsByVIN_Load(object sender, EventArgs e)
        {
            txtMake.ReadOnly = true;
            txtModel.ReadOnly = true;
            txtYear.ReadOnly = true;

            var cmp = new Company();
            var job = new Job();

            cmbCompany.DataSource = cmp.LoadCompany();
            cmbCompany.DisplayMember = "CompanyName";
            cmbCompany.ValueMember = "CompanyId";

            this.cmbCompany.DropDownStyle = ComboBoxStyle.DropDownList;
            cmp.CompanyId = int.Parse(cmbCompany.SelectedValue.ToString());

           // this.selectedJobs = new List<SelectedJobs>();
             selectedTable = new DataTable();
            selectedTable.Columns.Add("JobId", typeof(int));
            selectedTable.Columns.Add("Name", typeof(string));


            grdUserJobs.DataSource = job.LoadUserJobs();
           // grdUserJobs.Columns[0].Visible = false;
            grdUserJobs.Columns[1].Visible = false;
            //grdUserJobs.Columns[0].HeaderCell

            JobsByCompanyDt = cmp.LoadJobsByCompany();

        }

      

        private void cmbCompany_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var cmp = new Company();
            cmp.CompanyId = int.Parse(cmbCompany.SelectedValue.ToString());
            

            listJobs.DataSource= cmp.LoadJobsByCompany();
            JobsByCompanyDt = cmp.LoadJobsByCompany();
            listJobs.DisplayMember = "JobName";
            listJobs.ValueMember = "JobId";

        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var com = new Company();
            var s= (((DataRowView)listJobs.SelectedItem).Row[1]).ToString();

            
            selectedTable.Rows.Add(int.Parse(listJobs.SelectedValue.ToString()), s);

           

            listSelectedJobs.DataSource = selectedTable;
            listSelectedJobs.DisplayMember = "Name";
            listSelectedJobs.ValueMember = "JobId";


            com.CompanyId = int.Parse(cmbCompany.SelectedValue.ToString());
           
            var rw= JobsByCompanyDt.Select("JobId=" +listJobs.SelectedValue.ToString());

            foreach (var item in rw)
            {
                JobsByCompanyDt.Rows.Remove(item);
            }
            
           
            listJobs.DataSource = JobsByCompanyDt;
            listJobs.DisplayMember = "JobName";
            listJobs.ValueMember = "JobId";
        }

        

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var rw = selectedTable.Select("JobId=" + listSelectedJobs.SelectedValue.ToString());
            var jobName = (((DataRowView)listSelectedJobs.SelectedItem).Row[1]).ToString();
            var jobId = int.Parse(listSelectedJobs.SelectedValue.ToString());

            foreach (var item in rw)
            {
                selectedTable.Rows.Remove(item);
                

            }

            JobsByCompanyDt.Rows.Add(jobId,jobName);

            listSelectedJobs.DataSource = selectedTable;
            listSelectedJobs.DisplayMember = "Name";
            listSelectedJobs.ValueMember = "JobId";

            listJobs.DataSource = JobsByCompanyDt;
            listJobs.DisplayMember = "JobName";
            listJobs.ValueMember = "JobId";

        }

        private void btnAddJobs_Click(object sender, EventArgs e)
        {
            try
            {
                var job = new Job(new Company(), new User());
                job.usr.VIN = txtVIN.Text;
                job.year = txtYear.Text;
                job.Make = txtMake.Text;
                job.Model = txtModel.Text;
                job.stockNo = txtStockNumber.Text;
                job.Color = txtColor.Text;
                job.com.CompanyId = int.Parse(cmbCompany.SelectedValue.ToString());
                job.usr.Id = 1;
                
                var con = new SqlConnection(conStr);
                con.Open();
                trn = con.BeginTransaction();
                for (int i = 0; i < selectedTable.Rows.Count; i++)
                {
                   job.JobId= int.Parse( selectedTable.Rows[i]["JobId"].ToString());
                   job.InsertUserJobs(trn,con);


                }
                trn.Commit();
                con.Close();
                grdUserJobs.DataSource = job.LoadUserJobs();
                MessageBox.Show("Jobs Information Successfully Saved");

            }
            catch (Exception)
            {
                trn.Rollback();
                MessageBox.Show("Error !");
            }
           
            
        }

        

        private void grdUserJobs_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtVIN.Text = grdUserJobs.Rows[e.RowIndex].Cells["VIN"].Value.ToString();
            txtYear.Text = grdUserJobs.Rows[e.RowIndex].Cells["Model Year"].Value.ToString();
            txtModel.Text = grdUserJobs.Rows[e.RowIndex].Cells["model"].Value.ToString();
            txtMake.Text = grdUserJobs.Rows[e.RowIndex].Cells["make"].Value.ToString();
            txtStockNumber.Text = grdUserJobs.Rows[e.RowIndex].Cells["stockNo"].Value.ToString();
            txtColor.Text = grdUserJobs.Rows[e.RowIndex].Cells["color"].Value.ToString();
            cmbCompany.SelectedValue= grdUserJobs.Rows[e.RowIndex].Cells["companyId"].Value.ToString();

            var job = new Job(new Company(), new User());
            job.com.CompanyId = int.Parse( cmbCompany.SelectedValue.ToString());
            job.Date= grdUserJobs.Rows[e.RowIndex].Cells["Date"].Value.ToString();
            job.usr.VIN = txtVIN.Text;

            selectedTable = job.LoadUserJobsNames();
            listSelectedJobs.DataSource = selectedTable;
            listSelectedJobs.DisplayMember = "JobName";
            listSelectedJobs.ValueMember = "JobId";

            var cmp = new Company();
            cmp.CompanyId= int.Parse(cmbCompany.SelectedValue.ToString());
            DataRow[] rw;
            JobsByCompanyDt = cmp.LoadJobsByCompany();

            for (int i = 0; i < listSelectedJobs.Items.Count; i++)
            {
               rw= JobsByCompanyDt.Select("JobId=" + selectedTable.Rows[i]["JobId"].ToString());
               int r=  rw.Count();
                if(r>0)
                {
                    foreach (var item in rw)
                    {
                        JobsByCompanyDt.Rows.Remove(item); 
                    }
                    
                }
            }

            listJobs.DataSource = JobsByCompanyDt;
            listJobs.DisplayMember = "JobName";
            listJobs.ValueMember = "JobId";


        }
    }

   

    

}
