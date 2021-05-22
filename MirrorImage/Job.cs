using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirrorImage
{
    public class Job
    {
        public string JobName { get; set; }
        private string conStr = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        public int JobId { get; set; }
        public decimal price { get; set; }
        public Company com;
        public User usr;

        public string year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string stockNo { get; set; }
        public string Color { get; set; }
        public string Date { get; set; }
        public int InvoiceId { get; set; }

        public Job()
        {

        }

        public Job(Company cmp,User user)
        {
            com = cmp;
            usr = user;

        }
        public void AddJobs()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO JOBS (JobName,IsDeleted)VALUES(@NAME,0)", con);
            cmd.Parameters.AddWithValue("@NAME", this.JobName);


            var a = cmd.ExecuteNonQuery();
            con.Close();


        }

        public DataTable LoadJobs()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select JobId,JobName from VW_LOADJOBS", con);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;


        }

        public void UpdateJobs()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("EXEC SP_UPDATE_DELETE_JOB @JID,@NAME,1,0", con);
            
            cmd.Parameters.AddWithValue("@JID", this.JobId);
            cmd.Parameters.AddWithValue("@NAME", this.JobName);

            var a = cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteJobs()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("EXEC SP_UPDATE_DELETE_JOB @JID,@NAME,0,1", con);

            cmd.Parameters.AddWithValue("@JID", this.JobId);
            cmd.Parameters.AddWithValue("@NAME", this.JobName);

            var a = cmd.ExecuteNonQuery();
            con.Close();
        }

        public void InsertUserJobs(SqlTransaction trn,SqlConnection con)
        {
            
            
           // SqlConnection con = new SqlConnection(conStr);
            
           
            SqlCommand cmd = new SqlCommand("EXEC SP_INSERT_VIN_JOBS @UID,@JID, @CID ,@VIN ,@DATE ,@YEAR , @MAKE , @MODEL, @STOCKNO , @COLOR,@INID ", con);

            
            cmd.Parameters.AddWithValue("@UID", this.usr.Id);
            cmd.Parameters.AddWithValue("@JID", this.JobId);
            cmd.Parameters.AddWithValue("@CID", this.com.CompanyId);
            cmd.Parameters.AddWithValue("@VIN", this.usr.VIN);
            cmd.Parameters.AddWithValue("@DATE", DateTime.Today);
            cmd.Parameters.AddWithValue("@YEAR", this.year);
            cmd.Parameters.AddWithValue("@MAKE", this.Make);
            cmd.Parameters.AddWithValue("@MODEL", this.Model);
            cmd.Parameters.AddWithValue("@STOCKNO", this.stockNo);
            cmd.Parameters.AddWithValue("@COLOR", this.Color);
            cmd.Parameters.AddWithValue("@INID", this.InvoiceId);

            // trn = con.BeginTransaction();
            cmd.Connection = con;
            cmd.Transaction = trn;
            var a = cmd.ExecuteNonQuery();
            
        }

        public DataTable LoadUserJobs()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from VW_USER_JOBS", con);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable LoadUserJobsNames()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select JobId,JobName from VW_USER_JOBSNAME where invoiceid=@INID", con);
            cmd.Parameters.AddWithValue("@INID", this.InvoiceId);
           
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public SqlDataAdapter LoadUserJobsDetails()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from VW_USER_JOBSNAME where invoiceid=@INID", con);
            
            cmd.Parameters.AddWithValue("@INID", this.InvoiceId);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return da;
        }

        public int GetMaxInvoiceId()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select  isnull(max(invoiceid), 0) from UserJobs", con);
            
            int maxId= int.Parse( cmd.ExecuteScalar().ToString());
            con.Close();
            return maxId;
            

        }

        public bool IsJobIsUsed()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) as jobCount from UserJobs where JobId=@JID", con);
            cmd.Parameters.AddWithValue("@JID", this.JobId);
            int jCount = int.Parse(cmd.ExecuteScalar().ToString());


            con.Close();
            if (jCount > 0)
                return true;
            else
                return false;
        }
      

        public void UpdateUserJobs(SqlTransaction trn, SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("EXEC SP_UPDATE_USERJOBS @UID,@JID, @CID ,@VIN ,@DATE ,@YEAR , @MAKE , @MODEL, @STOCKNO , @COLOR,@INID ", con);


            cmd.Parameters.AddWithValue("@UID", this.usr.Id);
            cmd.Parameters.AddWithValue("@JID", this.JobId);
            cmd.Parameters.AddWithValue("@CID", this.com.CompanyId);
            cmd.Parameters.AddWithValue("@VIN", this.usr.VIN);
            cmd.Parameters.AddWithValue("@DATE", this.Date);
            cmd.Parameters.AddWithValue("@YEAR", this.year);
            cmd.Parameters.AddWithValue("@MAKE", this.Make);
            cmd.Parameters.AddWithValue("@MODEL", this.Model);
            cmd.Parameters.AddWithValue("@STOCKNO", this.stockNo);
            cmd.Parameters.AddWithValue("@COLOR", this.Color);
            cmd.Parameters.AddWithValue("@INID", this.InvoiceId);

        
            cmd.Connection = con;
            cmd.Transaction = trn;
            var a = cmd.ExecuteNonQuery();
        }

        public void DeleteUserJobs(SqlTransaction trn, SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("EXEC SP_DELETE_USERJOBS @INID ", con);


           
            cmd.Parameters.AddWithValue("@INID", this.InvoiceId);


            cmd.Connection = con;
            cmd.Transaction = trn;
            var a = cmd.ExecuteNonQuery();
        }
    }
}
