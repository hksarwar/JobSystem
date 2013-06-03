using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

using ConsultantJobPortal.ServiceReference1;

namespace ConsultantJobPortal
{
    public partial class MyProfile : System.Web.UI.Page
    {
        DbUser user;
        string removeSelectedItem;
        string addedSelectedItem;
        int userId;
        IJSService service = new JSServiceClient();
        BindingList<string> userExistingSkills = new BindingList<string>();
        BindingList<string> dbExistingSkills = new BindingList<string>();

        List<string> deletedSkills = new List<string>();
        List<string> newlyAddedSkills = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore(); 

            Guid sessionId = (Guid)Session["sessionId"];
           // user = new DbUser();
            user = service.DisplayProfile(sessionId);

            //trap the selected item
            if (LBAddedSkills.SelectedIndex > -1)
            {
                removeSelectedItem = LBAddedSkills.SelectedItem.ToString();
            }

            if(LBExisitingSkills.SelectedIndex > -1)
            {
                addedSelectedItem = LBExisitingSkills.SelectedItem.ToString();
            }
            //refill the bidinglist

            //add the trapped item to the bindinglist
            #region Postback
            if (!Page.IsPostBack)
            {
                //newlyAddedSkills;
                //EditPanel.Visible = false;
                ViewProfilePanel.Visible = true;
                EditPanel.Visible = false;

                //Fill the View and Edit Profile labels and TextBox fields
                TxtBoxFname.Text = user.FirstName;
                VPFirstNameLbl.Text = user.FirstName;

                TxtBoxLName.Text = user.LastName;
                VPLastNameLbl.Text = user.LastName;

                TxtBoxEmail.Text = user.Email;
                VPEmailLbl.Text = user.Email;

                TxtBoxDegree.Text = user.Degree;
                VPPDegreeLbl.Text = user.Degree;

                TxtBoxLocation.Text = user.Location;
                VPLocLbl.Text = user.Location;

                TxtBoxModules.Text = user.Modules;
                VPModulesLbl.Text = user.Modules;

                //Fill the ComboBox for Status and Stream
                FillDropDownLists();
                CmbBoxStatus.SelectedValue = user.TStatus;
                VPStatusLbl.Text = user.TStatus;

                CmbBoxStream.SelectedValue = user.Stream;
                VpStreamLbl.Text = user.Stream;


                //Add theImage for the Consultant
                Add_Image();

                //Fill the user existing skills fields

                userId = int.Parse(Session["userid"].ToString());

                userExistingSkills = new BindingList<string>(service.GetUserSkills(userId));

                LBAddedSkills.DataSource = userExistingSkills;
                LBAddedSkills.DataBind();

                //Fill the List of available skills from the database
                dbExistingSkills = new BindingList<string>(service.DisplaySkills());

                //Get rid of the skills already added for the user
                for (int i = 0; i < dbExistingSkills.Count; i++)
                {
                    foreach (string j in userExistingSkills)
                    {
                        if (j == dbExistingSkills[i])
                        {
                            dbExistingSkills.RemoveAt(i);
                        }
                    }
                }
                LBExisitingSkills.DataSource = dbExistingSkills;
                LBExisitingSkills.DataBind();

            }

            #endregion

            userId = int.Parse(Session["userid"].ToString());
            userExistingSkills = new BindingList<string>(service.GetUserSkills(userId));
            VPSkillsLB.DataSource = userExistingSkills;
            VPSkillsLB.DataBind();
            Label14.Text = "";
            Label13.Text = "";

        }

        private void Add_Image()
        {
            if (user.Stream == "Dot Net" || user.Stream == "Java")
            {
                TraineeImg.ImageUrl = "~/Iamge/Developer.jpg";
            }
            else if (user.Stream == "Testing")
            {
                TraineeImg.ImageUrl = "~/Iamge/Tester.jpg";
            }
            else if (user.Stream == "Project Management Office")
            {
                TraineeImg.ImageUrl = "~/Iamge/PMO.jpg";
            }
            else if (user.Stream == "Infrastructure")
            {
                TraineeImg.ImageUrl = "~/Iamge/infrastructure.bmp";
            }
            else if (user.Stream == "Application Support")
            {
                TraineeImg.ImageUrl = "~/Iamge/AppSupport.jpg";
            }
            else
            {
                TraineeImg.ImageUrl = "~/Iamge/All.jpg";
            }
        }

        #region Update Profile
        protected void UpdateProfile_Click(object sender, EventArgs e)
        {
            DbUser user = new DbUser();
            user.UserId = int.Parse(Session["userid"].ToString());
            user.Username = TxtBoxFname.Text;
            user.LastName = TxtBoxLName.Text;
            user.Email = TxtBoxEmail.Text;
            user.Location = TxtBoxLocation.Text;
            VPLocLbl.Text = TxtBoxLocation.Text;
            user.Degree = TxtBoxDegree.Text;
            VPPDegreeLbl.Text = TxtBoxDegree.Text;
            user.Modules = TxtBoxModules.Text;
            VPModulesLbl.Text = TxtBoxModules.Text;
            user.Stream = CmbBoxStream.SelectedValue;
            VpStreamLbl.Text = CmbBoxStream.SelectedValue;
            user.TStatus = CmbBoxStatus.SelectedValue;
            VPStatusLbl.Text = CmbBoxStatus.SelectedValue;

            if (service.UpdateProfile(user))
            {
                Label13.Text = "Successfully updated Profile";
                Label14.Text = "";
                //Page_Load(sender, e);
                EditPanel.Visible = false;
                ViewProfilePanel.Visible = true;
            }
            else
            {
                Label14.Text = "Failed to update the profile";
                Label13.Text = "";
            }
        }

        public void FillDropDownLists()
        {
            List<string> status = new List<string>();
            status = service.GetTStatuses().ToList();
            for (int i = 0; i < status.Count(); i++)
            {
                CmbBoxStatus.Items.Add(status[i]);
            }

            List<string> streamList = new List<string>();
            streamList = service.GetStreams().ToList();
            for (int i = 0; i < streamList.Count(); i++)
            {
                CmbBoxStream.Items.Add(streamList[i]);
            }
            ListItem item = CmbBoxStream.Items[0];
            CmbBoxStream.Items.Remove(item);
        }

        #region Skills
        protected void BtnAddSkill_Click(object sender, EventArgs e)
        {
            //BtnAddSkill.Enabled = false;

            for (int i = LBExisitingSkills.Items.Count; --i >= 0; )
            {
                ListItem li = LBExisitingSkills.Items[i];

                if (li.Selected)
                {
                    ListItem liNew = new ListItem(li.Text, li.Value);
                    LBAddedSkills.Items.Add(liNew);
                    userExistingSkills.Add(li.Text);
                    //newlyAddedSkills.Add(li.Text);
                    LBExisitingSkills.Items.RemoveAt(i);
                    dbExistingSkills.Remove(li.Text);
                    LBAddedSkills.DataBind();
                    LBExisitingSkills.DataBind();
                    userId = int.Parse(Session["userid"].ToString());
                    if (!service.AddUserSkill(li.Text, userId))
                    {
                        lblError.Text = "Failed to add skill";
                    }

                    dbExistingSkills.Clear();
                    userExistingSkills.Clear();
                }
            }

        }

        protected void BtnRemoveSkill_Click(object sender, EventArgs e)
        {

            for (int j = LBAddedSkills.Items.Count; --j >= 0; )
            {
                ListItem li2 = LBAddedSkills.Items[j];

                if (li2.Selected)
                {
                    ListItem li2New = new ListItem(li2.Text, li2.Value);
                    LBExisitingSkills.Items.Add(li2New);
                    userExistingSkills.Remove(li2.Text);
                    LBAddedSkills.Items.RemoveAt(j);
                    dbExistingSkills.Add(li2.Text);
                    //deletedSkills.Add(li2.Text);
                    LBAddedSkills.DataBind();
                    LBExisitingSkills.DataBind();
                    int userId = int.Parse(Session["userid"].ToString());
                    if (!service.RemoveUserSkill(li2.Text, userId))
                    {
                        lblError.Text = "Failed to remove the skill";
                    }

                    dbExistingSkills.Clear();
                    userExistingSkills.Clear();
                }
            }

        }
        #endregion Skills

        protected void VPUpdateProfile_Click(object sender, EventArgs e)
        {
            ViewProfilePanel.Visible = false;
            EditPanel.Visible = true;
            userId = int.Parse(Session["userid"].ToString());
            userExistingSkills = new BindingList<string>(service.GetUserSkills(userId));
            VPSkillsLB.DataSource = userExistingSkills;
            VPSkillsLB.DataBind();
            Label14.Text = "";
            Label13.Text = "";
        }

        protected void CloseBtn_Click(object sender, EventArgs e)
        {
            EditPanel.Visible = false;
            ViewProfilePanel.Visible = true;
        }
        #endregion

    }
}