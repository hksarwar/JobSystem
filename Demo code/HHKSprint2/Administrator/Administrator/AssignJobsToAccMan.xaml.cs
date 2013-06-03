using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.Data;
using System.Collections.ObjectModel;
using System.Windows.Threading;


using Adminidtrator.ServiceReference1;

namespace Adminidtrator
{
    /// <summary>
    /// Interaction logic for AssignJobsToAccMan.xaml
    /// </summary>
    public partial class AssignJobsToAccMan : Window
    {
        private Guid sessionId;
        ObservableCollection<DbJob> _JobCollection =
                             new ObservableCollection<DbJob>();
        ObservableCollection<DbUser> _AMCollection =
                             new ObservableCollection<DbUser>();
        List<DbJob> jobList = new List<DbJob>();
        List<DbUser> users = new List<DbUser>();
        IJSService client = new JSServiceClient();
        AddUser form;
        string username;

        public AssignJobsToAccMan(Guid session_Id, List<DbJob> jobs)
        {
            InitializeComponent();
            this.sessionId = session_Id;
            this.jobList = jobs;
        }

        public void setUsername(string username)
        {
            this.username = username;
        }

        public void setAdminAppForm(AddUser form)
        {
            this.form = form;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillAmCollection();
            FillJobCollection();   
        }

        private void FillJobCollection()
        {
            jobList = client.CheckAccManagerJobExists(username);
            for (int i = 0; i < jobList.Count; i++)
            {
                DbJob job = jobList[i];
                _JobCollection.Add(new DbJob
                {
                    Location = job.Location.ToString(),
                    Company = job.Company.ToString(),
                    Title = job.Title.ToString(),
                    DatePosted = job.DatePosted
                });
            }

        }

        private void FillAmCollection()
        {
            DbUser findUser = new DbUser();
            findUser.Username = username;
            findUser.TypeId = 1;
            try
            {
                users = client.FindUser(findUser);
                if (users.Count > 0)
                {
                    for (int i = 0; i < users.Count; i++)
                    {
                        if (users[i].Username == username)
                        {
                            //i++;
                        }
                        else
                        {
                            DbUser user = users[i];
                            _AMCollection.Add(new DbUser
                            {
                                FirstName = user.FirstName,
                                LastName = user.LastName,
                                Username = user.Username,
                                Location = user.Location
                            });
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        public ObservableCollection<DbJob> JobCollection
        { get { return _JobCollection; } }


        public ObservableCollection<DbUser> AMCollection
        { get { return _AMCollection; } }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            form.Show();
        }

        private void assignBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AccManJobList.SelectedIndex != -1)
            {

                if (AvailAccManList.SelectedIndex != -1)
                {
                    DbJob selectedJob = (DbJob)AccManJobList.SelectedItem;
                    string jobTitle = selectedJob.Title;
                    string company = selectedJob.Company;
                    int jobId = 0;
                    int userId = 0;

                    DbUser selectedUser = (DbUser)AvailAccManList.SelectedItem;
                    string userName = selectedUser.FirstName.ToLower() + "." + selectedUser.LastName.ToLower();
                    for (int i = 0; i < jobList.Count; i++)
                    {
                        if (jobList[i].Title == jobTitle && jobList[i].Company == company)
                        {
                            jobId = jobList[i].JobId;
                           
                        }
                    }
                    for (int i = 0; i < users.Count; i++)
                    {
                        if (users[i].Username == userName)
                        {
                            userId = users[i].UserId;
                        }
                    }

                    DbJob updateJob = new DbJob();
                    updateJob.UserId = userId;
                    updateJob.JobId = jobId;
                    List<DbJob> jobUpdate = new List<DbJob>();
                    jobUpdate.Add(updateJob);
                    if (client.UpdateUserIdOfAJob(jobUpdate, 0))
                    {
                        errLbl.Content = "Job reassigned '" + jobTitle + "'";
                        errLbl.Foreground = new SolidColorBrush(Colors.Green);
                        errLbl.Visibility = Visibility.Visible;
                        _JobCollection.Remove((DbJob)AccManJobList.SelectedItem);
                        if (_JobCollection.Count == 0)
                        {
                            form.Show();
                            this.Close();
                            form.DeleteAccountManager();
                        }
                    }
                    else
                    {
                        errLbl.Content = "Failed to reassigned job '" + jobTitle + "' Please try again later.";
                        errLbl.Foreground = new SolidColorBrush(Colors.Red);
                    }
                }
                else
                {
                    errLbl.Content = "Please select an account manager";
                    errLbl.Foreground = new SolidColorBrush(Colors.Red);
                    errLbl.Visibility = Visibility.Visible;
                }
            }
            else
            {
                errLbl.Content = "Please select a job";
                errLbl.Foreground = new SolidColorBrush(Colors.Red);
                errLbl.Visibility = Visibility.Visible;
            }
        }
    }

    public static class ExtensionMethods
    {
        private static Action EmptyDelegate = delegate() { };


        public static void Refresh(this UIElement uiElement)
        {
            uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
    }

}
