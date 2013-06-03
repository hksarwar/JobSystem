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
    public partial class LogoutForm : Form
    {
        IJSService service = new JSServiceClient();
        LoginForm login = new LoginForm();
        Guid sessionId;

        public LogoutForm(Guid sessionID)
        {
            InitializeComponent();
            sessionId = sessionID;
        }

        private void YesBTN_Click(object sender, EventArgs e)
        {
            service.Logout(sessionId);
            Application.Exit();
        }

        private void NoBTN_Click(object sender, EventArgs e)
        {
            MainForm home = new MainForm(sessionId);
            home.Show();
            this.Visible = false;
        }

        private void LogoutForm_Load(object sender, EventArgs e)
        {

        }

    }
}
