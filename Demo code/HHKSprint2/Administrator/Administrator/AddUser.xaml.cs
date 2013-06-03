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

using Adminidtrator.ServiceReference1;

namespace Adminidtrator
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        private Guid sessionId;

        public AddUser(Guid session_Id)
        {
            InitializeComponent();
            this.sessionId = session_Id;
        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            IJSService client = new JSServiceClient();
            client.Logout(sessionId);
            this.Close();
            //LoginWindow login = new LoginWindow();
            ////login.usernameTxtbox.Text = sessionId.ToString();
            //login.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IJSService client = new JSServiceClient();
            FillComboBoxes fill = new FillComboBoxes();
            fill.FillUserType(this);
            fill.FillStream(this);
            userTypeCombox.SelectedIndex = 1;
            streamCombox.SelectedIndex = 1;
        }

        private void addUserBtn_Click(object sender, RoutedEventArgs e)
        {
            if (checkDetailsAddTab() == "")
            {
                IJSService client = new JSServiceClient();
                PopulateUser populate = new PopulateUser();
                List<DbUser> userList = populate.GetUserList(this);
                int streamId = streamCombox.SelectedIndex + 1;
                //firstnameTxtbox.Text = userList.ToString();

                if (client.InsertUser(userList, streamId))
                {
                    //ClearFields clear = new ClearFields();
                    //clear.ClearNewJob(this);
                    // dgRecentJobs.Items.Refresh();
                    MessageBox.Show("User " + userList[0].Username +
                        " has been added", "New User", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Adding User failed. Please fill all the fields", "NewUser",
                                                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                InfoLbl.Content = checkDetailsAddTab();
                InfoLbl.Visibility = Visibility.Visible;
            }
           // client.Close();
        }

        private string checkDetailsAddTab()
        {
            string msg = "";
            if (firstnameTxtbox.Text == "")
            {
                msg = "Please enter First Name field";
            }
            if(lastnameTxtbox.Text == "")
            {
                msg = "Please enter Last Name field";
            }
            if (locTxtbox.Text == "")
            {
                msg = "Please enter Location field";
            }
            return msg;
        }

        private void findUserBtn_Click(object sender, RoutedEventArgs e)
        {
            //IJSService client = new JSServiceClient();
            //string username =  delUNameTxtbox.Text;

            //DbUser user = client.GetUserByUserName(username);

            //findUserList.ItemsSource = client.FindUser(user);
        }

           public DbUser LoadImages()
           {
               IJSService client = new JSServiceClient();
               string username = delUNameTxtbox.Text;

               DbUser user = client.GetUserByUserName(username);

               findUserList.ItemsSource = client.FindUser(user);
            //List<BitmapImage> robotImages = new List<BitmapImage>();
            //DirectoryInfo robotImageDir = new DirectoryInfo( @"..\..\Robots" );
            //foreach( FileInfo robotImageFile in robotImageDir.GetFiles( "*.jpg" ) )
            //{
            //    Uri uri = new Uri( robotImageFile.FullName );
            //    robotImages.Add( new BitmapImage( uri ) );
            //}
            return user;
            }


    }
}
