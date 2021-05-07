using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Billing_Management_System.BLL;
using Billing_Management_System.DAL;
namespace Billing_Management_System
{
    public partial class Transaction : Form
    {
        transactionDAL dl = new transactionDAL();
        public Transaction()
        {
            InitializeComponent();
        }

        private void Transaction_Load(object sender, EventArgs e)
        {
            DataTable dt = dl.DisplayAlltransaction();
            dataGridView1.DataSource = dt;


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = comboBox1.Text;

            DataTable dt = dl.DisplayTransactionType(type);
            dataGridView1.DataSource = dt;
        }
    }
}
