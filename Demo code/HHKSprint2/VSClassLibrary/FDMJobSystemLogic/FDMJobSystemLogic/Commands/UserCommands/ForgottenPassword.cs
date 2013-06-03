using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Outlook = Microsoft.Office.Interop.Outlook;



namespace FDMJobSystemLogic
{
    public class ForgottenPassword
    {
        private string Read(string username)
        {
            FindUser user = new FindUser();
            string password = "";
            if (user.GetUserByUsername(username).Username == username)
            {
                string cmdString = "SELECT password FROM FDMUser WHERE FDMUSER.Username = '" + username + "'";
                IReadOneCommand cmd = new ReadOneCommand();
                password = cmd.Execute(cmdString).ToString();
            }
            return password;
        }

        public bool EmailPassword(string username)
        {
            try
            {
                DbEmail mail = new DbEmail();
                mail.Sender = "hinnah.sarwar@fdmgroup.com";
                mail.Recipient = username + "@fdmgroup.com";
                mail.Subject = " your password";
                mail.Body = "Dear " + username + "! Your password is : " +Read(username) +
                            " Thank you!";

                SendComInteropEmail sendMail = new SendComInteropEmail();
                sendMail.SendMail(mail);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

    }
}
