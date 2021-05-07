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

namespace Billing_Management_System
{
    public partial class Inventory : Form
    {
        public Inventory()
        {
            InitializeComponent();
        }

        CatDAL dl = new CatDAL();
        ProductDAL pdl = new ProductDAL();

        private void Inventory_Load(object sender, EventArgs e)
        {

            DataTable cdt = dl.select();

            comboBox1.DataSource = cdt;

            comboBox1.DisplayMember = "tite";
            comboBox1.ValueMember = "tite";

            DataTable pdt = pdl.select();
            dataGridView1.DataSource = pdt;


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = comboBox1.Text;

            DataTable dt = pdl.DisplayProductByCategory(category);
            dataGridView1.DataSource = dt;
        }
    }
}
