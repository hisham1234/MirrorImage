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
    public partial class AddCompany : Form
    {
        public AddCompany()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            var cmp = new Company();
            cmp.CompanyName = CmpnyTxt.Text.Trim();
            cmp.Address = txtAddress.Text;
            cmp.PhoneNumber = txtPhn.Text;

            try
            {
                if (cmp.CompanyName == "")
                {
                    MessageBox.Show("Company Name Cannot be empty");

                }
                else
                {

                    cmp.AddCompany();
                    MessageBox.Show("Company Added Successfully !");
                    cmpnyGrid.DataSource = cmp.LoadCompany();
                    clearText();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error !");
            }
            
        }

        private void AddCompany_Load(object sender, EventArgs e)
        {
            var company = new Company();
            cmpnyGrid.DataSource = company.LoadCompany();
            cmpnyGrid.AllowUserToAddRows = false;
            cmpnyGrid.Columns[0].Visible = false;
            txtCmpId.Visible = false;
            clearText();

        }

        private void cmpnyGrid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CmpnyTxt.Text = cmpnyGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCmpId.Text = cmpnyGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAddress.Text= cmpnyGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPhn.Text = cmpnyGrid.Rows[e.RowIndex].Cells[3].Value.ToString();



        }

        private void clearText()
        {
            CmpnyTxt.Text = "";
            txtCmpId.Text = "";
            txtAddress.Text = "";
            txtPhn.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var com = new Company();
            if(txtCmpId.Text!="")
            {
                try
                {
                    com.CompanyId = int.Parse(txtCmpId.Text.ToString());
                    com.CompanyName = CmpnyTxt.Text.Trim();
                    com.Address = txtAddress.Text;
                    com.PhoneNumber = txtPhn.Text;
                    if(com.CompanyName=="")
                    {
                        MessageBox.Show("Company Name cannot be empty");
                    }
                    else
                    {
                        com.UpdateCompany();
                        MessageBox.Show("Company Details Updated Successfully");
                        cmpnyGrid.DataSource= com.LoadCompany();
                        clearText();
                    }
                    
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                   
                }
              
            }
            else
            {
                MessageBox.Show("Please select a record to update!");
            }

            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtCmpId.Text != "")
            {
                try
                {
                    var com = new Company();
                    com.CompanyId = int.Parse(txtCmpId.Text.ToString());
                    com.CompanyName = CmpnyTxt.Text.Trim();
                    com.Address = txtAddress.Text;
                    com.PhoneNumber = txtPhn.Text;

                    var IsCompanyInUse = com.IsCompanyIsUsed();
                    if(IsCompanyInUse)
                    {
                        MessageBox.Show("The Company Cannot be deleted. Users have using the services of this company !");
                    }
                    else
                    {
                        com.DeleteCompany();
                        MessageBox.Show("Successfully Deleted !");
                        clearText();
                        cmpnyGrid.DataSource = com.LoadCompany();
                    }
                    

                }
                catch (Exception)
                {

                    MessageBox.Show("Error !");
                }
                
            }
            else
            {
                MessageBox.Show("Please select a record to delete!");
            }
              
        }
    }
}
