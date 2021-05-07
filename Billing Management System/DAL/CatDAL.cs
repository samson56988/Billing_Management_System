using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Billing_Management_System.BLL;

namespace Billing_Management_System.DAL
{
    class CatDAL
    {
        public string myconstring = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;

        public DataTable select()
        {

            SqlConnection con = new SqlConnection(myconstring);

            DataTable dt = new DataTable();
            try
            {
                string sql = "Select * from table_categories";
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

        public DataTable Search(string Keywords)
        {

            SqlConnection con = new SqlConnection(myconstring);

            DataTable dt = new DataTable();
            try
            {
                string sql = "Select * from table_categories where id Like '%" + Keywords + "%' OR tite Like'%" + Keywords + "%'";
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

        public bool insert(CategoryBLL c)
        {

            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconstring);

            try
            {

                String sql = "Insert into table_categories(tite,description,added_date,addedby)Values(@tite,@description,@added_date,@addedby)";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@tite", c.Title);
                cmd.Parameters.AddWithValue("@description", c.Description);
                cmd.Parameters.AddWithValue("@added_date", c.Added_date);
                cmd.Parameters.AddWithValue("@addedby", c.added_by);
                
               

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

        public bool update(CategoryBLL c)
        {

            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconstring);

            try
            {
                
                String sql = "Update table_categories set tite = @title,description = @description,added_date = @added_date,addedby = @addedby where id=@id";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@tite", c.Title);
                cmd.Parameters.AddWithValue("@description", c.Description);
                cmd.Parameters.AddWithValue("@added_date", c.Added_date);
                cmd.Parameters.AddWithValue("@addedby", c.added_by);
                cmd.Parameters.AddWithValue("@id", c.Id);
                

                

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

        public bool Delete(CategoryBLL c)
        {

            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconstring);

            try
            {
                string query = "Delete From table_categories where id=@id";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", c.Id);
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

        public usebll GetIDFromUsername(string username)
        {

            usebll u = new usebll();
            SqlConnection con = new SqlConnection(myconstring);
            DataTable dt = new DataTable();

            try
            {
                string sql = "Select id from Users where username='" + username + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                con.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    u.id = int.Parse(dt.Rows[0]["id"].ToString());


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
            return u;


        }






    }
}
