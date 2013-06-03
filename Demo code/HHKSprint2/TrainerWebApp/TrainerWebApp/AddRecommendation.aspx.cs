using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using System.Windows.Forms; 

using TrainerWebApp.ServiceReference1;

namespace TrainerWebApp
{
    public partial class AddRecommendation : System.Web.UI.Page
    {
        public IJSService service = new JSServiceClient();
        List<string> autoCompleteTraineeName;
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        List<DbUser> availableConsultants = new List<DbUser>();
        BindingList<string> availableConsultantNames = new BindingList<string>();
        string stream;
        DbJob recJob;

        protected void Page_Load(object sender, EventArgs e)
        {
            recJob = (DbJob)Session["Job"];
            SelectTextLBL.Visible = false;
            SearchConsultantsRecLBX.Visible = false;
            ReasonLBL.Visible = false;
            ReasonTBX.Visible = false;
            //SearchTraineeTBX.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //SearchTraineeTBX.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //SearchTraineeTBX.AutoCompleteCustomSource = namesCollection; 
            selectedJobLBL.Text = recJob.Title + " at " + recJob.Company;
            if (!Page.IsPostBack)
            {

                streamFilterCBX.DataSource = service.GetStreams();
                streamFilterCBX.DataBind();
            }

        }

        public List<string> AutocompleteSuggestions(string username)
        {
            autoCompleteTraineeName = service.GetUserNamesForAutoFill();
            List<string> namelist = autoCompleteTraineeName.Where(n => n.ToLower().StartsWith(username.ToLower())).ToList();


            return namelist;
        }

        protected void InsertRecBTN_Click(object sender, EventArgs e)
        {
            DbJob recJob = (DbJob)Session["Job"];
            int recommender_id = int.Parse(Session["userid"].ToString());
            List<DbUser> recommendee = service.GetUserByUserName(SearchConsultantsRecLBX.SelectedValue);
            int recommendee_id = recommendee[0].UserId;
            service.AddRecommendation(recommender_id, recommendee_id, recJob.JobId, ReasonTBX.Text);
            Response.Redirect("Default.aspx");
        }

        protected void CancelRecBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void GetConsultantsBTN_Click(object sender, EventArgs e)
        {
            Session["Job"] = recJob;
            SelectTextLBL.Visible = true;
            availableConsultants = service.GetAvailableConsultants(stream);
            int c = availableConsultants.Count();
            for (int i = 0; i < availableConsultants.Count(); i++)
            {
                string username = availableConsultants[i].Username;
                availableConsultantNames.Add(username);
            }
            SearchConsultantsRecLBX.DataSource = availableConsultantNames;
            SearchConsultantsRecLBX.DataBind();
            SearchConsultantsRecLBX.Visible = true;

            SelectTextLBL.Visible = true;
            SearchConsultantsRecLBX.Visible = true;
            ReasonLBL.Visible = true;
            ReasonTBX.Visible = true;
        }

        protected void streamFilterCBX_SelectedIndexChanged(object sender, EventArgs e)
        {
            stream = streamFilterCBX.SelectedValue.ToString();
        }       
    }
}