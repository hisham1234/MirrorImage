using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MirrorImage
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var user = new User();
                user.UserName = textBox1.Text;
                user.Password = textBox2.Text;

                if (user.UserName == "" || user.Password == "")
                {
                    MessageBox.Show("Please Enter a value for User Name and Password");
                }
                else
                {
                    user.AddUser();
                    MessageBox.Show("User Successfully Added");
                    dataGridView1.DataSource = user.LoadUsers();
                    txtId.Text = "";
                    textBox1.Text = "";
                    textBox2.Text = "";
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Error!");
            }
           

            
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            var user = new User();

            dataGridView1.DataSource= user.LoadUsers();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            txtId.Text = "";

            txtId.Visible = false;
            dataGridView1.Columns["ISDELETED"].Visible = false;

            dataGridView1.Columns["userId"].HeaderText = "User Id";
            dataGridView1.Columns["username"].HeaderText = "User Name";
            dataGridView1.Columns["password"].HeaderText = "Password";
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["userName"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["password"].Value.ToString();
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells["userId"].Value.ToString();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text == "")
                {
                    MessageBox.Show("Please Select a User !");
                }
                else
                {
                    var usr = new User();
                    usr.Id = int.Parse(txtId.Text.ToString());
                    usr.DeleteUser();
                    MessageBox.Show("User Successfully Deleted");
                    txtId.Text = "";
                    textBox1.Text = "";
                    textBox2.Text = "";
                    dataGridView1.DataSource = usr.LoadUsers();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error !");
            }
            
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text == "")
                {
                    MessageBox.Show("Please Select a User !");
                }
                else
                {

                    var usr = new User();
                    usr.UserName = textBox1.Text;
                    usr.Password = textBox2.Text;
                    usr.Id = int.Parse(txtId.Text.ToString());
                    if (usr.UserName == "" || usr.Password == "")
                    {
                        MessageBox.Show("Please Enter a value for User Name and Password");
                    }
                    else
                    {
                        usr.UpdateUser();
                        MessageBox.Show("User Successfully Updated");
                        txtId.Text = "";
                        textBox1.Text = "";
                        textBox2.Text = "";
                        dataGridView1.DataSource = usr.LoadUsers();

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
