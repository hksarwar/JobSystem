using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConsultantJobPortal.ServiceReference1;

namespace ConsultantJobPortal
{
    public partial class Login : System.Web.UI.Page
    {

        IJSService service = new JSServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            if ((txtUsername.Text != null) && (txtPassword.Text != null))
            {
                //Guid sessionId = service.Login2(txtUsername.Text, txtPassword.Text, "Trainee", "Consultant");
                Guid sessionId = service.Login(txtUsername.Text, txtPassword.Text, "Consultant");
                if (sessionId == Guid.Empty)
                {
                    FailureText.Text = "Login Failed, Username or Password incorrect";
                }
                else
                {
                    Session["sessionId"] = sessionId;
                    Session["username"] = txtUsername.Text;
                    List<DbUser> user = service.GetUserByUserName(Session["username"].ToString()).ToList();
                    Session["userid"] = user[0].UserId;
                    Response.Redirect("Default.aspx");
                }


            }
        }

        protected void btnForgotPwd_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "")
            {
                if (service.GetForgottenPassword(txtUsername.Text))
                {
                    FailureText.Text = "An email with your password is sent to " + txtUsername.Text + "@fdmgroup.com";
                }
                else
                {
                    FailureText.Text = "Failed to send the password to your email. Please check the username.";
                }
            }
            else
            {
                FailureText.Text = "Please enter a valid username";
            }
        }
    }
}