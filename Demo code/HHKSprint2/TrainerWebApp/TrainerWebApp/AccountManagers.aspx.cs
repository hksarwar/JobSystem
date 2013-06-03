using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrainerWebApp.ServiceReference1;

using System.Reflection;     // to use Missing.Value 
using Microsoft.Office;
using Microsoft.Office.Core;
using System.Runtime.InteropServices;
using Outlook = Microsoft.Office.Interop.Outlook;




namespace TrainerWebApp
{
    public partial class AccountManagers : System.Web.UI.Page
    {
        public IJSService service = new JSServiceClient();
        DbUser user = new DbUser();

        protected void Page_Load(object sender, EventArgs e)
        {
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
            if(e.CommandName=="Email")
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
                System.Diagnostics.Process.Start("mailto:"+email+"?subject=my%20subject&body=body%20of%20email ");
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
                Label1.Visible = true;
            }
        }


    }
}