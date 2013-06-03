using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Adminidtrator.ServiceReference1;

namespace Adminidtrator
{
    public class PopulateUser
    {
        //private Guid sessionId;
        IJSService client = new JSServiceClient();
        public List<DbUser> GetUserList(AddUser userDetails)
        {
           // Home home = new Home(sessionId);
            //GetUser checkUserName = new GetUser();
            int num = client.GetNumOfUsers(userDetails.firstnameTxtbox.Text,
                                        userDetails.lastnameTxtbox.Text);
            DbUser user = new DbUser();
            if (num < 1)
            {
                user.Username = userDetails.firstnameTxtbox.Text + "." + userDetails.lastnameTxtbox.Text;
            }
            else
            {
                user.Username = userDetails.firstnameTxtbox.Text + "." +
                    userDetails.lastnameTxtbox.Text + num;
            }
            user.Password = "password";
            user.FirstName = userDetails.firstnameTxtbox.Text;
            user.LastName = userDetails.lastnameTxtbox.Text;
            user.Email = user.Username + "@fdmgroup.com";
            user.Location = userDetails.locTxtbox.Text;
            user.TypeId = userDetails.userTypeCombox.SelectedIndex +1;


            List<DbUser> userList = new List<DbUser>();
            userList.Add(user);

            return userList.ToList();
        }
    }
}
