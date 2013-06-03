using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AccountManagerApp.ServiceReference1;

using System.IO;
using System.Reflection;

namespace AccountManagerApp
{
    public partial class MainForm : Form
    {
        AutoCompleteStringCollection namesCollection =
        new AutoCompleteStringCollection();

        AutoCompleteStringCollection locCollection =
        new AutoCompleteStringCollection();

        #region Constructor
        IJSService service = new JSServiceClient();
        Guid sessionId = Guid.NewGuid();
        // Add job
        BindingList<string> selectedSkills = new BindingList<string>();
        BindingList<string> existingSkills = new BindingList<string>();

        List<DbJob> myFullJobsList = new List<DbJob>();
        List<DbComments> comments = new List<DbComments>();

        // Search consultant
        BindingList<string> searchSelectedSkills = new BindingList<string>();
        BindingList<string> searchExistingSkills = new BindingList<string>();
        List<DbUser> users = new List<DbUser>();

        string username;
        int jobId;
        DbJob editJob = new DbJob();

        public MainForm(Guid sessionID)
        {
            InitializeComponent();
            sessionId = sessionID;
            //this.DragDrop += new DragEventHandler(searchAddedSkillsLBX_DragDrop);
        }

        #endregion

        #region Add job
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Create the temp job
            DbJob job = new DbJob();

            // set the values
            job.Stream = streamCBX.SelectedValue.ToString();
            job.Status = statusCBX.SelectedValue.ToString();
            job.Description = descriptionBX.Text;
            job.Title = titleBX.Text;
            job.DatePosted = DateTime.Now;
            job.Deadline = datePickerDeadline.Value;
            job.Company = companyBX.Text;
            job.Location = locationBX.Text;

            List<string> skills = new List<string>();
            
            for (int k = 0; k < selectedSkills.Count(); k++)
            {
                skills.Add(selectedSkills[k].ToString());
            }
            
            // add the job to the system
            if (service.InsertJob(job, skills, sessionId))
            {
                descriptionBX.Text = "";
                titleBX.Text = "";
                companyBX.Text = "";
                locationBX.Text = "";
                addedSkillsLBX.DataSource = new List<string>();
                tabControl1.SelectedTab = homeTab;
                fillMyJobsDataGrid();
                
            }
            else
            {
                postedStatusLBL2.ForeColor = Color.Red;
                postedStatusLBL2.Text = "Job not posted";
                postedStatusLBL2.Visible = true;
                //for (int j = 0; j < skills.Count(); j++)
                //{
                //    postedStatusLBL2.Text += skills[j];
                //}
            }
        }

        private void addSkillBTN_Click(object sender, EventArgs e)
        {
            // add skill to database
            service.InsertSkill(txtOther.Text);

            // add formatted added skill to job skills
            string skill = service.FormatSkill(txtOther.Text);
            selectedSkills.Add(skill);

            // add skill to listbox
            addedSkillsLBX.DataSource = selectedSkills;
            addedSkillsLBX.Refresh();
            postedStatusLBL2.Text = addedSkillsLBX.Items.Count.ToString();
            txtOther.Text = "";
        }

        private void addJobSkillBTN_Click(object sender, EventArgs e)
        {
            // add selected skill to job skills
            selectedSkills.Add(existingSkillsLBX.SelectedItem.ToString());

            // remove selected skill from available skills
            existingSkills.Remove(existingSkillsLBX.SelectedItem.ToString());

            // add skill to listbox
            addedSkillsLBX.DataSource = selectedSkills;
            addedSkillsLBX.Refresh();

            // remove skill from listbox
            existingSkillsLBX.DataSource = existingSkills;
            //existingSkillsLBX.Refresh();
        }

        private void removeJobSkillBTN_Click(object sender, EventArgs e)
        {
            // add selected skill to available skills
            existingSkills.Add(addedSkillsLBX.SelectedItem.ToString());

            // remove selected skill from job skills
            selectedSkills.Remove(addedSkillsLBX.SelectedItem.ToString());

            // remove skill to listbox
            addedSkillsLBX.DataSource = selectedSkills;
            addedSkillsLBX.Refresh();

            // add skill from listbox
            existingSkillsLBX.DataSource = existingSkills;
            existingSkillsLBX.Refresh();
        }

        private void streamCBX_Options(object sender, EventArgs e)
        {
            streamCBX.DataSource = service.GetStreamList();
        }

        #endregion

        #region Search For Consultants

        private void searchAddBTN_Click(object sender, EventArgs e)
        {
            // add selected skill to job skills
            searchSelectedSkills.Add(searchExistingSkillsLBX.SelectedItem.ToString());

            // remove selected skill from available skills
            searchExistingSkills.Remove(searchExistingSkillsLBX.SelectedItem.ToString());

            // add skill to listbox
            searchAddedSkillsLBX.DataSource = searchSelectedSkills;
            searchAddedSkillsLBX.Refresh();

            // remove skill from listbox
            searchExistingSkillsLBX.DataSource = searchExistingSkills;
            //existingSkillsLBX.Refresh();
        }

        private void searchRemoveBTN_Click(object sender, EventArgs e)
        {
            // add selected skill to available skills
            searchExistingSkills.Add(searchAddedSkillsLBX.SelectedItem.ToString());

            // remove selected skill from job skills
            searchSelectedSkills.Remove(searchAddedSkillsLBX.SelectedItem.ToString());

            // remove skill to listbox
            searchAddedSkillsLBX.DataSource = searchSelectedSkills;
            searchAddedSkillsLBX.Refresh();

            // add skill from listbox
            searchExistingSkillsLBX.DataSource = searchExistingSkills;
            searchExistingSkillsLBX.Refresh();
        }

        public void GetUsers()
        {
            if (users.Count > 0)
            {
                users.Clear();
            }
            string stream = searchStreamBX.SelectedItem.ToString();
            string status = searchStatusBX.SelectedItem.ToString();
            List<string> searchSkills = new List<string>();

            //noConsultantsFoundTBX.Text = status;
            
            for (int k = 0; k < searchSelectedSkills.Count(); k++)
            {
                searchSkills.Add(searchSelectedSkills[k].ToString());
            }
            //noConsultantsFoundTBX.Text = success.Count().ToString();
            
            users = service.SearchForConsultants(stream, status, searchSkills);

            //noConsultantsFoundTBX.Text = users.Count().ToString();
            BindingList<string> searchUsers = new BindingList<string>();
            for (int i = 0; i < users.Count(); i++)
            {
                searchUsers.Add(users[i].Name);
            }
            searchUsersLBX.DataSource = searchUsers;

            noConsultantsFoundTBX.Text = searchUsers.Count().ToString() + " consultant(s) found";
            searchUsersLBX.Visible = true;
            //// Display profile of selected user
            //for (int j = 0; j < users.Count(); j++)
            //{
            //    if (searchUsersLBX.SelectedItem.ToString() == users[j].Name)
            //    {
            //        service.GetProfile(users[j].UserId);
            //        nameTBX.Text = users[j].Name;
            //        degreeTBX.Text = users[j].Degree;
            //        modulesTBX.Text = users[j].Modules;
            //        locationTBX.Text = users[j].Location;
            //        statusTBX.Text = users[j].TStatus;
            //        streamTBX.Text = users[j].Stream;
            //        emailTBX.Text = users[j].Email;

            //        searchConsultantSkillsLBX.DataSource = users[j].Skills;
            //        profileGBX.Visible = true;
            //    }
            //}
        }

        private void startSearchBTN_Click(object sender, EventArgs e)
        {
            GetUsers();
        }

        private void searchAddNewSkillBTN_Click(object sender, EventArgs e)
        {
            // add skill to database
            service.InsertSkill(searchNewSkillTBX.Text);

            // add formatted added skill to job skills
            string skill = service.FormatSkill(searchNewSkillTBX.Text);
            searchSelectedSkills.Add(skill);

            // add skill to listbox
            searchAddedSkillsLBX.DataSource = searchSelectedSkills;
            searchAddedSkillsLBX.Refresh();
            searchNewSkillTBX.Text = "";
        }

        private void doneWithSearchBTN_Click(object sender, EventArgs e)
        {
            ClearSearch();
            tabControl1.SelectedTab = homeTab;
        }

        private void emailConsultantsBTN_Click(object sender, EventArgs e)
        {
            DbUser user = new DbUser();
            for (int j = 0; j < users.Count(); j++)
            {
                if (searchUsersLBX.SelectedItem.ToString() == users[j].Name)
                {
                    user = users[j];
                    break;
                }
            }

            DbUser thisUser = service.GetUserByUserName(username)[0];
            EmailForm eform = new EmailForm(sessionId, user.Email, thisUser.Email);
            eform.Show();
        }

        private void ClearSearch()
        {

        }

        #endregion

        #region Logoff
        private void btnLogOff_Click(object sender, EventArgs e)
        {
            LogoutForm logoff = new LogoutForm(sessionId);
            logoff.Show();
            this.Visible = false;
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {

            panelDescription.Visible = false;
            fillMyJobsDataGrid();
            username = service.FindUsernameBySessionId(sessionId);
            label14.Text += " "+username.ToUpper();
            //postedStatusLBL2.Text = "hello";
            existingSkills = new BindingList<string>(service.DisplaySkills());
            existingSkillsLBX.DataSource = existingSkills;
            
            // add job
            streamCBX.DataSource = service.GetStreams();
            statusCBX.DataSource = service.GetStatuses();
            datePickerDeadline.Value = DateTime.Today.AddDays(14);
            postedStatusLBL2.Visible = false;

            // search consultants
            searchUsersLBX.Visible = false;
            profileGBX.Visible = false;
            searchExistingSkills = new BindingList<string>(service.DisplaySkills());
            searchExistingSkillsLBX.DataSource = searchExistingSkills;
            searchStreamBX.DataSource = service.GetStreams();
            BindingList<string> statuses = new BindingList<string>();
            statuses.Add("All Available");
            List<string> status = service.GetTStatuses();
            for (int g = 0; g < status.Count(); g++)
            {
                statuses.Add(status[g]);
            }
            searchStatusBX.DataSource = statuses;
            searchExistingSkillsLBX.AllowDrop = true;
            searchAddedSkillsLBX.AllowDrop = true;
        }

        #region My Jobs
        public void fillMyJobsDataGrid()
        {
            myJobsGridView.Rows.Clear();
            // setting the properties of DataGrid
            myJobsGridView.RowTemplate.Height = 50;
            myJobsGridView.RowHeadersVisible = false;

            //filling the variables by the service method calls
            string username = service.FindUsernameBySessionId(sessionId);
            myFullJobsList = service.CheckAccManagerJobExists(username);

            //Setting the first cloumn of DataGrid to be a View column
            DataGridViewLinkColumn lbl = new DataGridViewLinkColumn();
            myJobsGridView.Columns.Add(lbl);
            lbl.HeaderText = "Select";
            lbl.Text = "select";
            lbl.Name = "lbl";
            lbl.UseColumnTextForLinkValue = true;

            //Setting the second column of DataGrid to be an Edit column
            DataGridViewLinkColumn editlbl = new DataGridViewLinkColumn();
            myJobsGridView.Columns.Add(editlbl);
            editlbl.HeaderText = "  Edit  ";
            editlbl.Text = "Edit";
            editlbl.Name = "editlbl";
            editlbl.UseColumnTextForLinkValue = true;

            //Setting the third column of the DataGrid to ba a delete column
            DataGridViewLinkColumn dellbl = new DataGridViewLinkColumn();
            myJobsGridView.Columns.Add(dellbl);
            dellbl.HeaderText = "Delete";
            dellbl.Text = "Delete";
            dellbl.Name = "dellbl";
            dellbl.UseColumnTextForLinkValue = true;

            //Setting rest of the five columns of DataGrid to display useful information
            myJobsGridView.ColumnCount = 8;
            myJobsGridView.Columns[3].Name = "Title";
            myJobsGridView.Columns[4].Name = "Company";
            myJobsGridView.Columns[5].Name = "Date Posted";
            myJobsGridView.Columns[6].Name = "Location";
            myJobsGridView.Columns[7].Name = "Status";

            //Filling the last five columns with the data from the databse
            string[] row = new string[] { };

            for (int j = 0; j < myFullJobsList.Count; j++)
            {
                row = new string[] {"", "", "", myFullJobsList[j].Title, myFullJobsList[j].Company,
                                            myFullJobsList[j].DatePosted.ToString(),
                                            myFullJobsList[j].Location, myFullJobsList[j].Status };
                myJobsGridView.Rows.Add(row);
                myJobsGridView.Columns[j].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                //Filling first column with a view image
                DataGridViewImageCell imgCell = new DataGridViewImageCell();
                string exeFile = (new System.Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
                string exeDir = Path.GetDirectoryName(exeFile);
                string fullPath = Path.Combine(exeDir, "..\\..\\Image\\view.bmp"); 
                imgCell.Value = Image.FromFile(fullPath);
                this.myJobsGridView[0, j] = imgCell;
                myJobsGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                //Filling second column with an edit image
                DataGridViewImageCell imgCell2 = new DataGridViewImageCell();
                string fullPath2 = Path.Combine(exeDir, "..\\..\\Image\\edit.bmp");
                imgCell2.Value = Image.FromFile(fullPath2);
                this.myJobsGridView[1, j] = imgCell2;
                myJobsGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                //Filling third column with a delete image
                DataGridViewImageCell imgCell3 = new DataGridViewImageCell();
                string fullPath3 = Path.Combine(exeDir, "..\\..\\Image\\delete.bmp");
                imgCell3.Value = Image.FromFile(fullPath3);
                this.myJobsGridView[2, j] = imgCell3;
                myJobsGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            }
            //Getting rid of the grid border
            myJobsGridView.BorderStyle = BorderStyle.None;
            myJobsGridView.DefaultCellStyle.SelectionBackColor = myJobsGridView.DefaultCellStyle.BackColor;
            myJobsGridView.DefaultCellStyle.SelectionForeColor = myJobsGridView.DefaultCellStyle.ForeColor;
            
        }

        //This method is not used anywhere... Could be DELETED at the end if  required
        private void myJobsGridView_Manage_Size()
        {
            //for (int i = 0; i < myJobsGridView.Columns.Count; i++)
            //{
            //    //myJobsGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            //    //int colw = myJobsGridView.Columns[i].Width;
            //    myJobsGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    //myJobsGridView.Columns[i].Width = colw;
            //}


            int height = 0;
            foreach (DataGridViewRow row2 in myJobsGridView.Rows)
            {
                height += row2.Height;
            }
            height += myJobsGridView.ColumnHeadersHeight;

            int width = 0;
            foreach (DataGridViewColumn col in myJobsGridView.Columns)
            {
                width += col.Width;
            }
            width += myJobsGridView.RowHeadersWidth;

            myJobsGridView.ClientSize = new Size(width + 2, height + 2);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BindingList<string> skills = new BindingList<string>(); 
            string jobTitle = myJobsGridView.Rows[e.RowIndex].Cells["Title"].Value.ToString();

            //Checking if view is clicked
            if (e.ColumnIndex == 0)
            {
                //Hiding the editPanel and find the title of the job selected
                editPanel.Visible = false;
                hiddenLbl.Visible = false;

                //Finding all the information about the selected job and initialsing the correspondent txtBoxes
                for (int i = 0; i < myFullJobsList.Count; i++)
                {
                    if (jobTitle == myFullJobsList[i].Title)
                    {
                        skills = new BindingList<string>(service.GetJobSkills(myFullJobsList[i].JobId).ToList());
                        listViewSkills.DataSource = skills;

                        txtBoxStream.Text = myFullJobsList[i].Stream;
                        txtBoxStatus.Text = myFullJobsList[i].Status;
                        txtBoxLoc.Text = myFullJobsList[i].Location;
                        txtBoxDeadline.Text = myFullJobsList[i].Deadline.ToString();
                        txtBoxDatePosted.Text = myFullJobsList[i].DatePosted.ToString();
                        txtBoxDesc.Text = myFullJobsList[i].Description;
                        txtBoxCompany.Text = myFullJobsList[i].Company;
                        txtBoxTitle.Text = jobTitle;
                        jobId = myFullJobsList[i].JobId;
                    }
                }
                //show the description of selected job
                panelDescription.Visible = true;
                //MessageBox.Show((e.RowIndex + 1) + "  Row  " + (e.ColumnIndex + 1) + "  Column button clicked ");
            }

            //Otherwise Check if the selected column is edit column
            else if (e.ColumnIndex == 1)
            {
                panelDescription.Hide();
                hiddenLbl.Visible = false;
                for (int i = 0; i < myFullJobsList.Count; i++)
                {
                    if (jobTitle == myFullJobsList[i].Title)
                    {
                        skills = new BindingList<string>(service.GetJobSkills(myFullJobsList[i].JobId).ToList());
                        editSkillListBox.DataSource = skills;

                        streamComBox.DataSource = service.GetStreams();
                        streamComBox.SelectedItem = myFullJobsList[i].Stream;
                        statusComBox.DataSource = service.GetStatuses();
                        statusComBox.SelectedItem = myFullJobsList[i].Status;
                        editLocTxtBox.Text = myFullJobsList[i].Location;
                        editDPTxtBox.Text = myFullJobsList[i].Deadline.ToString();
                        txtBoxDatePosted.Text = myFullJobsList[i].DatePosted.ToString();
                        editDescTxtBox.Text = myFullJobsList[i].Description;
                        editCompTxtBox.Text = myFullJobsList[i].Company;
                        editTitleTxtBox.Text = jobTitle;
                        deadLinePicker.Value = myFullJobsList[i].Deadline;
                        editJob.JobId = myFullJobsList[i].JobId;
                        hiddenLbl.Text = jobTitle;
                    }
                }
                editPanel.Size = panelDescription.Size;
                editPanel.Location = panelDescription.Location;
                panelDescription.Visible = false;
                editPanel.Visible = true;
            }

            //Otherwise Check if the selected column is delete column
            else if (e.ColumnIndex == 2)
            {
                if (MessageBox.Show("Are you sure You want to delete this job?", "Confirm",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for (int i = 0; i < myFullJobsList.Count; i++)
                    {
                        if (jobTitle == myFullJobsList[i].Title)
                        {
                            DbJob job = new DbJob();
                            job.JobId = myFullJobsList[i].JobId;
                            List<DbJob> jobs = new List<DbJob>();
                            jobs.Add(job);
                            if (service.DeleteJob(jobs, 1))
                            {
                                editPanel.Hide();
                                panelDescription.Hide();
                                fillMyJobsDataGrid();
                                hiddenLbl.ForeColor = Color.Green;
                                hiddenLbl.Text = "Job successfully deleted. ";
                                hiddenLbl.Visible = true;
                            }
                            else
                            {
                                hiddenLbl.Text = "Job delete unsuccessful. ";
                                hiddenLbl.ForeColor = Color.Red;
                                hiddenLbl.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    // user clicked no
                }
            }
        }

        private void myJobsGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.myJobsGridView.Rows[e.RowIndex - 1].Cells[0].Value = null;
        }



        private void closeBtn_Click(object sender, EventArgs e)
        {
            //hidding the panel and cleaning up
            panelDescription.Visible = false;
            txtBoxStatus.Text = "";
            txtBoxStream.Text = "";
            txtBoxLoc.Text = "";
            txtBoxCompany.Text = "";
            txtBoxTitle.Text = "";
            txtBoxDesc.Text = "";
            txtBoxDatePosted.Text = "";
            txtBoxDeadline.Text = "";
        }

        #endregion

        #region Close Application

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            service.Logout(sessionId);
            Application.Exit();
        }

        private void editCloseBtn_Click(object sender, EventArgs e)
        {
            //hidding the edit panel and cleaning up
            editPanel.Visible = false;
            txtBoxStatus.Text = "";
            txtBoxStream.Text = "";
            txtBoxLoc.Text = "";
            txtBoxCompany.Text = "";
            txtBoxTitle.Text = "";
            txtBoxDesc.Text = "";
            txtBoxDatePosted.Text = "";
            txtBoxDeadline.Text = "";
        }

        #endregion

        #region Update Job
        private void updateBtn_Click(object sender, EventArgs e)
        {
            //testLbl.Text = hiddenLbl.Text;
            DbJob job = new DbJob();
            BindingList<string> skills = new BindingList<string>(); 
            for (int i = 0; i < myFullJobsList.Count; i++)
            {
                skills = new BindingList<string>(service.GetJobSkills(myFullJobsList[i].JobId).ToList());
                if (hiddenLbl.Text == myFullJobsList[i].Title)
                {
                    //skills = new BindingList<string>(service.GetJobSkills(myFullJobsList[i].JobId).ToList());
                    //listViewSkills.DataSource = skills;
                   
                    job.Stream = streamComBox.SelectedValue.ToString();
                    job.Status = statusComBox.SelectedValue.ToString();
                    job.Location = editLocTxtBox.Text;
                    job.Deadline = deadLinePicker.Value;
                    job.JobId = myFullJobsList[i].JobId;
                    job.Description = editDescTxtBox.Text;
                    job.Company = editCompTxtBox.Text;
                    job.Title = editTitleTxtBox.Text;
                }
            }

            List<DbJob> jobList = new List<DbJob>();
            jobList.Add(job);
            if (service.UpdateAMJob(jobList))
            {
                //fillMyJobsDataGrid();
                hiddenLbl.ForeColor = Color.Green;
                hiddenLbl.Text = "Job successfully update.";
                editPanel.Visible = false;
                hiddenLbl.Visible = true;
                myJobsGridView.Refresh();
               
            }
            else
            {
                hiddenLbl.Text = "Job update unsuccessful.";
                hiddenLbl.ForeColor = Color.Red;
                hiddenLbl.Visible = true;
            }
        }

        private void editSkillsBtn_Click(object sender, EventArgs e)
        {
            BindingList<string> skills = new BindingList<string>();
            foreach (string obj in editSkillListBox.Items)
            {
                skills.Add(obj);
            }
            EditSkillsForm editForm = new EditSkillsForm(skills);
            editForm.setJob(editJob);
            editForm.setForm(this);
            //hiddenLbl.Text = editJob.JobId.ToString();
            //hiddenLbl.Visible = true;
            editForm.Show();
        }

        #endregion

        #region Comments

        private void btnComments_Click(object sender, EventArgs e)
        {
            label46.Visible = false;
            tabControl1.SelectedTab = commentsTab;
            panel1.Visible = true;
            txtCommStatus.Text = txtBoxStatus.Text;
            txtComStream.Text = txtBoxStream.Text;
            txtComLocation.Text = txtBoxLoc.Text;
            txtComCompany.Text = txtBoxCompany.Text;
            txtComTitle.Text = txtBoxTitle.Text;
            txtComDescription.Text = txtBoxDesc.Text;
            txtComDPosted.Text = txtBoxDatePosted.Text;
            txtComDeadline.Text = txtBoxDeadline.Text;
            lbxComSkills.DataSource = listViewSkills.DataSource;
            timer1.Start();
            FilldgvComments();

        }

        public void FilldgvComments()
        {
            // set dgvComments up
            dgvComments.Rows.Clear();
            dgvComments.RowHeadersVisible = false;
            dgvComments.ColumnHeadersVisible = false;

            //set the first column of dgvComments to delete
            DataGridViewLinkColumn del = new DataGridViewLinkColumn();
            dgvComments.Columns.Add(del);
            del.Text = "Delete";
            del.Name = "del";
            del.UseColumnTextForLinkValue = true;

            //set the databound columns of dgvComments
            dgvComments.ColumnCount = 5;
            dgvComments.Columns[1].Name = "DateAdded";
            dgvComments.Columns[2].Name = "Text";
            dgvComments.Columns[3].Name = "Username";
            dgvComments.Columns[4].Name = "Comment Id";

            dgvComments.Columns[4].Visible = false;

            //Fill list with comments then bind to rows of dgvComments
            comments = service.ViewComments(jobId);
            string[] row = new string[] { };

            for (int i = 0; i < comments.Count; i++ )
            {
                row = new string[] { "Delete", comments[i].DateAdded.ToString(), comments[i].Text, comments[i].Username, comments[i].CommentId.ToString()};
                dgvComments.Rows.Add(row);
                // allow text wrapping for comment text
                dgvComments.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvComments.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvComments.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }

            dgvComments.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvComments.BorderStyle = BorderStyle.None;
            dgvComments.AllowUserToAddRows = false;
            dgvComments.Columns[2].Width = 400;
            // set selection to same colour as background
            dgvComments.DefaultCellStyle.SelectionBackColor = dgvComments.DefaultCellStyle.BackColor;
            dgvComments.DefaultCellStyle.SelectionForeColor = dgvComments.DefaultCellStyle.ForeColor;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel2.Visible = true;
        }

        private void btnCancelCom_Click(object sender, EventArgs e)
        {
            txtComment.Text = "";
            lblMessage.Text = "";
            panel2.Visible = false;
        }

        private void btnAddCom_Click(object sender, EventArgs e)
        {
            service.AddComment(jobId, sessionId, txtComment.Text);
            FilldgvComments();
            txtComment.Text = "";
            lblMessage.Text = "You comment has been successfully added";
            panel2.Visible = false;
        }

        private void dgvComments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int commentId = int.Parse(dgvComments.Rows[e.RowIndex].Cells["Comment Id"].Value.ToString());
            int userId = service.GetUserIdByCommentId(commentId);
            DbUser user = service.GetUserByUserName(username)[0];
            int userId2 = user.UserId;

            if(e.ColumnIndex == 0)
            {
                if (userId == userId2)
                {
                    if (MessageBox.Show("Are you sure You want to delete this comment?", "Confirm",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (service.DeleteComment(commentId) == true)
                        {
                            lblMessage.Text = "Your comment has been successfully deleted";
                            FilldgvComments();
                        }
                        else
                        {
                            MessageBox.Show("Something went wrong, please try again", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            lblMessage.Text = "";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("You can only delete your own comments", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblMessage.Text = "";
                }
            }
        }

        private void lBtnBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectedTab = homeTab;
            lblMessage.Text = "";
            label46.Visible = true;
            txtCommStatus.Text = "";
            txtComStream.Text = "";
            txtComLocation.Text = "";
            txtComCompany.Text = "";
            txtComTitle.Text = "";
            txtComDescription.Text = "";
            txtComDPosted.Text = "";
            txtComDeadline.Text = "";
            lbxComSkills.DataSource = null;
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FilldgvComments();
        }

        #endregion

        private void btnChngPass_Click(object sender, EventArgs e)
        {
            ChangePwdForm chngPass = new ChangePwdForm(sessionId);
            this.Hide();
            chngPass.Show();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> dt = service.GetAvailableCompanyNames();
            List<string> locDt = service.GetAvailableLocNames();

            for (int i = 0; i <= dt.Count - 1; i++) 
            {
                namesCollection.Add(dt[i].ToString()); 
            }
            companyBX.AutoCompleteMode = AutoCompleteMode.Suggest;
            companyBX.AutoCompleteSource = AutoCompleteSource.CustomSource;
            companyBX.AutoCompleteCustomSource = namesCollection;



            for (int i = 0; i <= locDt.Count - 1; i++)
            {
                locCollection.Add(locDt[i].ToString());
            }
            locationBX.AutoCompleteMode = AutoCompleteMode.Suggest;
            locationBX.AutoCompleteSource = AutoCompleteSource.CustomSource;
            locationBX.AutoCompleteCustomSource = locCollection;
        }

        private void searchUsersLBX_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Display profile of selected user
            for (int j = 0; j < users.Count(); j++)
            {
                if (searchUsersLBX.SelectedItem.ToString() == users[j].Name)
                {
                    service.GetProfile(users[j].UserId);
                    nameTBX.Text = users[j].Name;
                    degreeTBX.Text = users[j].Degree;
                    modulesTBX.Text = users[j].Modules;
                    locationTBX.Text = users[j].Location;
                    statusTBX.Text = users[j].TStatus;
                    streamTBX.Text = users[j].Stream;
                    emailTBX.Text = users[j].Email;

                    searchConsultantSkillsLBX.DataSource = users[j].Skills;
                    profileGBX.Visible = true;
                }
            }
        }

    }
}
