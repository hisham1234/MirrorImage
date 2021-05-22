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
    public partial class AddCompanyJobs : Form
    {
        public AddCompanyJobs()
        {
            InitializeComponent();
        }

        private int rowId = -1;

        private void AddCompanyJobs_Load(object sender, EventArgs e)
        {
            var cmp = new Company();
            cmpCmb.DataSource = cmp.LoadCompany();
            cmpCmb.DisplayMember = "CompanyName";
            cmpCmb.ValueMember = "CompanyId";

            this.cmpCmb.DropDownStyle = ComboBoxStyle.DropDownList;
            var job = new Job();
            jobCmb.DataSource = job.LoadJobs();
            jobCmb.DisplayMember = "JobName";
            jobCmb.ValueMember = "JobId";
            this.jobCmb.DropDownStyle = ComboBoxStyle.DropDownList;

            serviceGrdVw.DataSource = cmp.LoadJobPrices();
            serviceGrdVw.Columns[0].Visible = false;
            serviceGrdVw.Columns[3].Visible = false;
            serviceGrdVw.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            serviceGrdVw.ReadOnly = true;
            serviceGrdVw.AllowUserToAddRows = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var com = new Company(new Job());
            try
            {
                string price = txtPrice.Text.Trim();
                if (price != "")
                {
                    com.Job.JobId = int.Parse(jobCmb.SelectedValue.ToString());
                    com.CompanyId = int.Parse(cmpCmb.SelectedValue.ToString());
                    com.Job.price = Decimal.Parse(txtPrice.Text.ToString());
                    

                    com.AddCompanyJobs();
                    MessageBox.Show("Price Successfully Added to the Job");
                    txtPrice.Text = "";
                    serviceGrdVw.DataSource = com.LoadJobPrices();
                }
                else
                {
                    MessageBox.Show("Please Enter a Value For the Price!");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error !");
            }
           
        }

        private void serviceGrdVw_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                
                rowId=e.RowIndex;
                jobCmb.SelectedValue = int.Parse(serviceGrdVw.Rows[e.RowIndex].Cells[3].Value.ToString());
                cmpCmb.SelectedValue = int.Parse(serviceGrdVw.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtPrice.Text= serviceGrdVw.Rows[e.RowIndex].Cells[4].Value.ToString();


            }
            catch (Exception)
            {

                MessageBox.Show("Error !");
            }
            

            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var com = new Company(new Job());
            try
            {
                string price=  txtPrice.Text.Trim();
                if (rowId != -1)
                {
                    if (price != "")
                    {
                        com.Job.JobId = int.Parse(jobCmb.SelectedValue.ToString());
                        com.CompanyId = int.Parse(cmpCmb.SelectedValue.ToString());
                        com.Job.price = Decimal.Parse(txtPrice.Text.ToString());

                        com.UpdateJobsPrice();
                        MessageBox.Show("Price Successfully Updated!");
                        txtPrice.Text = "";
                        serviceGrdVw.DataSource = com.LoadJobPrices();
                        rowId = -1;
                    }
                    else
                    {
                        MessageBox.Show("Please Enter a Value For the Price!");
                    }
                }
                else
                {
                    MessageBox.Show("Please Select A Record");
                }

                  
                
            }
            catch (Exception)
            {

                MessageBox.Show("Error !");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var com = new Company(new Job());
            try
            {
                string price = txtPrice.Text.Trim();
                if (rowId != -1)
                {
                    com.Job.JobId = int.Parse(jobCmb.SelectedValue.ToString());
                    com.CompanyId = int.Parse(cmpCmb.SelectedValue.ToString());
                    com.Job.price = Decimal.Parse(txtPrice.Text.ToString());

                   
                    var IsCompanyJobIsUsed = com.IsCompanyJobIsUsed();
                  

                    if(IsCompanyJobIsUsed)
                    {
                        MessageBox.Show("This Record Cannot be Deleted.!");
                    }
                    else
                    {
                        com.DeleteJobsPrice();
                        MessageBox.Show("Successfully Deleted!");
                        txtPrice.Text = "";
                        serviceGrdVw.DataSource = com.LoadJobPrices();
                        rowId = -1;
                    }
                   
                }
                else
                {
                    MessageBox.Show("Please Select A Record");
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Error !");
            }
        }
    }
}
