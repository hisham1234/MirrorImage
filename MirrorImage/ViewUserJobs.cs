using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MirrorImage
{
    public partial class ViewUserJobs : Form
    {
        private string conStr = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        SqlTransaction trn;
        private DataTable userJobsFiltered;
        private DataTable allUserJobs;

        public ViewUserJobs()
        {
            InitializeComponent();
        }

        private void ViewUserJobs_Load(object sender, EventArgs e)
        {
            txtInvoiceId.Visible = false;

            var job = new Job();
            var com = new Company();

            cmbCompany.DataSource = com.LoadCompany();
            cmbCompany.DisplayMember = "CompanyName";
            cmbCompany.ValueMember = "CompanyId";

            allUserJobs = job.LoadUserJobs();
            grdUserJobs.DataSource = job.LoadUserJobs();
            grdUserJobs.Columns[0].Visible = false;
            grdUserJobs.Columns[1].Visible = false;
            grdUserJobs.ReadOnly = true;
            grdUserJobs.AllowUserToAddRows = false;
            ClearText();
        }

        private void grdUserJobs_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            txtInvoiceId.Text = grdUserJobs.Rows[e.RowIndex].Cells["INVOICEID"].Value.ToString();

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (txtInvoiceId.Text == "")
            {
                MessageBox.Show("Please select a record !");
            }
            else
            {
                var job = new Job();

                job.InvoiceId = int.Parse(txtInvoiceId.Text.ToString());

                var vin = new ViewInvoice(job);
                vin.Show();
                ClearText();
                grdUserJobs.ClearSelection();
                

            }
        }

        private void ClearText()
        {
            txtInvoiceId.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtInvoiceId.Text == "")
            {
                MessageBox.Show("Please select a record !");
            }
            else
            {
                try
                {
                    var job = new Job();

                    job.InvoiceId = int.Parse(txtInvoiceId.Text.ToString());

                    var con = new SqlConnection(conStr);
                    try
                    {
                        con.Open();
                        trn = con.BeginTransaction();
                        job.DeleteUserJobs(trn, con);
                        trn.Commit();
                        ClearText();
                        grdUserJobs.ClearSelection();
                        grdUserJobs.DataSource = job.LoadUserJobs();
                        MessageBox.Show("Record Deleted Successfully !");

                    }
                    catch (Exception)
                    {

                        trn.Rollback();
                        MessageBox.Show("Error !");
                    }

                }
                catch (Exception)
                {

                    MessageBox.Show("Error !");
                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtVIN.Text == "" && txtStock.Text == "")
                {
                    userJobsFiltered = allUserJobs.Select("CompanyId=" + cmbCompany.SelectedValue.ToString()).CopyToDataTable();
                    grdUserJobs.DataSource = userJobsFiltered;
                }
                else if (txtVIN.Text == "")
                {
                    // userJobsFiltered = allUserJobs.Select("CompanyId=" + cmbCompany.SelectedValue.ToString() + " and VIN=1C4RJEBG6LC118522").CopyToDataTable();
                    userJobsFiltered = allUserJobs.Select("CompanyId= '" + cmbCompany.SelectedValue.ToString() + "'and stockNo='" + txtStock.Text + "'").CopyToDataTable();

                    grdUserJobs.DataSource = userJobsFiltered;
                }
                else if (txtStock.Text == "")
                {
                    userJobsFiltered = allUserJobs.Select("CompanyId= '" + cmbCompany.SelectedValue.ToString() + "'and VIN='" + txtVIN.Text + "'").CopyToDataTable();

                    //userJobsFiltered = allUserJobs.Select("CompanyId= '" + cmbCompany.SelectedValue.ToString() + "'and VIN='" + txtVIN.Text + "'and stockNo='" + txtStock.Text + "'").CopyToDataTable();
                    grdUserJobs.DataSource = userJobsFiltered;
                }
                else
                {
                    userJobsFiltered = allUserJobs.Select("CompanyId= '" + cmbCompany.SelectedValue.ToString() + "'and VIN='" + txtVIN.Text + "'and stockNo='" + txtStock.Text + "'").CopyToDataTable();
                    grdUserJobs.DataSource = userJobsFiltered;
                }
            }
            catch (Exception ex)
            {
                var log = new Logger();

                log.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
           
            
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            var job = new Job();
            grdUserJobs.DataSource = job.LoadUserJobs();
        }
    }
}
