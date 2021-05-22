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
        private int rowId = -1;

        public AddJobsByVIN()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string VIN = txtVIN.Text; //"1C4RJEBG6LC118522"; //3C4NJDAB8MT566152
            
            string url = "https://vpic.nhtsa.dot.gov/api/vehicles/DecodeVin/"+ VIN + "?format=JSON";

            if (VIN.Trim()=="")
            {
                MessageBox.Show("Please provide the VIN !");
            }
            else
            {
                try
                {
                    var api = new APIAccess();
                    var obj = api.GenericGet(url);
                    if (obj.Result.IsSucess)
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


        }

        private void AddJobsByVIN_Load(object sender, EventArgs e)
        {
            txtMake.ReadOnly = true;
            txtModel.ReadOnly = true;
            txtYear.ReadOnly = true;
            txtDate.Visible = false;
            txtInvoiceId.Visible = false;

            rowId = -1;
            txtInvoiceId.Text = "";
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
            grdUserJobs.Columns[0].Visible = false;
            grdUserJobs.Columns[1].Visible = false;
           
            grdUserJobs.AllowUserToAddRows = false;
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
            selectedTable.Rows.Clear();
           

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
        public void ClearText()
        {
            txtVIN.Text = "";
            txtYear.Text = "";
            txtModel.Text = "";
            txtStockNumber.Text = "";
            txtColor.Text = "";
            selectedTable.Clear();
            txtMake.Text = "";
            JobsByCompanyDt.Clear();
            txtInvoiceId.Text = "";
           // listSelectedJobs.Items.Clear() ;

        }
        private void btnAddJobs_Click(object sender, EventArgs e)
        {
            try
            {
                var job = new Job(new Company(), new User());
                job.usr.VIN = txtVIN.Text.Trim();
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

                if (job.usr.VIN=="")
                {
                    MessageBox.Show("Please Enter the VIN !");
                }else if(listSelectedJobs.Items.Count==0)
                {
                    MessageBox.Show("Please Select the jobs !");
                }
                else
                {
                    try
                    {
                        int InvoiceId = job.GetMaxInvoiceId() + 1;
                    job.InvoiceId = InvoiceId;
                    
                    for (int i = 0; i < selectedTable.Rows.Count; i++)
                    {
                        job.JobId = int.Parse(selectedTable.Rows[i]["JobId"].ToString());
                        job.InsertUserJobs(trn, con);


                    }
                    
                    
                        trn.Commit();
                        con.Close();

                        grdUserJobs.DataSource = job.LoadUserJobs();
                        ClearText();
                        MessageBox.Show("Jobs Information Successfully Saved");
                    }
                    catch (Exception)
                    {
                        trn.Rollback();
                        MessageBox.Show("Error !");
                    }
                    
                }

                

            }
            catch (Exception)
            {
                
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
            txtDate.Text= grdUserJobs.Rows[e.RowIndex].Cells["Date"].Value.ToString();
            txtInvoiceId.Text= grdUserJobs.Rows[e.RowIndex].Cells["INVOICEID"].Value.ToString();

            rowId = e.RowIndex;

            var job = new Job(new Company(), new User());
            job.com.CompanyId = int.Parse( cmbCompany.SelectedValue.ToString());
            
            job.usr.VIN = txtVIN.Text;

            job.InvoiceId = int.Parse(txtInvoiceId.Text.ToString());
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtInvoiceId.Text=="")
            {
                MessageBox.Show("Please select a record !");
            }else
            {
                var job = new Job(new Company(), new User());
               
                job.InvoiceId = int.Parse(txtInvoiceId.Text.ToString());

                var vin = new ViewInvoice(job);
                ClearText();
                grdUserJobs.ClearSelection();
                vin.Show();

            }



        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(txtInvoiceId.Text=="")
            {
                MessageBox.Show("Please Select a record");
            }
            else
            {
                var job = new Job(new Company(), new User());
                job.usr.VIN = txtVIN.Text.Trim();
                job.year = txtYear.Text;
                job.Make = txtMake.Text;
                job.Model = txtModel.Text;
                job.stockNo = txtStockNumber.Text;
                job.Color = txtColor.Text;
                job.com.CompanyId = int.Parse(cmbCompany.SelectedValue.ToString());
                job.usr.Id = 1;
                job.InvoiceId =int.Parse( txtInvoiceId.Text.ToString());
                job.Date = txtDate.Text;

                try
                {
                    
                  

                    var con = new SqlConnection(conStr);
                    con.Open();
                    trn = con.BeginTransaction();

                    if (job.usr.VIN == "")
                    {
                        MessageBox.Show("Please Enter the VIN !");
                    }
                    else if (listSelectedJobs.Items.Count == 0)
                    {
                        MessageBox.Show("Please Select the jobs !");
                    }
                    else
                    {
                        try
                        {
                            job.DeleteUserJobs(trn, con);
                        for (int i = 0; i < selectedTable.Rows.Count; i++)
                        {
                            job.JobId = int.Parse(selectedTable.Rows[i]["JobId"].ToString());
                            job.UpdateUserJobs(trn, con);


                        }

                        
                            trn.Commit();
                            con.Close();
                            grdUserJobs.DataSource = job.LoadUserJobs();
                            ClearText();
                            MessageBox.Show("Jobs Information Successfully Updated");
                        }
                        catch (Exception)
                        {
                            trn.Rollback();
                            MessageBox.Show("Error !");
                        }
                       
                    }



                }
                catch (Exception)
                {

                    MessageBox.Show("Error !");
                }



            }
        }
    }

   

    

}
