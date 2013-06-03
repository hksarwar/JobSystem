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


using Adminidtrator.ServiceReference1;

namespace Adminidtrator
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        #region Global variables

        private Guid sessionId;
        ObservableCollection<DbUser> _UserCollection =
        new ObservableCollection<DbUser>();
        List<DbJob> jobsList = new List<DbJob>();
        IJSService client = new JSServiceClient();
        string adminUsername;
        List<string> autoFillUserName;
        List<string> autoFillLoc;

        #endregion

        #region Constructor
        public AddUser(Guid session_Id)
        {
            InitializeComponent();
            this.sessionId = session_Id;
        }

        #endregion

        #region Properties

        public ObservableCollection<DbUser> UserCollection
        { get { return _UserCollection; } }
        #endregion

        #region Setting the layout
        public void SetAdminUsername(string AUname)
        {
            adminUsername = AUname;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            homeMsgLbl.Content = "WELCOME " + adminUsername.ToUpper();
            autoFillUserName = client.GetUserNamesForAutoFill();
            autoFillLoc = client.GetUserLocsForAutoFill();
            List<DbUser> userDetails = client.GetUserByUserName(adminUsername);
            enterFirstName.Content = userDetails[0].FirstName;
            enterLastName.Content = userDetails[0].LastName;
            enterEmail.Content = userDetails[0].Email;
            enterLocation.Content = userDetails[0].Location;

            FillComboBoxes fill = new FillComboBoxes();
            fill.FillUserType(this);
            fill.FillStream(this);
            userTypeCombox.SelectedIndex = 0;
            streamCombox.SelectedIndex = 0;
        }

        #endregion

        #region Logout functionality
        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to Logout?", "Logout",
                                                       MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                client.Logout(sessionId);
                this.Close();
            }
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            client.Logout(sessionId);
            Application.Current.Shutdown();
        }

        #endregion

        #region Add user functionality
        private void addUserBtn_Click(object sender, RoutedEventArgs e)
        {
            if (checkDetailsAddTab() == "")
            {
                InfoLbl.Visibility = Visibility.Hidden;
                PopulateUser populate = new PopulateUser();
                List<DbUser> userList = populate.GetUserList(this); 
                int streamId = 0;

                if (userList[0].TypeId == 2)
                {
                    streamId = streamCombox.SelectedIndex + 1;
                }

                if (client.InsertUser(userList, streamId))
                {
                    var result = MessageBox.Show("User " + userList[0].Username +
                        " has been added", "New User", MessageBoxButton.OK, MessageBoxImage.Information);
                    if (result == MessageBoxResult.OK)
                    {
                        clearAddUserDetails();
                        autoFillUserName.Add(userList[0].Username);
                    }
                }
                else
                {
                    MessageBox.Show("Adding user failed. Please try again", "New User",
                                                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                InfoLbl.Content = checkDetailsAddTab();
                InfoLbl.Visibility = Visibility.Visible;
            }
        }

        private string checkDetailsAddTab()
        {
            string msg = "";
            if (firstnameTxtbox.Text == "" || lastnameTxtbox.Text == "" || locTxtbox.Text == "")
            {
                msg = "Please make sure all the fields are completed";
            }
            return msg;
        }
        #endregion

        #region Cleaning up funtionality
        private void clearAddUserDetails()
        {
            firstnameTxtbox.Text = "";
            lastnameTxtbox.Text = "";
            locTxtbox.Text = "";
            InfoLbl.Content = "";
            InfoLbl.Visibility = Visibility.Hidden;
            userTypeCombox.SelectedIndex = 0;
        }

        private void clearDeleteUserDetails()
        {
            delUNameTxtbox.Text = "";
            delUErrorLbl.Content = "";
            delUErrorLbl.Visibility = Visibility.Hidden;
        }

        private void tabControl1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                clearAddUserDetails();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                clearDeleteUserDetails();
            }
            else if (tabControl1.SelectedIndex == 0)
            {
                clearAddUserDetails();
                clearDeleteUserDetails();
            }
        }
        #endregion

        #region Find user functionality
        private void findUserBtn_Click(object sender, RoutedEventArgs e)
        {
            findUserBtnLogic();
        }

        private void findUserBtnLogic()
        {
            delUErrorLbl.Visibility = Visibility.Hidden;
            delUnameAutoFillLB.Visibility = Visibility.Collapsed;
            _UserCollection.Clear();
            if (delUNameTxtbox.Text == "")
            {
                delUErrorLbl.Content = "Please enter a username";
                delUErrorLbl.Foreground = new SolidColorBrush(Colors.Red);
                delUErrorLbl.Visibility = Visibility.Visible;
            }
            else{
            string username = delUNameTxtbox.Text;
            try
            {
                List<DbUser> users = client.GetUserByUserName(username);
                if (users.Count > 0)
                {
                    DbUser user = users[0];
                    _UserCollection.Add(new DbUser
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Username = user.Username,
                        Location = user.Location
                    });
                }
                else
                {
                    delUErrorLbl.Content = "User with username: " + username + " does not exist in the database";
                    delUErrorLbl.Foreground = new SolidColorBrush(Colors.Red);
                    delUErrorLbl.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
                delUErrorLbl.Content = "User with username: " + username + " does not exist in the database";
                delUErrorLbl.Foreground = new SolidColorBrush(Colors.Red);
                delUErrorLbl.Visibility = Visibility.Visible;
            }
          }
        }

        private void delUNameTxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                findUserBtnLogic();
            }
        }
        #endregion

        #region Delete user functionality
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
            if (delUNameTxtbox.Text == "")
            {
                delUErrorLbl.Content = "Please enter a username";
                delUErrorLbl.Foreground = new SolidColorBrush(Colors.Red);
                delUErrorLbl.Visibility = Visibility.Visible;
            }
            else if (findUserList.SelectedItem == null)
            {
                delUErrorLbl.Content = "Please select a user to delete";
                delUErrorLbl.Foreground = new SolidColorBrush(Colors.Red);
                delUErrorLbl.Visibility = Visibility.Visible;
            }
            else
            {
                delUErrorLbl.Visibility = Visibility.Hidden;
                DbUser selectedUser = (DbUser)findUserList.SelectedItem;
                string username = selectedUser.Username;

                if (jobExists(username))
                {
                    AssignJobsToAccMan jobs = new AssignJobsToAccMan(sessionId, jobsList);
                    jobs.setUsername(username);
                    jobs.setAdminAppForm(this);
                    this.Hide();
                    jobs.Show();
                }

                else if (username == adminUsername)
                {
                    delUErrorLbl.Content = "Sorry you cannot delete yourself. This action is not permitted";
                    delUErrorLbl.Foreground = new SolidColorBrush(Colors.Red);
                    delUErrorLbl.Visibility = Visibility.Visible;
                }
                else
                {
                    var result = MessageBox.Show("Are you sure you want to delete the selected user?", "Delete User",
                                                           MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        List<DbUser> users = new List<DbUser>();
                        selectedUser.Username = username;
                        users.Add(selectedUser);
                        if (client.DeleteUser(users))
                        {
                            _UserCollection.Clear();
                            autoFillUserName.Remove(username);
                           // delUErrorLbl.Content = tabControl1.SelectedIndex.ToString();
                            delUErrorLbl.Content = "User " + username + " has been deleted";
                            delUErrorLbl.Foreground = new SolidColorBrush(Colors.Green);

                            delUNameTxtbox.Text = "";
                            delUErrorLbl.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            delUErrorLbl.Content = "Failed to delete the user with username: " + username;
                            delUErrorLbl.Foreground = new SolidColorBrush(Colors.Red);
                            delUErrorLbl.Visibility = Visibility.Visible;
                        }
                    }
                }
            }
        }


        private bool jobExists(string username)
        {
            jobsList = client.CheckAccManagerJobExists(username);
            if (jobsList.Count > 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region user type and stream comboBoxes functionality
        private void userTypeCombox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (userTypeCombox.SelectedValue.ToString() == "Consultant")
            {
                streamLbl.Visibility = Visibility.Visible;
                streamCombox.Visibility = Visibility.Visible;
            }
            else
            {
                streamLbl.Visibility = Visibility.Hidden;
                streamCombox.Visibility = Visibility.Hidden;
            }
        }
        #endregion

        #region Autofill username functionality
        private void delUnameAutoFillLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (delUnameAutoFillLB.ItemsSource != null)
            {
                delUnameAutoFillLB.Visibility = Visibility.Collapsed;
                delUNameTxtbox.TextChanged -= new TextChangedEventHandler(delUNameTxtbox_TextChanged);
                if (delUnameAutoFillLB.SelectedIndex != -1)
                {
                    delUNameTxtbox.Text = delUnameAutoFillLB.SelectedItem.ToString();
                }
                delUNameTxtbox.TextChanged += new TextChangedEventHandler(delUNameTxtbox_TextChanged);
            }

        }

        private void delUNameTxtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            delUErrorLbl.Visibility = Visibility.Hidden;
            string typedstring = delUNameTxtbox.Text;
            List<string> autoList = new List<string>();
            autoList.Clear();

            foreach (string name in autoFillUserName)
            {
                if (!string.IsNullOrEmpty(delUNameTxtbox.Text))
                {
                    if (name.StartsWith(typedstring))
                    {
                        autoList.Add(name);
                    }
                }
            }

            if (autoList.Count > 0)
            {
                delUnameAutoFillLB.ItemsSource = autoList;
                delUnameAutoFillLB.Visibility = Visibility.Visible;
            }

            else if (delUNameTxtbox.Text.Equals(""))
            {
                delUnameAutoFillLB.Visibility = Visibility.Collapsed;
                delUnameAutoFillLB.ItemsSource = null;
            }

            else
            {
                delUnameAutoFillLB.Visibility = Visibility.Collapsed;
                delUnameAutoFillLB.ItemsSource = null;
            }
        }
        #endregion

        #region Autofill location functionality
        private void locAutoFillLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (locAutoFillLB.ItemsSource != null)
            {
                locAutoFillLB.Visibility = Visibility.Collapsed;
                locTxtbox.TextChanged -= new TextChangedEventHandler(locTxtbox_TextChanged);
                if (locAutoFillLB.SelectedIndex != -1)
                {
                    locTxtbox.Text = locAutoFillLB.SelectedItem.ToString();
                }
                locTxtbox.TextChanged += new TextChangedEventHandler(locTxtbox_TextChanged);
            }

        }

        private void locTxtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string typedstring = locTxtbox.Text;
            List<string> autoList = new List<string>();
            autoList.Clear();

            foreach (string loc in autoFillLoc)
            {
                if (!string.IsNullOrEmpty(locTxtbox.Text))
                {
                    string strloc = loc.ToLower();
                    if (strloc.StartsWith(typedstring.ToLower()))
                    {
                        autoList.Add(loc);
                    }
                }
            }

            if (autoList.Count > 0)
            {
                locAutoFillLB.ItemsSource = autoList;
                locAutoFillLB.Visibility = Visibility.Visible;
            }

            else if (locTxtbox.Text.Equals(""))
            {
                locAutoFillLB.Visibility = Visibility.Collapsed;
                locAutoFillLB.ItemsSource = null;
            }

            else
            {
                locAutoFillLB.Visibility = Visibility.Collapsed;
                locAutoFillLB.ItemsSource = null;
            }
        }

        #endregion

        #region Delete account manager functionality
        public void DeleteAccountManager()
        {
            DbUser selectedUser = (DbUser)findUserList.SelectedItem;
            string username = selectedUser.Username;
            var result = MessageBox.Show("Job(s) successfully reassigned. Are you sure you want to delete "+ username +
                                                                            "?", "Delete User",
                                                           MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                List<DbUser> users = new List<DbUser>();
                
                //selectedUser.Username = username;
                users.Add(selectedUser);
                if (client.DeleteUser(users))
                {
                    _UserCollection.Clear();
                    autoFillUserName.Remove(username);
                    // delUErrorLbl.Content = tabControl1.SelectedIndex.ToString();
                    delUErrorLbl.Content = "User " + username + " has been deleted";
                    delUErrorLbl.Foreground = new SolidColorBrush(Colors.Green);

                    delUNameTxtbox.Text = "";
                    delUErrorLbl.Visibility = Visibility.Visible;
                }
                else
                {
                    delUErrorLbl.Content = "Failed to delete the user with username: " + username;
                    delUErrorLbl.Foreground = new SolidColorBrush(Colors.Red);
                    delUErrorLbl.Visibility = Visibility.Visible;
                }
            }
        }
        #endregion

        private void GridViewColumnHeader_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

    }
}
