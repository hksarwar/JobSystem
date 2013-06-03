using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using AccountManagerApp.ServiceReference1;

namespace AccountManagerApp
{
    public partial class LoginForm : Form
    {
        IJSService service = new JSServiceClient();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '•';
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDownHandler);
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            loginLogin();
        }

        private void loginLogin()
        {
            Guid id = service.Login(txtUsername.Text, txtPassword.Text, "Account Manager");

            if (id == Guid.Empty)
            {
                //txtUsername.Text = "";
                txtPassword.Text = "";
                ErrorLBL.Text = "Invalid Username or Password ";
                ErrorLBL.ForeColor = Color.Red;
                ErrorLBL.Visible = true;
            }
            else
            {
                MainForm home = new MainForm(id);
                home.Show();
                this.Visible = false;
            }
        }

        //private void btnFPassword_Click(object sender, EventArgs e)
        //{
        //    if (service.GetForgottenPassword(txtUsername.Text))
        //    {
        //        ErrorLBL.Text = "Your password is sent to " + txtUsername.Text + "@fdmgroup.com";
        //        ErrorLBL.ForeColor = Color.Green;
        //        ErrorLBL.Show();
        //    }
        //    else
        //    {
        //        ErrorLBL.Text = "Failed to send an email please check the username";
        //        ErrorLBL.Show();
        //    }
        //}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (txtUsername.Text != "" && txtPassword.Text != "")
                {
                    loginLogin();
                }
            }

        }

        private void btnFPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (service.GetForgottenPassword(txtUsername.Text))
            {
                ErrorLBL.Text = "Password has been sent to your FDM email";
                ErrorLBL.ForeColor = Color.Green;
                ErrorLBL.Show();
            }
            else
            {
                ErrorLBL.Text = "Failed to send an email please check the username";
                ErrorLBL.Show();
            }
        }
    }
}
