using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing_Management_System.BLL;
using Billing_Management_System.DAL;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Billing_Management_System.DAL
{
    class ProductDAL

    {
        public string myconstring = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;

        public DataTable select()
        {

            SqlConnection con = new SqlConnection(myconstring);

            DataTable dt = new DataTable();
            try
            {
                string sql = "Select * from Products";
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

        public bool insert(Productbll p)
        {

            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconstring);

            try
            {

                String sql = "Insert into Products(name,category,description,rate,quantity,added_date,added_by)Values(@name,@category,@description,@rate,@quantity,@added_date,@added_by)";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@name", p.name);
                cmd.Parameters.AddWithValue("@category", p.category);
                cmd.Parameters.AddWithValue("@description", p.description);
                cmd.Parameters.AddWithValue("@rate", p.rate);
                cmd.Parameters.AddWithValue("@quantity", p.qty);
                cmd.Parameters.AddWithValue("@added_date", p.added_date);
                cmd.Parameters.AddWithValue("@added_by", p.added_by);

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

        public bool update(Productbll p)
        {

            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconstring);

            try
            {

                String sql = "Update Products set name = @name,category = @category, description = @description,rate = @rate,quantity = @quantity,added_by = @added_by where id=@id";
                SqlCommand cmd = new SqlCommand(sql, con);


                cmd.Parameters.AddWithValue("@name", p.name);
                cmd.Parameters.AddWithValue("@category", p.category);
                cmd.Parameters.AddWithValue("@description", p.description);
                cmd.Parameters.AddWithValue("@rate", p.rate);
                cmd.Parameters.AddWithValue("@quantity", p.qty);
                cmd.Parameters.AddWithValue("@added_date", p.added_date);
                cmd.Parameters.AddWithValue("@added_by", p.added_by);
                cmd.Parameters.AddWithValue("@id", p.id);



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

        public bool Delete(Productbll p)
        {

            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconstring);

            try
            {
                string query = "Delete From Products where id=@id";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", p.id);
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

        public Productbll searchproductforTransaction(string keyword)
        {
            Productbll dc = new Productbll();

            SqlConnection conn = new SqlConnection(myconstring);



            DataTable dt = new DataTable();

            try
            {

                string sql = "Select name,rate,quantity from Products where id like '%" + keyword + "%' or name Like '%" + keyword + "%' ";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                conn.Open();

                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    dc.name = dt.Rows[0]["name"].ToString();
                    dc.rate = decimal.Parse(dt.Rows[0]["rate"].ToString());
                    dc.qty = decimal.Parse(dt.Rows[0]["quantity"].ToString());
                   

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

        public Productbll GetProductIDFromName(string ProductName)
        {
            Productbll p = new Productbll();

            SqlConnection conn = new SqlConnection(myconstring);

            DataTable dt = new DataTable();

            try
            {
                string sql = "Select id from Products where name = '" + ProductName + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                conn.Open();


                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    p.id = int.Parse(dt.Rows[0]["id"].ToString());

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
            finally
            {


            }

            return p;

        }

        public decimal getProductQty(int ProductID)
        {

            SqlConnection conn = new SqlConnection(myconstring);

            decimal qty = 0;

            DataTable dt = new DataTable();

            try
            {

                string sql = "Select quantity from Products where id ="+ProductID;

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                conn.Open();

                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    qty = decimal.Parse(dt.Rows[0]["quantity"].ToString());
                
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


            return qty;
        
        }

        public bool UpdateQuantity(int ProductID, decimal qty)
        {
            bool success = false;

            SqlConnection conn = new SqlConnection(myconstring);

            try
            {
                string sql = "Update Products set quantity = @quantity where id = @id";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@quantity", qty);
                cmd.Parameters.AddWithValue("@id", ProductID);


                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {

                    success = true;
                }
                else 
                {
                    success = false;
                
                }


            }
            catch
            {

                conn.Close();
            
            }


            return success;
        
           
        }

        public bool IncreaseProduct(int ProductID, decimal IncreaseQty)
        {

            bool success = false;


            SqlConnection conn = new SqlConnection(myconstring);

            try
            {
               
                decimal currentQty = getProductQty(ProductID);

                     decimal NewQty = currentQty + IncreaseQty;

                     success = UpdateQuantity(ProductID, NewQty);
            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {

                conn.Close();
            
            }
            return success;
        }

        public bool DecreaseProduct(int ProductID, decimal Qty)
        {

            bool success = false;

            SqlConnection con = new SqlConnection(myconstring);

            try
            {
                decimal currentQty = getProductQty(ProductID);

                decimal NewQty = currentQty - Qty;

                success = UpdateQuantity(ProductID, NewQty);


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {

                con.Close();
            
            }

            return success;
        
        }

        public DataTable DisplayProductByCategory(string category)
        {

            SqlConnection conn = new SqlConnection(myconstring);

            DataTable dt = new DataTable();

            try
            {
                string sql = "Select * from Products where category ='"+category+"'";

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                conn.Open();

                adapter.Fill(dt);


            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {

                conn.Close();
            
            }



            return dt;
        
        
        }

    }
}
