using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using Billing_Management_System.BLL;
using Billing_Management_System.DAL;

namespace Billing_Management_System
{
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }


        Productbll bl = new Productbll();
        ProductDAL dl = new ProductDAL();
        UserDAL l = new UserDAL();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bl.name = txt_Name.Text;
            bl.category = txt_categories.Text;
            bl.description = txt_description.Text;
            bl.qty = 0;
            bl.rate =decimal.Parse(txt_rate.Text);
            bl.added_date = DateTime.Now;
            string loggedUser = Login.loggein;
            usebll usr = l.GetIDFromUsername(loggedUser);
            bl.added_by = usr.id;

            bool success = dl.insert(bl);

            if (success == true)
            {

                MessageBox.Show("Product Successfully Added");



            }
            else
            {

                MessageBox.Show("Failed to add new Category");
            }
            DataTable dt = dl.select();
            dataGridView1.DataSource = dt;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bl.id = Convert.ToInt32(txt_productID.Text);
             bl.name = txt_Name.Text;
            bl.category = txt_categories.Text;
            bl.description = txt_description.Text;
            bl.qty = 0;
            bl.rate =decimal.Parse(txt_rate.Text);
            bl.added_date = DateTime.Now;
            string loggedUser = Login.loggein;
            usebll usr = l.GetIDFromUsername(loggedUser);
            bl.added_by = usr.id;

            bool success = dl.update(bl);

            if (success == true)
            {

                MessageBox.Show("Product Updated Added");



            }
            else
            {

                MessageBox.Show("Failed to add new Category");
            }
            DataTable dt = dl.select();
            dataGridView1.DataSource = dt;
        }
        

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            bl.id = Convert.ToInt32(txt_productID.Text);

            bool success = dl.Delete(bl);

            if (success == true)
            {
                MessageBox.Show("Product Deleted Succcessfully");
                DataTable dt = dl.select();
                dataGridView1.DataSource = dt;
            }
            else
            {

                MessageBox.Show("Failed to delete user");


            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        CatDAL dll = new CatDAL();
        private void Product_Load(object sender, EventArgs e)
        {
            DataTable dt = dl.select();
            dataGridView1.DataSource = dt;
            DataTable categoriesDt = dll.select();

            txt_categories.DataSource = categoriesDt;
            txt_categories.DisplayMember = "tite";
            txt_categories.ValueMember = "tite";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = e.RowIndex;

            txt_productID.Text = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();
            txt_Name.Text = dataGridView1.Rows[rowindex].Cells[1].Value.ToString();
            txt_categories.Text = dataGridView1.Rows[rowindex].Cells[2].Value.ToString();
            txt_description.Text = dataGridView1.Rows[rowindex].Cells[3].Value.ToString();
            txt_rate.Text = dataGridView1.Rows[rowindex].Cells[4].Value.ToString();
        }
    }
}
