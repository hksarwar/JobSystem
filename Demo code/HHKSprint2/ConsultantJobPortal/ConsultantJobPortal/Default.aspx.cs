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
    public partial class _Default : System.Web.UI.Page
    {
        public string username = "";
        public int userId = 0;
        public IJSService service = new JSServiceClient();
        DataTable dt;
        DataTable dt2;
        int jobId;

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            username = (string)Session["username"];
            userId = int.Parse(Session["userid"].ToString());
            string userStream = service.DetermineUserStream(userId);
            dt2 = ToDataTable<DbJob>(service.RecentJobs(userStream).ToList());
            
            dt2.Columns.Remove("UserId");
            dt2.Columns.Remove("JobId");
            dt2.Columns.Remove("Description");

            gvRecentJobs.DataSource = dt2;
            gvRecentJobs.DataBind();
        }


        #region GridView
        protected void gvRecentJobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvRecentJobs.SelectedRow;
            string userStream = service.DetermineUserStream(userId);
            dt2 = ToDataTable<DbJob>(service.RecentJobs(userStream));
            DataRow dRow = dt2.Rows[row.RowIndex];
            Session["jobId"] = (int)dRow["JobId"];
            jobId = int.Parse(Session["jobId"].ToString());
            pnlSelectJob.Visible = true;

            List<string> skills = new List<string>();
            skills = service.GetJobSkills(jobId).ToList();
            Session["Skills"] = skills;
            Session["AccMan"] = service.GetOneUser((int)dRow["UserId"]);

            int rowCount = gvRecentJobs.SelectedIndex;

            lblStatus.Text = row.Cells[6].Text;
            lblStream.Text = row.Cells[5].Text;
            lblLocation.Text = row.Cells[4].Text;
            lblCompany.Text = row.Cells[3].Text;
            lblTitle.Text = row.Cells[2].Text;
            lblDescription.Text = dRow["Description"].ToString();
            lblDateposted.Text = row.Cells[1].Text;
            lblDeadline.Text = row.Cells[7].Text;
            lblAccMan.Text = Session["AccMan"].ToString();
            blSkills.DataSource = Session["Skills"];
            blSkills.DataBind();


            lbtnAddComment.Visible = true;
            BindCommentData(jobId);

            if (service.ViewComments(jobId).ToList().Count == 0)
            {
                lblSuccess.Text = "There are currently no comments for this post";
            }
            cmntTimer.Enabled = true;
        }

        private string ConvertSortDirectionToSql(SortDirection sortDirection)
        {
            string newSortDirection = String.Empty;

            switch (sortDirection)
            {
                case SortDirection.Ascending:
                    newSortDirection = "ASC";
                    break;

                case SortDirection.Descending:
                    newSortDirection = "DESC";
                    break;
            }

            return newSortDirection;
        }

        protected void gvRecentJobs_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRecentJobs.PageIndex = e.NewPageIndex;
            gvRecentJobs.DataBind();
        }

        protected void gvRecentJobs_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dataTable = gvRecentJobs.DataSource as DataTable;

            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

                gvRecentJobs.DataSource = dataView;
                gvRecentJobs.DataBind();
            }
        }
        #endregion

        #region Description
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            pnlSelectJob.Visible = false;
            lblStatus.Text = "";
            lblStream.Text = "";
            lblLocation.Text = "";
            lblCompany.Text = "";
            lblTitle.Text = "";
            lblDescription.Text = "";
            lblDateposted.Text = "";
            lblDeadline.Text = "";
            gvRecentJobs.SelectedIndex = -1;
            cmntTimer.Enabled = false;
            lbtnAddComment.Visible = false;
            lblSuccess.Text = "";
            lblError.Text = "";
            dt = null;
            gvComments.DataSource = dt;
            gvComments.DataBind();
        }

        protected void LbtnFavs_Click(object sender, EventArgs e)
        {
            GridViewRow row = gvRecentJobs.SelectedRow;
            DbUser user = new DbUser();
            user.UserId = int.Parse(Session["userid"].ToString());

            List<DbUser> userList = new List<DbUser>();
            userList.Add(user);

            jobId = int.Parse(Session["jobId"].ToString());

            if (service.InsertFavourite(userList, jobId))
            {
                pnlSelectJob.Visible = false;
                lblStatus.Text = "";
                lblStream.Text = "";
                lblLocation.Text = "";
                lblCompany.Text = "";
                lblTitle.Text = "";
                lblDescription.Text = "";
                lblDateposted.Text = "";
                lblDeadline.Text = "";
                gvRecentJobs.SelectedIndex = -1;
                lblSuccess.Text = "This job has been successfully added to your favourites";
            }
            else
            {
                LbtnFavs.Visible = false;
                lblSuccess.Text = "Favourite already added";
            }
           
        }
        #endregion

        #region Comments

        public void BindCommentData(int jobId)
        {
            dt = ToDataTable<DbComments>(service.ViewComments(jobId).ToList());
            dt.Columns.Remove("CommentId");
            dt.Columns.Remove("JobId");

            gvComments.DataSource = dt;
            gvComments.DataBind();

        }

        protected void cmntTimer_tick(object sender, EventArgs e)
        {
            jobId = int.Parse(Session["jobId"].ToString());
            BindCommentData(jobId);

        }

        protected void lbtnAddComment_Click(object sender, EventArgs e)
        {
            lblSuccess.Text = "";
            lblSuccess.Text = "";
            pnlAddCom.Visible = true;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblSuccess.Text = "";
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            pnlAddCom.Visible = false;
            txtComment.Text = "";
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

        #endregion

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



        protected void filterByStreamLBX_SelectedIndexChanged(object sender, EventArgs e)
        {
            string userStream = service.DetermineUserStream(userId);
            dt2 = ToDataTable<DbJob>(service.RecentJobs(userStream).ToList());
            dt2.Columns.Remove("UserId");
            dt2.Columns.Remove("JobId");
            dt2.Columns.Remove("Description");

            gvRecentJobs.DataSource = dt2;
            gvRecentJobs.DataBind();
        }

        protected void GoBTN_Click(object sender, EventArgs e)
        {
            string userStream = service.DetermineUserStream(userId);
            dt2 = ToDataTable<DbJob>(service.RecentJobs(userStream).ToList());
            dt2.Columns.Remove("UserId");
            dt2.Columns.Remove("JobId");
            dt2.Columns.Remove("Description");

            gvRecentJobs.DataSource = dt2;
            gvRecentJobs.DataBind();
            //testLBL.Text = filterByStreamLBX.SelectedIndex.ToString();
        }


       
    }
}
