using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDMJobSystemLogic
{
    public class LoginCommand : ILoginCommand
    {
        public Guid VerifyDetails(string username, string password, string type)
        {
            // Get the type_id of the application
            int type_id = int.Parse(GetAppType(type));

            // Get userid from username and password
            string qry = "SELECT user_id FROM FDMUser WHERE username = '" + username + "' AND password = '" + password + "'";
            IReadOneCommand cmd = new ReadOneCommand();
            string u = cmd.Execute(qry);
            Console.WriteLine(u.Count());
            if (u != "")
            {
                string qry2 = "SELECT type_id FROM FDMUser WHERE user_id = " + u;
                IReadOneCommand cmd2 = new ReadOneCommand();
                string t = cmd.Execute(qry2);

                if (int.Parse(t) == type_id)
                {
                    ISessionControlCommand sessionControl = new SessionControlCommand();
                    return sessionControl.SessionStart(int.Parse(u), int.Parse(t));
                }
            }
                return Guid.Empty;
        }

        public Guid VerifyDetails(string username, string password, string consultant, string trainee)
        {
            // Get the type_id of part of the application
            string type_id = GetAppType(consultant);

            // Get the type_id of part of the application
            string type_id2 = GetAppType(trainee);

            // Get list of usernames and passwords of relevant type of user
            string qry = "SELECT user_id, username, password FROM FDMUser WHERE type_id = '" + type_id + "' OR type_id = '" + type_id2 + "'";
            IReadOneCommand cmd = new ReadOneCommand();
            string u = cmd.Execute(qry);

            // Compare inputs with usernames and passwords of users 
            for (int i = 1; i < u.Count(); i += 3)
            {
                // if the username matches, check the password
                if (username == u[i].ToString())
                {
                    // if the password matches as well - success
                    if (password == u[i + 1].ToString())
                    {
                        ISessionControlCommand sessionControl = new SessionControlCommand();
                        return sessionControl.SessionStart(int.Parse(u), int.Parse(type_id));
                    }
                }
            }
            return Guid.Empty;
        }


        public void TerminateSession(Guid sessionId)
        {
            Console.WriteLine(sessionId);
            ISessionControlCommand sessionControl = new SessionControlCommand();
            sessionControl.EndSession(sessionId);
        }

        public string GetAppType(string type)
        {
            // A method to get the type id from the database from the type of application
            string qry = "SELECT type_id FROM Type WHERE type_text = '" + type + "'";
            IReadOneCommand cmd = new ReadOneCommand();
            string type_id = cmd.Execute(qry);
            return type_id;
        }
    }
}
