using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Billing_Management_System.DAL;
using Billing_Management_System.BLL;
using System.Transactions;

namespace Billing_Management_System
{
    public partial class PurchaseAndSales : Form
    {
        public PurchaseAndSales()
        {
            InitializeComponent();
        }
        CustomerDal dl = new CustomerDal();
        ProductDAL Pl = new ProductDAL();
        UserDAL Dal = new UserDAL();
        transactionDAL tdal = new transactionDAL();
        transactionDetailsDAL tdetailDAL = new transactionDetailsDAL();
        DataTable transactionDT = new DataTable();
        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void PurchaseAndSales_Load(object sender, EventArgs e)
        {
            string type = UserForm.transactionType;
            lblPurchaseandsales.Text = type;

            transactionDT.Columns.Add("Producct Name");
            transactionDT.Columns.Add("Rate");
            transactionDT.Columns.Add("Quantity");
            transactionDT.Columns.Add("Total");
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox1.Text;

            if (textBox1.Text == "")
            {

                txt_name.Text = "";
                txt_email.Text = "";
                txt_contact.Text = "";
                txt_address.Text = "";

            
            
            }

            CustomerBll d = dl.searchcustomerDealerorforTransaction(keyword);

            txt_name.Text = d.name;
            txt_contact.Text = d.Contact;
            txt_email.Text = d.Email;
            txt_address.Text = d.Address;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox6.Text;


            if (keyword == "")
            {

                txt_productnname.Text = "";
                txt_inventory.Text = "";
                txt_rate.Text = "";
                txt_qty.Text = "";
                return;
            
            
            }
            Productbll d = Pl.searchproductforTransaction(keyword);

            txt_productnname.Text = d.name;
            txt_inventory.Text = d.qty.ToString(); ;
            txt_rate.Text = d.rate.ToString(); ;
            



        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string Productname = txt_productnname.Text;
            decimal Rate = decimal.Parse(txt_rate.Text);
            decimal qty = decimal.Parse(txt_qty.Text);
            decimal Total = Rate * qty;

            decimal subTotal = decimal.Parse(txt_subtotal.Text);
            subTotal = subTotal + Total;

            if (Productname == "")
            {

                MessageBox.Show("Select the product first.Try again");

            }
            else
            {
                transactionDT.Rows.Add(Productname, Rate, qty,Total);

                dataGridView1.DataSource = transactionDT;

                txt_subtotal.Text = subTotal.ToString();

                textBox6.Text = "";
                txt_productnname.Text = "";
                txt_inventory.Text = "0.00";
                txt_rate.Text = "0.00";
                txt_qty.Text = "0.00";

            
            }
        }

        private void txt_discount_TextChanged(object sender, EventArgs e)
        {
            string value = txt_discount.Text;

            if (value == "")
            {

                MessageBox.Show("Please add Product");

            }
            else
            {

                decimal subtotal = decimal.Parse(txt_subtotal.Text);
                decimal discount = decimal.Parse(txt_discount.Text);

                decimal Grandtotal = ((100 - discount) / 100) * subtotal;

                txt_grand.Text = Grandtotal.ToString();

            
            
            }
        }

        private void txt_vat_TextChanged(object sender, EventArgs e)
        {
            string check = txt_grand.Text;

            if (check == "")
            {

                MessageBox.Show("Calculate the discount and set the grand total first");

            }
            else
            {

                decimal previousGT = decimal.Parse(txt_grand.Text);
                decimal vat = decimal.Parse(txt_vat.Text);
                decimal grandtotalWithVAT = ((100+vat)/100)* previousGT;

                txt_grand.Text = grandtotalWithVAT.ToString();
            
            }
        }

        private void txt_paidamount_TextChanged(object sender, EventArgs e)
        {
            decimal grandTotal = decimal.Parse(txt_grand.Text);
            decimal Paidamount = decimal.Parse(txt_paidamount.Text);

            decimal returnamount = Paidamount - grandTotal;

            return_amount.Text = returnamount.ToString();
            
            }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                 TransactionBll transaction = new TransactionBll();

            transaction.type = lblPurchaseandsales.Text;

            string deacustman = txt_name.Text;

            CustomerBll dc = dl.GetCustomerIDFromname(deacustman);

            transaction.dea_cust_id = dc.id;
            transaction.grandTotal = decimal.Parse(txt_grand.Text);
            transaction.transaction_date = DateTime.Now;
            transaction.tax = decimal.Parse(txt_vat.Text);
            transaction.discount = decimal.Parse(txt_discount.Text);

            string loggedUser = Login.loggein;
            usebll usr = Dal.GetIDFromUsername(loggedUser);
            transaction.added_by = usr.id;

            transaction.transactionDetails = transactionDT;

            bool success = false;

            using (TransactionScope scope = new TransactionScope())
            {
                int transactionID = -1;

                bool w = tdal.Insert_transaction(transaction, out transactionID);


                for (int i = 0; i < transactionDT.Rows.Count;i++)
                {

                    TransactionDetailsBll transactiondetails = new TransactionDetailsBll();

                    string Productname = txt_productnname.Text;
                    Productbll p = Pl.GetProductIDFromName(Productname);


                    string transactionType = lblPurchaseandsales.Text;

                    
                    transactiondetails.ProductID = p.id;
                    transactiondetails.rate = decimal.Parse(transactionDT.Rows[i][1].ToString());
                    transactiondetails.qty = decimal.Parse(transactionDT.Rows[i][2].ToString());
                    transactiondetails.total = decimal.Parse(transactionDT.Rows[i][3].ToString());
                    transactiondetails.dea_cust_id = dc.id;
                    transactiondetails.added_date = DateTime.Now;
                    transactiondetails.added_by = usr.id;
                    bool x = false;
                    if (transactionType == "Purchase")
                    {

                        x = Pl.IncreaseProduct(transactiondetails.ProductID, transactiondetails.qty);

                    }
                    else if (transactionType == "Sales")
                    {

                        x = Pl.DecreaseProduct(transactiondetails.ProductID, transactiondetails.qty);

                    }
                    

                    bool y = tdetailDAL.insertTransactionDetails(transactiondetails);

                    success = w & y;

                    if (success == true)
                    {
                        scope.Complete();

                        
                        MessageBox.Show("Transaction Completed Successfully");

                    }
                    else
                    {
                        MessageBox.Show("Transaction Failed");
                    
                    }




                
                }

            
            }


        

            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);
            
            }
        }
    }
}
