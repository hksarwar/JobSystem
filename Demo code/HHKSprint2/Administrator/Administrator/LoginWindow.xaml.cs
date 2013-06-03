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
using System.Windows.Navigation;
using System.Windows.Shapes;

using Adminidtrator.ServiceReference1;

namespace Adminidtrator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        IJSService client = new JSServiceClient();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            loginLogin();            
        }

        private void loginLogin()
        {

            if ((usernameTxtbox.Text != null) && (passwordBox.Password != null))
            {
                Guid sessionId = client.Login(usernameTxtbox.Text, passwordBox.Password, "Administrator");
                if (sessionId == Guid.Empty)
                {
                    MessageBox.Show("Invalid login details. Please try again.", "Invalid Login",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    AddUser addUser = new AddUser(sessionId);
                    addUser.SetAdminUsername(usernameTxtbox.Text);
                    this.Hide();
                    addUser.Show();
                }
            }
        }

        private void cancleBtn_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to close the application?", "Close Application",
                                MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown(); // close the application
            }
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {

                if (usernameTxtbox.Text != "" && passwordBox.Password != "")
                {
                    loginLogin();
                }
            }
        }
    }
}
