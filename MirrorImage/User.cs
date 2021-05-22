using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace MirrorImage
{
     public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
        public string VIN { get; set; }

        private string conStr = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;


        public void AddUser()
        {
            
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO USERS (USERNAME,PASSWORD)VALUES(@NAME,@PASSWORD,@ISDELETED)", con);
            cmd.Parameters.AddWithValue("@NAME", UserName);
            cmd.Parameters.AddWithValue("@PASSWORD", Password);
            cmd.Parameters.AddWithValue("@ISDELETED", 0);
            var a= cmd.ExecuteNonQuery();
            con.Close();


        }
        public void UpdateUser()
        {

            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("EXEC SP_UPDATE_USER @USERNAMAE,@PASSWORD,@UID", con);
            cmd.Parameters.AddWithValue("@USERNAMAE", UserName);
            cmd.Parameters.AddWithValue("@PASSWORD", Password);
            cmd.Parameters.AddWithValue("@UID", Id);
            var a = cmd.ExecuteNonQuery();
            con.Close();


        }

        public void DeleteUser()
        {

            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("EXEC SP_DELETE_USER @UID", con);
            
            cmd.Parameters.AddWithValue("@UID", Id);
            var a = cmd.ExecuteNonQuery();
            con.Close();


        }

        public DataTable LoadUsers()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Users WHERE ISNULL(ISDELETED, 0) = 0", con);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
            
            
        }
        
    }
}
