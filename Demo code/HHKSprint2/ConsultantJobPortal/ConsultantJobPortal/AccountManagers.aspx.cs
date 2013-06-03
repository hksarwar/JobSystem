using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConsultantJobPortal.ServiceReference1;

namespace ConsultantJobPortal
{
    public partial class About : System.Web.UI.Page
    {
        IJSService service = new JSServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            DbUser user = new DbUser();
            user.TypeId = 1;

            gvAccMan.DataSource = from f in service.FindUser(user)
                                  select new
                                  {
                                      f.FirstName,
                                      f.LastName,
                                      f.Email,
                                      f.Location
                                  };
            gvAccMan.DataBind();
        }

        protected void gvAccMan_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Email")
            {
                // retrive the index of the selected row
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvAccMan.Rows[index];
                //get the email address
                string email = row.Cells[3].Text;
                sendEmail(email);
            }
        }

        private void sendEmail(string email)
        {
            try
            {
                System.Diagnostics.Process.Start("mailto:" + email + "?subject=my%20subject&body=body%20of%20email ");
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
                Label1.Visible = true;
            }
        }
    }
}
