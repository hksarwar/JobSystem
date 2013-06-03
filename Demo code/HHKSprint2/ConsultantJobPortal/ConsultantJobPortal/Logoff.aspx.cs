using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConsultantJobPortal.ServiceReference1;

namespace ConsultantJobPortal
{
    public partial class Logout : System.Web.UI.Page
    {
        IJSService service = new JSServiceClient();
        Guid sessionId;

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore(); 
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            sessionId = (Guid)Session["sessionId"];
            service.Logout(sessionId);
            Response.Redirect("Login.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}