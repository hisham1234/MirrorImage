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
            SqlCommand cmd = new SqlCommand("INSERT INTO USERS (USERNAME,PASSWORD)VALUES(@NAME,@PASSWORD)",con);
            cmd.Parameters.AddWithValue("@NAME", UserName);
            cmd.Parameters.AddWithValue("@PASSWORD", Password);

            var a= cmd.ExecuteNonQuery();
            con.Close();


        }

        public DataTable LoadUsers()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Users", con);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
            
            
        }
        
    }
}
