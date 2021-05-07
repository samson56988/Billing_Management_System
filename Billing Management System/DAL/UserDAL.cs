using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
using Billing_Management_System.BLL;
namespace Billing_Management_System.DAL
{
    class UserDAL
    {
        public string myconstring = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;


        public DataTable select()
        {

            SqlConnection con = new SqlConnection(myconstring);

            DataTable dt = new DataTable();
            try
            {
                string sql = "Select * from Users";
                SqlCommand cmd = new SqlCommand(sql,con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con.Open();
                adapter.Fill(dt);
                

            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
            finally
            {

                con.Close();
            
            }
            return dt;

        
        }

        public DataTable Search(string Keywords)
        {

            SqlConnection con = new SqlConnection(myconstring);

            DataTable dt = new DataTable();
            try
            {
                string sql = "Select * from Users where id Like '%"+Keywords+"%' OR Firstname Like'%"+Keywords+"%'"  ;
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con.Open();
                adapter.Fill(dt);


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
            finally
            {

                con.Close();

            }
            return dt;


        }

        public bool insert(usebll u)
        {

            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconstring);

            try
            {

                String sql = "Insert into Users(Firstname,Lastname,email,username,password,contact,address,gender,user_type,added_date,addedby)Values(@Firstname,@Lastname,@email,@username,@password,@contact,@address,@gender,@user_type,@added_date,@addedby)";
                SqlCommand cmd = new SqlCommand(sql,con);

                cmd.Parameters.AddWithValue("@Firstname", u.first_name);
                cmd.Parameters.AddWithValue("@Lastname", u.last_name);
                cmd.Parameters.AddWithValue("@email", u.email);
                cmd.Parameters.AddWithValue("@username", u.username);
                cmd.Parameters.AddWithValue("@password", u.password);
                cmd.Parameters.AddWithValue("@contact", u.Contact);
                cmd.Parameters.AddWithValue("@address", u.address);
                cmd.Parameters.AddWithValue("@gender", u.gender);
                cmd.Parameters.AddWithValue("@user_type", u.user_type);
                cmd.Parameters.AddWithValue("@added_date", u.added_date);
                cmd.Parameters.AddWithValue("@addedby", u.addedby);

                con.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
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

        public bool update(usebll u)
        {

            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconstring);

            try
            {

                string sql = "update Users set Firstname = @Firstname,Lastname=@Lastname,email=@email,username=@username,password=@password,contact=@contact,address=@address,gender=@gender,user_type=@user_type,added_date=@addeddate,addedby=@addedby where id=@Userid";
                SqlCommand cmd = new SqlCommand(sql,con);

                cmd.Parameters.AddWithValue("@Userid", u.id);
                cmd.Parameters.AddWithValue("@Firstname", u.first_name);
                cmd.Parameters.AddWithValue("@Lastname", u.last_name);
                cmd.Parameters.AddWithValue("@email", u.email);
                cmd.Parameters.AddWithValue("@username", u.username);
                cmd.Parameters.AddWithValue("@password", u.password);
                cmd.Parameters.AddWithValue("@contact", u.Contact);
                cmd.Parameters.AddWithValue("@address", u.address);
                cmd.Parameters.AddWithValue("@gender", u.gender);
                cmd.Parameters.AddWithValue("@user_type", u.user_type);
                cmd.Parameters.AddWithValue("@addeddate", u.added_date);
                cmd.Parameters.AddWithValue("@addedby", u.addedby);

                con.Open();

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;

                }

                else
                {
                    isSuccess = false;

                
                }




            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            finally
            {

                con.Close();
            
            
            }

            return isSuccess;
        
        }

        public bool Delete(usebll u)
        {

            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconstring);

            try
            {
                string query = "Delete From Users where id=@id";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", u.id);
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
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

        public usebll GetIDFromUsername(string username)   
        {

            usebll u = new usebll();
            SqlConnection con = new SqlConnection(myconstring);
            DataTable dt = new DataTable();

            try
            {
                string sql = "Select id from Users where username='" + username + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(sql,con);
                con.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    u.id = int.Parse(dt.Rows[0]["id"].ToString());


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
            return u;

        
        }


    }
}
