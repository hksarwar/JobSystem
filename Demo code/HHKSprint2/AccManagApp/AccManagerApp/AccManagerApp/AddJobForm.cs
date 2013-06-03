using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;
using FDMJobSystemLogic;

namespace AccManagerApp
{
    public partial class AddJobForm : Form
    {
        public AddJobForm()
        {
            InitializeComponent();
            PopulateTheComboBoxes();
        }

        private void StatLbl_Click(object sender, EventArgs e)
        {

        }

        private void PopulateTheComboBoxes()
        {
            IReadCommand cmd = new ReadCommand();
            string statusText = "SELECT STATUSTEXT FROM STATUS";
            StatusComBox.DataSource = cmd.Execute(statusText);

            string streamText = "SELECT STREAMTEXT FROM STREAM";
            StreamComBox.DataSource = cmd.Execute(streamText);
        }

        private void AddJobBtn_Click(object sender, EventArgs e)
        {
            if (DescriptionTxtbox.Text == "")
            {
                DesManLbl.Visible = true;
            }

            if (TitleTxtbox.Text == "")
            {
                TitManLbl.Visible = true;
            }

            if (CompanyTxtbox.Text == "")
            {
                ComManLbl.Visible = true;
            }
            if (CompanyTxtbox.Text == "")
            {
                LocManLbl.Visible = true;
            }
            else
            {
                string stream_id = (StreamComBox.SelectedIndex + 1).ToString();
                string status_id = (StatusComBox.SelectedIndex + 1).ToString();
                string description = DescriptionTxtbox.Text;
                string title = TitleTxtbox.Text;
                string deadline = DeadlinedatePicker1.Value.ToString();
                string company = CompanyTxtbox.Text;
                string location = LocTxtbox.Text;
                DesManLbl.Visible = false;
                TitManLbl.Visible = false;
                ComManLbl.Visible = false;
                LocManLbl.Visible = false;
                string addJobQry = "INSERT INTO JobPost (Job_id, User_id, Stream_id, Status_id, Description, " +
                                        "Title, DatePosted, Deadline, Company, Location) VALUES (job_id_seq.nextval, 6, " +
                                         stream_id + ", " + 
                                         status_id + ", " +
                                         description + ", " + 
                                         title + 
                                        ", SYSDATE, " +
                                         deadline + 
                                        ", " + company + ", " + 
                                        location;
                IWriteCommand cmd = new WriteCommand();
                if (cmd.Execute(addJobQry))
                {
                    DescriptionTxtbox.Text = "";
                    TitleTxtbox.Text = "";
                    CompanyTxtbox.Text = "";
                    CompanyTxtbox.Text = "";
                }
                else
                {
                    JobMsgLbl.Text = "Adding Job Failed.";
                    JobMsgLbl.ForeColor = Color.Red;
                }
                JobMsgLbl.Visible = true;
            }
        }
    }
}
