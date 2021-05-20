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
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Hi";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void ShowWorkingPnl(object frm)
        {
            if (this.ContentPnl.Controls.Count > 0)
                this.ContentPnl.Controls.RemoveAt(0);

            Form fm = frm as Form;
            fm.TopLevel = false;
            fm.Dock = DockStyle.Fill;
            this.ContentPnl.Controls.Add(fm);
            fm.Show(); 


        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            ShowWorkingPnl( new AddUser());
        }

        private void AddCmp_Click(object sender, EventArgs e)
        {
            ShowWorkingPnl(new AddCompany());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowWorkingPnl(new AddJobs());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowWorkingPnl(new AddCompanyJobs());
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowWorkingPnl(new AddJobsByVIN());
        }
    }
}
