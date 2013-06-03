using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.ComponentModel;

using ConsultantJobPortal.ServiceReference1;

namespace ConsultantJobPortal
{
    public partial class Comments : System.Web.UI.Page
    {
        public IJSService service = new JSServiceClient();
        DbJob job;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {

            job = (DbJob)Session["Job"];
            lblStatus.Text = job.Status;
            lblStream.Text = job.Stream;
            lblLocation.Text = job.Location;
            lblCompany.Text = job.Company;
            lblTitle.Text = job.Title;
            lblDescription.Text = job.Description;
            lblDateposted.Text = job.DatePosted.ToString();
            lblDeadline.Text = job.Deadline.ToString();
            lblAccMan.Text = (string)Session["AccMan"];
            blSkills.DataSource = Session["Skills"];
            blSkills.DataBind();
            lblSuccess.Text = "";
            lblError.Text = "";

            dt = ToDataTable<DbComments>(service.ViewComments(job.JobId).ToList());
            dt.Columns.Remove("CommentId");
            dt.Columns.Remove("JobId");

            gvComments.DataSource = dt;
            gvComments.DataBind();

            if (service.ViewComments(job.JobId).ToList().Count == 0)
            {
                lblSuccess.Text = "There are currently no comments for this post";
            }

        }

        protected void cmntTimer_tick(object sender, EventArgs e)
        {
            dt = ToDataTable<DbComments>(service.ViewComments(job.JobId).ToList());
            dt.Columns.Remove("CommentId");
            dt.Columns.Remove("JobId");

            gvComments.DataSource = dt;
            gvComments.DataBind();

        }

        public DataTable ToDataTable<T>(List<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            lblSuccess.Text = "";
            pnlAddCom.Visible = true;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblSuccess.Text = "";
            job = (DbJob)Session["Job"];
            int jobId = job.JobId;
            Guid sessionId = (Guid)Session["sessionId"];
            if (service.AddComment(jobId, sessionId, txtComment.Text) == true)
            {
                lblSuccess.Text = "Your comment has been successfully added";
                lblError.Text = "";
                pnlAddCom.Visible = false;
                txtComment.Text = "";
                dt = ToDataTable<DbComments>(service.ViewComments(job.JobId).ToList());
                dt.Columns.Remove("CommentId");
                dt.Columns.Remove("JobId");

                gvComments.DataSource = dt;
                gvComments.DataBind();
            }
            else
            {
                lblError.Text = "Something went wrong! Please try again";
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            pnlAddCom.Visible = false;
            txtComment.Text = "";
        }

        protected void gvComments_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;
            job = (DbJob)Session["Job"];
            dt = ToDataTable<DbComments>(service.ViewComments(job.JobId).ToList());
            DataRow dr = dt.Rows[rowIndex];
            int commentId = (int)dr["CommentId"];
            int userId = service.GetUserIdByCommentId(commentId);
            int userId2 = int.Parse(Session["userid"].ToString());
            if (userId != userId2)
            {
                lblError.Text = "You can only delete your own comments";
            }
            else
            {
                if (service.DeleteComment(commentId) == true)
                {
                    lblSuccess.Text = "Your comment has been successfully deleted";
                    lblError.Text = "";
                    dt = ToDataTable<DbComments>(service.ViewComments(job.JobId).ToList());
                    dt.Columns.Remove("CommentId");
                    dt.Columns.Remove("JobId");

                    gvComments.DataSource = dt;
                    gvComments.DataBind();
                }
                else
                {
                    lblError.Text = "Something went wrong! Please try again";
                }
            }
        }
    }
}