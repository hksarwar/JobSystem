using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConsultantJobPortal.ServiceReference1;

namespace ConsultantJobPortal
{
    public partial class SessionClear : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IJSService service = new JSServiceClient();
            Guid sessionId;
            sessionId = (Guid)HttpContext.Current.Session["sessionId"];
            service.Logout(sessionId);

            HttpContext.Current.Session.Remove("sessionId");
            HttpContext.Current.Session.Abandon();
        }
    }
}