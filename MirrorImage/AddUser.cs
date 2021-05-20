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



        }
    }
}
