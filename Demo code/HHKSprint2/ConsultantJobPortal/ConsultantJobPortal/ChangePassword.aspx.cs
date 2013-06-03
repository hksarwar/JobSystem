using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConsultantJobPortal.ServiceReference1;

namespace ConsultantJobPortal
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        public string username = "";
        public int userId;
        public IJSService service = new JSServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            username = (string)Session["username"];
            userId = int.Parse(Session["userid"].ToString());
        }

        protected void btnChngPwd_Click(object sender, EventArgs e)
        {
            if (txtnewPasswd.Text == txtConfirmPasswd.Text)
            {
                DbUser user = new DbUser();
                user.Username = username;
                user.Password = txtnewPasswd.Text;
                if (service.UpdatePassword(user))
                {
                    Guid sessionId = (Guid)Session["sessionId"];
                    service.Logout(sessionId);
                    Response.Redirect("Login.aspx");
                }
            }
            else
            {
                FailureText.Text = "Passwords do not match";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}