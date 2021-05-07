using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing_Management_System.DAL;
using Billing_Management_System.BLL;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Windows.Forms;

namespace Billing_Management_System.DAL
{
    class transactionDAL
    {
        static string myconstring = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;


        public bool Insert_transaction(TransactionBll t, out int transactionID)
        {

            bool isSuccess = false;

            transactionID = -1;

            SqlConnection conn = new SqlConnection(myconstring);
            try
            {
                string sql = "Insert into transaction_tbl (type,customer_id, grandTotal,transaction_date,tax,discount,addedd_by)Values(@type,@customer_id,@grandTotal,@transaction_date,@tax,@discount,@added_by); SELECT @@IDENTITY";
                SqlCommand cmd = new SqlCommand(sql,conn);

                cmd.Parameters.AddWithValue("@type", t.type);
                cmd.Parameters.AddWithValue("@customer_id", t.dea_cust_id);
                cmd.Parameters.AddWithValue("@grandTotal",t.grandTotal);
                cmd.Parameters.AddWithValue("@transaction_date", t.transaction_date);
                cmd.Parameters.AddWithValue("@tax", t.tax);
                cmd.Parameters.AddWithValue("@discount", t.discount);
                cmd.Parameters.AddWithValue("@added_by", t.added_by);

                conn.Open();

                object o = cmd.ExecuteScalar();

                if (o != null)
                {
                    transactionID = int.Parse(o.ToString());
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

                conn.Close();
            }

            return isSuccess;
        
           
        }

        public DataTable DisplayAlltransaction()
        {

            SqlConnection conn = new SqlConnection(myconstring);

            DataTable dt = new DataTable();

            try
            {
                string Sql = "Select * from transaction_tbl ";

                SqlCommand cmd = new SqlCommand(Sql,conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                conn.Open();

                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            { 
            
            
            }
            return dt;
        
        
        }

        public DataTable DisplayTransactionType(string type)
        {
            SqlConnection con = new SqlConnection(myconstring);

            DataTable dt = new DataTable();

            try
            {

                string sql = "Select * from transaction_tbl where type ='" + type + "' ";

                SqlCommand cmd = new SqlCommand(sql, con);

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
            
            
            
            }


            return dt;
        }
    }
}
