using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace FDMJobSystemLogic
{
    public class LoginCommand : ILoginCommand
    {
        public Guid VerifyDetails(string username, string password, string type)
        {
            // Get the type_id of the application
            string type_id = GetAppType(type.ToLower());

            string qry = "SELECT user_id, username, password FROM FDMUser WHERE type_id = " + type_id;

            // Get list of usernames and passwords of relevant type of user
            IReadCommand cmd = new ReadCommand();
            List<DbUser> u = new List<DbUser>();


            DataTable dt = cmd.Execute(qry);

            u = (from DataRow row in dt.Rows

                     select new DbUser
                     {
                         UserId = (int)row["USER_ID"],
                         Username = row["USERNAME"].ToString(),
                         Password = row["PASSWORD"].ToString()

                     }).ToList();

            //Guid g = new Guid("{00000000 - 0000 - 0000 - 0000 - 000000000000}");

            // Compare inputs with usernames and passwords of users 
            for (int i = 1; i < u.Count(); i+=3)
            {
                // if the username matches, check the password
                if (username == u[i].ToString())
                {
                    // if the password matches as well - success
                    if (password == u[i+1].ToString())
                    {
                        ISessionControlCommand sessionControl = new SessionControlCommand();
                        return sessionControl.SessionStart(int.Parse(u[i].UserId.ToString()), int.Parse(type_id));
                    }
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
            string qry = "SELECT user_id, username, password FROM FDMUser WHERE type_id = " + type_id + " OR type_id = " + type_id2;
            IReadCommand cmd = new ReadCommand();

            List<DbUser> u = new List<DbUser>();


            DataTable dt = cmd.Execute(qry);

            u = (from DataRow row in dt.Rows

                 select new DbUser
                 {
                     UserId = (int)row["USER_ID"],
                     Username = row["USERNAME"].ToString(),
                     Password = row["PASSWORD"].ToString()

                 }).ToList();

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
                        return sessionControl.SessionStart(int.Parse(u[i].UserId.ToString()), int.Parse(type_id));
                    }
                }
            }
            return Guid.Empty;
        }


        public void TerminateSession(Guid sessionId)
        {
            ISessionControlCommand sessionControl = new SessionControlCommand();
            sessionControl.EndSession(sessionId);
        }

        public string GetAppType(string type)
        {
            // A method to get the id from the database from the type of application
            string qry = "SELECT type_id FROM Type WHERE type_text = " + type;
            IReadOneCommand cmd = new ReadOneCommand();
            string type_id = cmd.Execute(qry);
            return type_id;
        }
    }
}
