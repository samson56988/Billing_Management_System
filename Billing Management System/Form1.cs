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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users us = new Users();
            us.Show();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Admin_Load(object sender, EventArgs e)
        {
            label2.Text = Login.loggein;
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoriesForm cat = new CategoriesForm();
            cat.Show();

        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            p.Show();
        }

        private void customersDealersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customers cs = new Customers();
            cs.Show();
        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transaction tran = new Transaction();
            tran.Show();
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory iv = new Inventory();
            iv.Show();
        }
    }
}
