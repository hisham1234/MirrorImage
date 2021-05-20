using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MirrorImage
{
    public partial class AddJobs : Form
    {
        public AddJobs()
        {
            InitializeComponent();
        }

        private void AddJob_Click(object sender, EventArgs e)
        {
            var job = new Job();
            job.JobName = txtJob.Text.Trim(); ;

            try
            {
                if (job.JobName == "")
                {
                    MessageBox.Show("Job Name Cannot be empty");

                }
                else
                {

                    job.AddJobs();
                    MessageBox.Show("Job Added Successfully !");
                    txtJob.Text = "";
                    jobGrid.DataSource = job.LoadJobs();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error !");
            }

        }

        private void AddJobs_Load(object sender, EventArgs e)
        {
            var job = new Job();
           
            jobGrid.DataSource = job.LoadJobs ();
           
            
            txtJobId.Visible = false;
            jobGrid.AllowUserToAddRows = false;
            jobGrid.ReadOnly = true;
            
           

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var job = new Job();
            try
            {
                string jobId = txtJobId.Text.ToString();
                if (jobId != "")
                {
                    string jobText = txtJob.Text.Trim();
                    if (jobText != "")
                    {
                        job.JobId = int.Parse(txtJobId.Text.ToString());
                        job.JobName = jobText;


                        job.UpdateJobs();
                        MessageBox.Show("Job Name Successfully Updated!");
                        txtJobId.Text = "";
                        txtJob.Text = "";
                        jobGrid.DataSource = job.LoadJobs();
                    }
                    else
                    {
                        MessageBox.Show("Please Enter a Value For the Job Name!");
                    }
                }
                else
                {
                    MessageBox.Show("Please Select a Record To Update !");
                }


            }
            catch (Exception)
            {

                MessageBox.Show("Error !");
            }
        }

        private void jobGrid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
             txtJob.Text= jobGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtJobId.Text= jobGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var job = new Job();
            try
            {
                string jobId = txtJobId.Text.ToString();
                if (jobId != "")
                {

                    job.JobId = int.Parse(txtJobId.Text.ToString());
                    job.JobName = txtJob.Text;
                    job.DeleteJobs();
                    MessageBox.Show("Job Successfully Deleted!");
                    jobGrid.DataSource = job.LoadJobs();
                    jobGrid.ClearSelection();
                    txtJob.Text = "";
                }
                else
                {
                    MessageBox.Show("Please Select a Record To Delete !");
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Error !");
            }
        }
    }
}
