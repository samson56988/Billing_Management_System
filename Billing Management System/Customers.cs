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
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
        }
        CustomerDal dl = new CustomerDal();
        CustomerBll bl = new CustomerBll();
        UserDAL l = new UserDAL();
        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bl.Type = txt_TYPE.Text;
            bl.name = txt_Name.Text;
            bl.Email = txt_Email.Text;
            bl.Contact = txt_contact.Text;
            bl.Address = txt_address.Text;
            bl.added_date = DateTime.Now;

            string loggedUser = Login.loggein;
            usebll usr = l.GetIDFromUsername(loggedUser);
            bl.added_by = usr.id;

            bool success = dl.insert(bl);

            if (success == true)
            {

                MessageBox.Show("Customer Successfully Added");



            }
            else
            {

                MessageBox.Show("Failed to add new Customer");
            }
            DataTable dt = dl.select();
            dataGridView1.DataSource = dt;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bl.id = Convert.ToInt32(CustpmerID.Text);
            bl.Type = txt_TYPE.Text;
            bl.name = txt_Name.Text;
            bl.Email = txt_Email.Text;
            bl.Contact = txt_contact.Text;
            bl.Address = txt_address.Text;
            bl.added_date = DateTime.Now;
            

            string loggedUser = Login.loggein;
            usebll usr = l.GetIDFromUsername(loggedUser);
            bl.added_by = usr.id;

              bool success = dl.update(bl);

            if (success == true)
            {

                MessageBox.Show("Customer Updated Successfully");



            }
            else
            {

                MessageBox.Show("Failed to Update Customer");
            }
            DataTable dt = dl.select();
            dataGridView1.DataSource = dt;
        

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            bl.id = Convert.ToInt32(CustpmerID.Text);
           

            bool success = dl.Delete(bl);

            if (success == true)
            {

                MessageBox.Show("Customer Deleted Successfully");



            }
            else
            {

                MessageBox.Show("Failed to Delete Customer");
            }
            DataTable dt = dl.select();
            dataGridView1.DataSource = dt;
        
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            DataTable dt = dl.select();
            dataGridView1.DataSource = dt;
        
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = e.RowIndex;

            CustpmerID.Text = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();
            txt_TYPE.Text = dataGridView1.Rows[rowindex].Cells[1].Value.ToString();
            txt_Name.Text = dataGridView1.Rows[rowindex].Cells[2].Value.ToString();
            txt_Email.Text = dataGridView1.Rows[rowindex].Cells[3].Value.ToString();
            txt_contact.Text = dataGridView1.Rows[rowindex].Cells[4].Value.ToString();
            txt_address.Text = dataGridView1.Rows[rowindex].Cells[5].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


            

        }
    }

