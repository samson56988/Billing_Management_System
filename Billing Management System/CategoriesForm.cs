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
    public partial class CategoriesForm : Form
    {
        public CategoriesForm()
        {
            InitializeComponent();
        }

        CatDAL dl = new CatDAL();
        CategoryBLL bl = new CategoryBLL();
        usebll u = new usebll();
        UserDAL Dal = new UserDAL();

        private void btnAdd_Click(object sender, EventArgs e)
        {
          
            bl.Title = txt_title.Text;
            bl.Description = txt_description.Text;
            bl.Added_date = DateTime.Now;
            

            

            string loggedUser = Login.loggein;
            usebll usr = dl.GetIDFromUsername(loggedUser);
            bl.added_by = usr.id;

            bool success = dl.insert(bl);

            if (success == true)
            {

                MessageBox.Show("Category Successfully Added");
               
                

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
            bl.Id = Convert.ToInt32(txt_categoryID.Text);
            bl.Title = txt_title.Text;
            bl.Description = txt_description.Text;
            bl.Added_date = DateTime.Now;


            string loggedUser = Login.loggein;
            usebll usr = dl.GetIDFromUsername(loggedUser);
            bl.added_by = usr.id;

            bool success = dl.update(bl);

            if (success == true)
            {

                MessageBox.Show("User Updated Successfully");
                

            }
            else
            {

                MessageBox.Show("Failed to Update user");
            }
            DataTable dt = dl.select();
            dataGridView1.DataSource = dt;



        }

        private void CategoriesForm_Load(object sender, EventArgs e)
        {
            DataTable dt = dl.select();
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = e.RowIndex;

             txt_categoryID.Text = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();
            txt_title.Text = dataGridView1.Rows[rowindex].Cells[1].Value.ToString();
            txt_description.Text = dataGridView1.Rows[rowindex].Cells[2].Value.ToString();
        
        
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            bl.Id = Convert.ToInt32(txt_categoryID.Text);

            bool success = dl.Delete(bl);

            if (success == true)
            {
                MessageBox.Show("Catgory Deleted Succcessfully");
                    DataTable dt = dl.select();
                   dataGridView1.DataSource = dt;
            }
            else
            {

                MessageBox.Show("Failed to delete user");
            
            
            }

        
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            string keywords = txt_search.Text;

            if (keywords != null)
            {

                DataTable dt = dl.Search(keywords);
                dataGridView1.DataSource = dt;


            }

            else
            {

                DataTable dt = Dal.select();
                dataGridView1.DataSource = dt;

            }
        }
        }
    }

