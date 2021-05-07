using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Windows.Forms;
using Billing_Management_System.BLL;

namespace Billing_Management_System.DAL
{
    class CustomerDal
    {
        public string myconstring = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;

        public DataTable select()
        {

            SqlConnection con = new SqlConnection(myconstring);

            DataTable dt = new DataTable();
            try
            {
                string sql = "Select * from customer";
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

        public bool insert( CustomerBll c)
        {

            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconstring);

            try
            {

                String sql = "Insert into customer(type,name,email,contact,address,added_date,added_by)Values(@type,@name,@email,@contact,@address,@added_date,@added_by)";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@type", c.Type);
                cmd.Parameters.AddWithValue("@name", c.name);
                cmd.Parameters.AddWithValue("@email", c.Email);
                cmd.Parameters.AddWithValue("@contact", c.Contact);
                cmd.Parameters.AddWithValue("@address", c.Address);
                cmd.Parameters.AddWithValue("@added_date", c.added_date);
                cmd.Parameters.AddWithValue("@added_by", c.added_by);

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

        public bool update(CustomerBll c)
        {

            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconstring);

            try
            {

                String sql = "Update customer set type = @type,name = @name,email=@email,contact=@contact,address=@address,added_date=@added_date,added_by=@added_by where id=@id";
                SqlCommand cmd = new SqlCommand(sql, con);


                cmd.Parameters.AddWithValue("@type", c.Type);
                cmd.Parameters.AddWithValue("@name", c.name);
                cmd.Parameters.AddWithValue("@email", c.Email);
                cmd.Parameters.AddWithValue("@contact", c.Contact);
                cmd.Parameters.AddWithValue("@address", c.Address);
                cmd.Parameters.AddWithValue("@added_date", c.added_date);
                cmd.Parameters.AddWithValue("@added_by", c.added_by);
                cmd.Parameters.AddWithValue("@id", c.id);



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

        public bool Delete(CustomerBll c)
        {

            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconstring);

            try
            {
                string query = "Delete From customer where id = @id";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", c.id);
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

        public CustomerBll searchcustomerDealerorforTransaction(string keyword)
        {
            CustomerBll dc = new CustomerBll();

            SqlConnection conn = new SqlConnection(myconstring);

          

            DataTable dt = new DataTable();

            try{
            
                string sql = "Select name,email,contact,address from customer where id like '%" + keyword + "%' or name Like '%" + keyword + "%' ";

                SqlDataAdapter adapter = new SqlDataAdapter(sql,conn);

                conn.Open();

                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    dc.name = dt.Rows[0]["name"].ToString();
                    dc.Email = dt.Rows[0]["email"].ToString();
                    dc.Contact = dt.Rows[0]["contact"].ToString();
                    dc.Address = dt.Rows[0]["address"].ToString();
                    
               }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {

                conn.Close();
            
            }

            return dc;
        }

        public CustomerBll GetCustomerIDFromname(string Name)
        {
            CustomerBll dc = new CustomerBll();

            SqlConnection conn = new SqlConnection(myconstring);

            DataTable dt = new DataTable();

            try
            {
                string sql = "Select id from customer where name = '"+Name+"'";

                SqlDataAdapter adapter = new SqlDataAdapter(sql,conn);

                conn.Open();


                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    dc.id = int.Parse(dt.Rows[0]["id"].ToString());
                
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
            finally
            { 
            
            
            }

            return dc;
        
        }


    }
}
