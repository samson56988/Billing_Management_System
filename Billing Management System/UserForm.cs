using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Billing_Management_System
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }
        public static string transactionType;
        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            transactionType = "Purchase";
            PurchaseAndSales purchase = new PurchaseAndSales();
            purchase.Show();
            
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            label2.Text = Login.loggein;
        }

        private void salesFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            transactionType = "Sales";
            PurchaseAndSales sales = new PurchaseAndSales();
            sales.Show();
            
        }
    }
}
