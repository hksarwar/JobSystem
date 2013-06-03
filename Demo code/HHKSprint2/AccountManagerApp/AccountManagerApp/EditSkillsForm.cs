using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AccountManagerApp.ServiceReference1;

namespace AccountManagerApp
{
    public partial class EditSkillsForm : Form
    {
        IJSService service = new JSServiceClient();
        BindingList<string> editSelectedSkills = new BindingList<string>();
        BindingList<string> editExistingSkills = new BindingList<string>();
        DbJob job = new DbJob();
        MainForm mForm;

        List<string> deletedSkills = new List<string>();
        List<string> newlyAddedSkills = new List<string>();
        //BindingList<string> jobSkills = new BindingList<string>();

        public EditSkillsForm(BindingList<string> skills)
        {
            InitializeComponent();
            editSelectedSkills = skills;
        }

        public void setJob(DbJob job)
        {
            this.job = job;
        }

        public void setForm(MainForm form)
        {
            this.mForm = form;
        }

        private void removeJobSkillBTN_Click(object sender, EventArgs e)
        {

        }

        private void addJobSkillBTN_Click(object sender, EventArgs e)
        {

        }

        private void addSkillBTN_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<string> skills = new List<string>();

            for (int k = 0; k < editSelectedSkills.Count(); k++)
            {
                skills.Add(editSelectedSkills[k].ToString());
            }
        }

        private void skillCloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditSkillsForm_Load(object sender, EventArgs e)
        {
            BindingList<string> jobSkills = new BindingList<string>();
            editExistingSkills = new BindingList<string>(service.DisplaySkills());
            jobSkillsLBX.DataSource = editSelectedSkills;
            for (int i = 0; i < editExistingSkills.Count; i++)
            {
                foreach (string j in editSelectedSkills)
                {
                    if (j == editExistingSkills[i])
                    {
                        editExistingSkills.Remove(j);
                    }
                }
            }
            DbSkillsLBX.DataSource = editExistingSkills;
        }

        private void addSkillsBtn_Click(object sender, EventArgs e)
        {
            // add selected skill to job skills
            editSelectedSkills.Add(DbSkillsLBX.SelectedItem.ToString());
            newlyAddedSkills.Add(DbSkillsLBX.SelectedItem.ToString());

            // remove selected skill from available skills
            editExistingSkills.Remove(DbSkillsLBX.SelectedItem.ToString());

            // add skill to listbox
            jobSkillsLBX.DataSource = editSelectedSkills;
            jobSkillsLBX.Refresh();

            // remove skill from listbox
            DbSkillsLBX.DataSource = editExistingSkills;
            //existingSkillsLBX.Refresh();
        }

        private void editAddSkillBTN_Click(object sender, EventArgs e)
        {
            // add skill to database
            service.InsertSkill(newSkilltxtBox.Text);

            // add formatted added skill to job skills
            string skill = service.FormatSkill(newSkilltxtBox.Text);
            editSelectedSkills.Add(skill);

            // add skill to listbox
            jobSkillsLBX.DataSource = editSelectedSkills;
            jobSkillsLBX.Refresh();
            //postedStatusLBL2.Text = jobSkillsLBX.Items.Count.ToString();
            newSkilltxtBox.Text = "";
        }

        private void removeSkillsBtn_Click(object sender, EventArgs e)
        {
            // add selected skill to available skills
            editExistingSkills.Add(jobSkillsLBX.SelectedItem.ToString());
            deletedSkills.Add(jobSkillsLBX.SelectedItem.ToString());
            // remove selected skill from job skills
            editSelectedSkills.Remove(jobSkillsLBX.SelectedItem.ToString());

            // remove skill to listbox
            jobSkillsLBX.DataSource = editSelectedSkills;
            jobSkillsLBX.Refresh();

            // add skill from listbox
            DbSkillsLBX.DataSource = editExistingSkills;
            DbSkillsLBX.Refresh();
        }

        private void skillUpdateBtn_Click(object sender, EventArgs e)
        {
            List<DbJob> jobs = new List<DbJob>();
            jobs.Add(job);

            if (deletedSkills.Count > 0)
            {
                if (service.UpdateDeletedJobSkill(jobs, deletedSkills))
                {
                    BindingList<string>  skills = new BindingList<string>(service.GetJobSkills(job.JobId).ToList());
                    mForm.editSkillListBox.DataSource = skills;
                    mForm.fillMyJobsDataGrid();
                    this.Close();
                }
            }
             if (newlyAddedSkills.Count > 0)
            {
                if (service.UpdateAddedJobSkill(jobs, newlyAddedSkills))
                {
                    BindingList<string> skills = new BindingList<string>(service.GetJobSkills(job.JobId).ToList());
                    mForm.editSkillListBox.DataSource = skills;
                    mForm.tabControl1.Refresh();
                    this.Close();
                }
            }
            else
            {
                editSkillErrorLbl.Text = "updating job skills failed.";
                editSkillErrorLbl.Visible = true;
            }
        }

        private void addedSkillsLBL_Click(object sender, EventArgs e)
        {

        }

        private void existingSkillsLBL_Click(object sender, EventArgs e)
        {

        }

        private void DbSkillsLBX_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void editSkillErrorLbl_Click(object sender, EventArgs e)
        {

        }

        private void jobSkillsLBX_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void otherLBL_Click(object sender, EventArgs e)
        {

        }

        private void newSkilltxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
