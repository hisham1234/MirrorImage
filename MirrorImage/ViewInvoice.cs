using Microsoft.Reporting.WinForms;
using MirrorImage.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MirrorImage
{
    public partial class ViewInvoice : Form
    {
        private string conStr = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        Job jobParam = new Job(new Company(), new User());
        public ViewInvoice()
        {
            InitializeComponent();
        }
        public ViewInvoice(Job job)
        {
            jobParam = job;
            InitializeComponent();
        }

        private void ViewInvoice_Load(object sender, EventArgs e)
        {

            this.reportInvoice.RefreshReport();
            
            

            var ds = new InvoiceDataset();

            var da = jobParam.LoadUserJobsDetails();
            da.Fill(ds, "InvoiceDataTable");



            var dts = new ReportDataSource("DataSetReport", ds.Tables[0]);
            //var dts = new ReportDataSource("DataSet1", ds.Tables[0]);
            reportInvoice.LocalReport.DataSources.Clear();
            reportInvoice.LocalReport.DataSources.Add(dts);

            reportInvoice.RefreshReport();
        }

        private void btnShowInvoice_Click(object sender, EventArgs e)
        {
            // var con = new SqlConnection(conStr);
            var job = new Job(new Company(),new User());
            job.com.CompanyId = 3;
            job.usr.VIN = "1C4RJEBG6LC118522";
            //job.Date = "2021/5/20";

            var ds = new InvoiceDataset();
           
              var da=job.LoadUserJobsDetails();
            da.Fill(ds, "InvoiceDataTable");
            

          
            var dts = new ReportDataSource("DataSetReport", ds.Tables[0]);
            reportInvoice.LocalReport.DataSources.Clear();
            reportInvoice.LocalReport.DataSources.Add(dts);
            
            reportInvoice.RefreshReport();
           

        }
    }
}
