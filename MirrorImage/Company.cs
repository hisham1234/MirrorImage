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
    public class Company
    {
        public string CompanyName { get; set; }
        public int CompanyId { get; set; }
        public Job Job;
        public string Address { get; set; }
        public string PhoneNumber { get; set; }


        private string conStr = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        public Company()
        {

        }

        public Company(Job jb)
        {
            Job = jb;
        }
        public void AddCompany()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO COMPANY (CompanyName,IsDeleted,ADDRESS,PHONENUMBER)VALUES(@NAME,0,@ADDRESS,@PHN)", con);
            cmd.Parameters.AddWithValue("@NAME", this.CompanyName);
            cmd.Parameters.AddWithValue("@ADDRESS", this.Address);
            cmd.Parameters.AddWithValue("@PHN", this.PhoneNumber);

            var a = cmd.ExecuteNonQuery();
            con.Close();


        }

        public void UpdateCompany()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("EXEC SP_UPDATE_DELETE_COMPANY @CID,@NAME,@ADDRESS,@PHONE,1,0", con);

            cmd.Parameters.AddWithValue("@CID", this.CompanyId);
            cmd.Parameters.AddWithValue("@NAME", this.CompanyName);
            cmd.Parameters.AddWithValue("@ADDRESS", this.Address);
            cmd.Parameters.AddWithValue("@PHONE", this.PhoneNumber);

            var a = cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteCompany()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("EXEC SP_UPDATE_DELETE_COMPANY @CID,@NAME,@ADDRESS,@PHONE,0,1", con);

            cmd.Parameters.AddWithValue("@CID", this.CompanyId);
            cmd.Parameters.AddWithValue("@NAME", this.CompanyName);
            cmd.Parameters.AddWithValue("@ADDRESS", this.Address);
            cmd.Parameters.AddWithValue("@PHONE", this.PhoneNumber);

            var a = cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable LoadCompany()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select CompanyId,CompanyName,ADDRESS,PHONENUMBER from VW_LOADCOMPANIES", con);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;


        }

        public void AddCompanyJobs()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("EXEC SP_ADDCOMPANYJOBS @CID,@JID,@PRICE", con);
            cmd.Parameters.AddWithValue("@CID", this.CompanyId);
            cmd.Parameters.AddWithValue("@JID", this.Job.JobId);
            cmd.Parameters.AddWithValue("@PRICE", this.Job.price);

            var a = cmd.ExecuteNonQuery();
            con.Close();

        }

        public DataTable LoadJobPrices()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from VW_JOBSPRICE_VIEW", con);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;

        }

        public void UpdateJobsPrice()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("EXEC SP_UPDATE_PRICE @CID,@JID,@PRICE,0,1", con);
            cmd.Parameters.AddWithValue("@CID", this.CompanyId);
            cmd.Parameters.AddWithValue("@JID", this.Job.JobId);
            cmd.Parameters.AddWithValue("@PRICE", this.Job.price);

            var a = cmd.ExecuteNonQuery();
            con.Close();

        }

        public void DeleteJobsPrice()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("EXEC SP_UPDATE_PRICE @CID,@JID,@PRICE,1,0", con);
            cmd.Parameters.AddWithValue("@CID", this.CompanyId);
            cmd.Parameters.AddWithValue("@JID", this.Job.JobId);
            cmd.Parameters.AddWithValue("@PRICE", this.Job.price);

            var a = cmd.ExecuteNonQuery();
            con.Close();

        }

        public DataTable LoadJobsByCompany()
        {
            
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select JobId,JobName from VW_JOBSPRICE_VIEW where CompanyId=@CID", con);
            cmd.Parameters.AddWithValue("@CID", this.CompanyId);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
           
            con.Close();
            return dt;
        }

        public bool IsCompanyJobIsUsed()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) as jobCount from UserJobs where JobId=@JID and CompanyId=@CID", con);
            cmd.Parameters.AddWithValue("@JID", this.Job.JobId);
            cmd.Parameters.AddWithValue("@CID", this.CompanyId);
            int jCount = int.Parse(cmd.ExecuteScalar().ToString());


            con.Close();
            if (jCount > 0)
                return true;
            else
                return false;
        }

        public bool IsCompanyIsUsed()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) as comCount from UserJobs where CompanyId=@CID", con);
            cmd.Parameters.AddWithValue("@CID", this.CompanyId);
            int cCount = int.Parse(cmd.ExecuteScalar().ToString());


            con.Close();
            if (cCount > 0)
                return true;
            else
                return false;
        }
        
    }
}
