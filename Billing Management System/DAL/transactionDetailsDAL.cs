using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Windows.Forms;
using Billing_Management_System.BLL;

namespace Billing_Management_System.DAL
{
    class transactionDetailsDAL
    {
        static string myconstring = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;

        public bool insertTransactionDetails(TransactionDetailsBll td)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconstring);
            try
            {
                string sql = "Insert into Transaction_details(product_id,rate,quantity,total,dea_customer_id,added_date,added_by)Values(@product_id,@rate,@quantity,@total,@dea_customer_id,@added_date,@added_by) ";

                SqlCommand cmd = new SqlCommand(sql,conn);

                cmd.Parameters.AddWithValue("@product_id", td.ProductID);
                cmd.Parameters.AddWithValue("@rate", td.rate);
                cmd.Parameters.AddWithValue("@quantity", td.qty);
                cmd.Parameters.AddWithValue("@total", td.total);
                cmd.Parameters.AddWithValue("@dea_customer_id", td.dea_cust_id);
                cmd.Parameters.AddWithValue("@added_date", td.added_date);
                cmd.Parameters.AddWithValue("@added_by", td.added_by);

                conn.Open();

                int row = cmd.ExecuteNonQuery();

                if (row > 0)
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
                conn.Close();
            
            }

            return isSuccess;
        }
        
        
      
    }
}
