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
    public partial class EmailForm : Form
    {
        IJSService service = new JSServiceClient();
        Guid sessionId = Guid.NewGuid();
        DbEmail email = new DbEmail();
        List<string> attachments;
        string user_Email;
        string sender_Email;

        public EmailForm(Guid sessionID, string userEmail, string senderEmail)
        {
            InitializeComponent();
            sessionId = sessionID;
            user_Email = userEmail;
            sender_Email = senderEmail;
        }

        private void sendEmailBTN_Click(object sender, EventArgs e)
        {
            // set up email
            email.Recipient = user_Email;
            email.Sender = sender_Email;
            email.Subject = subjectBX.Text;
            email.Body = bodyBX.Text;
            //email.Attachments = attachments;
            sendEmailBTN.Visible = false;

            if (service.SendUserEmail(email))
            {
                messageEmail.ForeColor = Color.Green;
                messageEmail.Text = "Email sucessfully sent";
                closeEmailBTN.Visible = true;
            }
            else
            {
                messageEmail.ForeColor = Color.Red;
                messageEmail.Text = "Email not sent";
                closeEmailBTN.Visible = true;
            }
        }

        private void EmailForm_Load(object sender, EventArgs e)
        {
            closeEmailBTN.Visible = false;
            messageEmail.Text = "";
            recipientLBL.Text = user_Email;
            senderLBL.Text = sender_Email;
        }

        private void closeEmailBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
