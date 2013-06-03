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
    public partial class ChangePwdForm : Form
    {
        Guid sessionId = Guid.NewGuid();
        IJSService service = new JSServiceClient();

        public ChangePwdForm(Guid sessionID)
        {
            InitializeComponent();
            sessionId = sessionID;
        }

        private void ForgottenPwdForm_Load(object sender, EventArgs e)
        {
            txtBoxNewPass.PasswordChar = '•';
            txtBoxConfirmPass.PasswordChar = '•';
            this.txtBoxConfirmPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDownHandler);
        }

        private void cancelBTN_Click(object sender, EventArgs e)
        {
            MainForm mForm = new MainForm(sessionId);
            mForm.Show();
            this.Close();
        }

        private void changePasswd()
        {
            if (txtBoxNewPass.Text == txtBoxConfirmPass.Text)
            {
                string username = service.FindUsernameBySessionId(sessionId);

                DbUser user = new DbUser();
                user.Username = username;
                user.Password = txtBoxNewPass.Text;
                if (service.UpdatePassword(user))
                {
                    LoginForm form = new LoginForm();
                    form.txtUsername.Text = username;
                    form.ErrorLBL.Text = "Please Login with your new password";
                    form.ErrorLBL.ForeColor = Color.Green;
                    form.ErrorLBL.Show();
                    this.Hide();
                    form.Show();

                    service.Logout(sessionId);
                }
            }
            else
            {
                lbl.ForeColor = Color.Green;
                lbl.Text = "New Password do not match.";
            }

        }
        private void changePwdBTN_Click(object sender, EventArgs e)
        {
            changePasswd();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (txtBoxNewPass.Text != "" && txtBoxConfirmPass.Text != "")
                {
                    changePasswd();
                }
            }

        }
    }
}
