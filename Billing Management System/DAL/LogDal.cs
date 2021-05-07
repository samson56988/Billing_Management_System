using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing_Management_System.BLL;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Windows.Forms;


namespace Billing_Management_System.DAL
{
    class LogDal
    {
        public string myconstring = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;


        public bool loginCheck(loginBll l)
        {

            bool isSuccess = false;

            SqlConnection con = new SqlConnection(myconstring);


            try
            {
                string sql = "Select * from Users where username=@username AND password = @password AND user_type=@user_type";

                SqlCommand cmd = new SqlCommand(sql,con);
                cmd.Parameters.AddWithValue("@username", l.username);
                cmd.Parameters.AddWithValue("@password", l.password);
                cmd.Parameters.AddWithValue("@user_type", l.Usertype);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    isSuccess = true;

                }
                else
                {
                    isSuccess = false;
                
                }


            }

            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            

            return isSuccess;
        
        }

    }
}
