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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        loginBll bl = new loginBll();
        LogDal dal = new LogDal();
      public  static string loggein;
        private void button1_Click(object sender, EventArgs e)
        {
            bl.username = txt_username.Text.Trim();
            bl.password = txt_password.Text.Trim();
            bl.Usertype = usertypecb.Text.Trim();


            bool success = dal.loginCheck(bl);

            if (success == true)
            {

                MessageBox.Show("Login Successful");
                loggein = bl.username;

                switch (bl.Usertype)
                { 
                
                    case "Admin":
                    {

                        Admin admin = new Admin();
                        admin.Show();
                        this.Hide();
                    
                    }
                    break;
                    case "User":
                    {
                        UserForm user = new UserForm();
                        user.Show();
                        this.Hide();

                    }
                    break;

                    default:
                    {

                        MessageBox.Show("Invalid Usertype");
                    }
                    break;


                }

            }
            else
            {

                MessageBox.Show("Login  Failed");
            
            }


        }
    }
}
