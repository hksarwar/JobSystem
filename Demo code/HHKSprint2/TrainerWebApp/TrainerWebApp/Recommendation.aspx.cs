using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrainerWebApp.ServiceReference1;
using System.ComponentModel;

using System.Data;

namespace TrainerWebApp
{
    public partial class Recommendation : System.Web.UI.Page
    {
        public IJSService service = new JSServiceClient();
        List<DbRecommendation> recPeople;
        public string username = "";
        public int userId = 0;
        int jobId;
        DataTable dt;
        DataTable dt2;

        protected void Page_Load(object sender, EventArgs e)
        {
            username = (string)Session["username"];
            userId = int.Parse(Session["userid"].ToString());
            BindDataToGridView();
        }

        private void BindDataToGridView()
        {
            recPeople = service.RetreiveRecommendations(Guid.Parse((Session["sessionId"].ToString())));
            if (recPeople.Count > 0)
            {
                gvRecJobs.DataSource = from r in recPeople
                                          select new
                                          {
                                              r.JobTitle,
                                              r.Recommended,
                                              r.Reason 
                                          };
                gvRecJobs.DataBind();
            }
            else
            {
                lblMsg.Text = "No consultants recommended.";
                lblMsg.Visible = true;
            }
        }

        protected void gvRecJobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvRecJobs.SelectedRow;
            dt2 = ToDataTable<DbRecommendation>(recPeople.ToList());
            DataRow dRow = dt2.Rows[row.RowIndex];
            jobId = (int)dRow["JobId"];
            pnlSelectJob.Visible = true;
            DbJob job = service.GetOneJob(jobId);

            string accountManager = service.GetOneUser(job.UserId);

            //int rowCount = gvRecJobs.SelectedIndex;

            //lblStatus.Text = jobId.ToString();
            lblStatus.Text = job.Status;
            lblStream.Text = job.Stream;
            lblLocation.Text = job.Location;
            lblCompany.Text = job.Company;
            lblTitle.Text = job.Title;
            lblDescription.Text = job.Description;
            lblDateposted.Text = job.DatePosted.ToString();
            lblDeadline.Text = job.Deadline.ToString();
            lblAccMan.Text = accountManager;
            blSkills.DataSource = job.Skills;
            blSkills.DataBind();

            //lblMsg.Visible = false;
            pnlSelectJob.Visible = true;
            Session["jobId"] = jobId;

            lbtnAddComment.Visible = true;
            BindCommentData(jobId);

            if (service.ViewComments(jobId).ToList().Count == 0)
            {
                lblSuccess.Text = "There are currently no comments for this post";
                cmntTimer.Enabled = false;
            }
            cmntTimer.Enabled = true;
        }

        protected void HideBTN_Click(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            pnlSelectJob.Visible = false;
            lblStatus.Text = "";
            lblStream.Text = "";
            lblLocation.Text = "";
            lblCompany.Text = "";
            lblTitle.Text = "";
            lblDescription.Text = "";
            lblDateposted.Text = "";
            lblDeadline.Text = "";
            gvRecJobs.SelectedIndex = -1;
            cmntTimer.Enabled = false;
            lbtnAddComment.Visible = false;
            lblSuccess.Text = "";
            lblError.Text = "";
            dt = null;
            gvComments.DataSource = dt;
            gvComments.DataBind();
        }


        public void BindCommentData(int jobId)
        {
            dt = ToDataTable<DbComments>(service.ViewComments(jobId).ToList());
            dt.Columns.Remove("CommentId");
            dt.Columns.Remove("JobId");

            gvComments.DataSource = dt;
            gvComments.DataBind();

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //lblSuccess.Text = "";
            //lblSuccess.Text = jobId.ToString();
            jobId = int.Parse(Session["jobId"].ToString());
            Guid sessionId = (Guid)Session["sessionId"];
            if (service.AddComment(jobId, sessionId, txtComment.Text) == true)
            {
                lblSuccess.Text = "Your comment has been successfully added";
                lblError.Text = "";
                pnlAddCom.Visible = false;
                txtComment.Text = "";
                BindCommentData(jobId);
            }
            else
            {
                lblError.Text = "Something went wrong! Please try again";
                lblSuccess.Text = "";
            }
        }

        protected void lbtnAddComment_Click(object sender, EventArgs e)
        {
            lblSuccess.Text = "";
            lblSuccess.Text = "";
            pnlAddCom.Visible = true;
        }

        protected void cmntTimer_tick(object sender, EventArgs e)
        {
            jobId = int.Parse(Session["jobId"].ToString());
            BindCommentData(jobId);
        }

        protected void gvComments_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;
            jobId = int.Parse(Session["jobId"].ToString());
            dt = ToDataTable<DbComments>(service.ViewComments(jobId).ToList());
            DataRow dr = dt.Rows[rowIndex];
            int commentId = (int)dr["CommentId"];
            int userId = service.GetUserIdByCommentId(commentId);
            int userId2 = int.Parse(Session["userid"].ToString());
            if (userId != userId2)
            {
                lblError.Text = "You can only delete your own comments";
                lblSuccess.Text = "";
            }
            else
            {
                if (service.DeleteComment(commentId) == true)
                {
                    lblSuccess.Text = "Your comment has been successfully deleted";
                    lblError.Text = "";
                    BindCommentData(jobId);
                }
                else
                {
                    lblError.Text = "Something went wrong! Please try again";
                    lblSuccess.Text = "";
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            pnlAddCom.Visible = false;
            txtComment.Text = "";
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

        protected void gvComments_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    LinkButton lnkDetete = ((LinkButton)e.Row.Cells[3].Controls[0]);
                    if (lnkDetete != null)
                        lnkDetete.Attributes["onclick"] = "if(!confirm('Are you sure to delete this comment?'))return   false;";
                }
            }
        }
    }
}