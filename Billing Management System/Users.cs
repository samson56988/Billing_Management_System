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
    public partial class Users : Form
    {

        
        public Users()
        {
            InitializeComponent();
        }

        usebll u = new usebll();
        UserDAL Dal = new UserDAL();

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            
            u.first_name = Txt_firtname.Text;
            u.last_name = txt_lastname.Text;
            u.email = txt_email.Text;
            u.username = txt_username.Text;
            u.password = txt_password.Text;
            u.Contact = txt_contact.Text;
            u.address = txt_Addrss.Text;
            u.gender = txt_Addrss.Text;
            u.gender = Gendercb.Text;
            u.user_type = Usertypecb.Text;
            u.added_date = DateTime.Now;
            

            string loggedUser = Login.loggein;
            usebll usr = Dal.GetIDFromUsername(loggedUser);
            u.addedby = usr.id;

            bool success = Dal.insert(u);

            if (success == true)
            {

                MessageBox.Show("User Successfully Added");
                clear();
                

            }
            else
            {

                MessageBox.Show("Failed to add new user");
            }
            DataTable dt = Dal.select();
            dataGridView1.DataSource = dt;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            u.id = Convert.ToInt32(txt_userID.Text);
            u.first_name = Txt_firtname.Text;
            u.last_name = txt_lastname.Text;
            u.email = txt_email.Text;
            u.username = txt_username.Text;
            u.password = txt_password.Text;
            u.Contact = txt_contact.Text;
            u.address = txt_Addrss.Text;
            u.gender = txt_Addrss.Text;
            u.gender = Gendercb.Text;
            u.user_type = Usertypecb.Text;
            u.added_date = DateTime.Now;
            

            bool success = Dal.update(u);

            if (success == true)
            {

                MessageBox.Show("User Updated Successfully");
                clear();


            }
            else
            {

                MessageBox.Show("Failed to Update user");
            }
            DataTable dt = Dal.select();
            dataGridView1.DataSource = dt;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            u.id = Convert.ToInt32(txt_userID.Text);

            bool success = Dal.Delete(u);

            if (success == true)
            {
                MessageBox.Show("User Deleted Succcessfully");
                    DataTable dt = Dal.select();
                   dataGridView1.DataSource = dt;
            }
            else
            {

                MessageBox.Show("Failed to delete user");
            
            
            }

        }

        private void Users_Load(object sender, EventArgs e)
        {
            DataTable dt = Dal.select();
            dataGridView1.DataSource = dt;
        }

        private void clear()
        {

            Txt_firtname.Text = "";
            txt_lastname.Text = "";
            txt_email.Text = "";
            txt_username.Text = "";
            txt_password.Text = "";
            txt_contact.Text = "";
            txt_Addrss.Text = "";
            txt_Addrss.Text = "";
            Gendercb.Text = "";
            Usertypecb.Text = "";
            comboBox1.Text = "";
        
        
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = e.RowIndex;
            txt_userID.Text = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();
            Txt_firtname.Text = dataGridView1.Rows[rowindex].Cells[1].Value.ToString();
            txt_lastname.Text = dataGridView1.Rows[rowindex].Cells[2].Value.ToString();
            txt_email.Text = dataGridView1.Rows[rowindex].Cells[3].Value.ToString();
            txt_username.Text = dataGridView1.Rows[rowindex].Cells[4].Value.ToString();
            txt_password.Text= dataGridView1.Rows[rowindex].Cells[5].Value.ToString();
            txt_contact.Text = dataGridView1.Rows[rowindex].Cells[6].Value.ToString();
            txt_Addrss.Text= dataGridView1.Rows[rowindex].Cells[7].Value.ToString();
            Gendercb.Text = dataGridView1.Rows[rowindex].Cells[8].Value.ToString();
            Usertypecb.Text = dataGridView1.Rows[rowindex].Cells[9].Value.ToString();


        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            string keywords = txt_search.Text;

            if (keywords != null)
            {

                DataTable dt = Dal.Search(keywords);
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
