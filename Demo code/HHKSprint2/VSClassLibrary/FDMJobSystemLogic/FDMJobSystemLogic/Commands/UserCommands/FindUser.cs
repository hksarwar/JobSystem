using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace FDMJobSystemLogic
{
    public class FindUser : IReadCommandFactory<DbUser>, IReadSearchFactory<string>
    {

        List<DbUser> users = new List<DbUser>();
        List<string> usernames = new List<string>();

        public List<DbUser> Execute(string username)
        {
            string cmdString = "select FDMUSER.User_id, FDMUser.FirstName, FDMUser.LastName, FDMUser.Location, FDMUser.Email from FDMUser WHERE lower(FDMUser.Username) =lower('" +
                                    username + "')";
            List<DbUser> users2 = new List<DbUser>();
            try
            {
                IReadCommand cmd = new ReadCommand();
                DataTable dt = cmd.Execute(cmdString);
                Console.WriteLine(dt.Rows.Count);
                users2 = (from DataRow row in dt.Rows

                         select new DbUser
                         {
                             UserId = int.Parse(row["USER_ID"].ToString()),
                             FirstName = row["FIRSTNAME"].ToString(),
                             LastName = row["LASTNAME"].ToString(),
                             Email = row["EMAIL"].ToString(),
                             Location = row["LOCATION"].ToString()
                         }).ToList();
                users2[0].Username = username;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return users2;
        }

        public List<DbUser> Execute(DbUser user)
        {
            string cmdString = "select FDMUser.User_id, FDMUser.username, FDMUser.FirstName, FDMUser.LastName, FDMUser.Location, FDMUser.Email from FDMUser WHERE FDMUser.Type_id =" + user.TypeId;
            IReadCommand cmd = new ReadCommand();
            DataTable dt = cmd.Execute(cmdString);

            users = (from DataRow row in dt.Rows

                     select new DbUser
                     {
                         UserId = int.Parse(row["USER_ID"].ToString()),
                         FirstName = row["FIRSTNAME"].ToString(),
                         LastName = row["LASTNAME"].ToString(),   
                         Email = row["EMAIL"].ToString(),
                         Location = row["LOCATION"].ToString(),
                         Username = row["USERNAME"].ToString()
                     }).ToList();
            return users;
        }
        //public List<DbUser> Execute(DbUser user)
        //{
        //    string cmdString = "select FDMUser.username, FDMUser.Location, FDM.Email from FDMUser WHERE FDMUser.FirstName ='" +
        //                            user.FirstName + "' AND FDMUser.LastName = '" + user.LastName + "'";
        //    IReadCommand cmd = new ReadCommand();
        //    DataTable dt = cmd.Execute(cmdString);

        //    users = (from DataRow row in dt.Rows

        //             select new DbUser
        //             {
        //                 Email = row["EMAIL"].ToString(),
        //                 Location = row["LOCATION"].ToString(),
        //                 Username = row["USERNAME"].ToString()

        //             }).ToList();
        //    return users;
        //}


        public List<string> Execute()
        {
            string cmdString = "select FDMUser.username from FDMUser";
            IReadCommand cmd = new ReadCommand();
            DataTable dt = cmd.Execute(cmdString);
            usernames = (from row in dt.AsEnumerable() select Convert.ToString(row["USERNAME"])).ToList();
            return usernames;
        }

        public int NumOfUsers(string firstName, string lastName)
        {
            string cmdString = "select FDMUser.username FROM FDMUser WHERE lower(FDMUser.FirstName) = lower('" +
                                firstName.ToUpper() + "') AND lower(FDMUser.LastName) = lower('" +
                                lastName.ToUpper() + "')";
            IReadCommand cmd = new ReadCommand();
            DataTable dt = cmd.Execute(cmdString);
            usernames = (from row in dt.AsEnumerable() select Convert.ToString(row["USERNAME"])).ToList();
            return usernames.Count;
        }

        public bool UniqueUsername(string username)
        {
            usernames = Execute();
            for (int i = 0; i < usernames.Count; i++)
            {
                if (usernames[i].ToUpper() == username.ToUpper())
                {
                    return false;
                }
            }
            return true;
        }

        public DbUser GetUserByUsername(string username)
        {
            string cmdString = "select FDMUSER.user_id, FDMUSER.type_id FROM FDMUser WHERE lower(FDMUser.Username) = lower('" +
                                username + "')";
            IReadCommand cmd = new ReadCommand();
            DataTable dt = cmd.Execute(cmdString);
            users = (from DataRow row in dt.Rows

                     select new DbUser
                     {
                         UserId = int.Parse(row["USER_ID"].ToString()),
                         TypeId = int.Parse(row["TYPE_ID"].ToString())

                     }).ToList();
            users[0].Username = username;
            return users[0];
        }

        public string GetUsernameBySessionId(Guid sessionId)
        {
            string cmdString = "select FDMUser.Username FROM FDMUSER JOIN SESSIONS ON SESSIONS.User_id = FDMUser.User_id WHERE SESSIONS.Session_Guid = '" + sessionId + "'";
            IReadOneCommand readCmd = new ReadOneCommand();
            string username = readCmd.Execute(cmdString);
            return username;
        }

        public string GetUserIDBySessionId(Guid sessionId)
        {
            // Get user id  
            string qry = "SELECT FDMUSER.user_id FROM FDMUSER JOIN Sessions ON FDMUSER.user_id = Sessions.user_id WHERE Sessions.session_guid = '" + sessionId + "'";
            IReadOneCommand cmd = new ReadOneCommand();
            string id = cmd.Execute(qry);
            return id;
        }

        public List<DbUser> GetConsultants(string stream)
        {
            string qry;
            if (stream != "All")
            {
                qry = "SELECT FDMUSER.User_id, FDMUSER.username, FDMUSER.FirstName, FDMUSER.LastName, FDMUSER.Location, FDMUSER.Email FROM FDMUSER JOIN TYPE ON FDMUSER.type_id = TYPE.type_id JOIN PROFILE ON PROFILE.user_id = FDMUSER.user_id JOIN STREAM ON STREAM.stream_id = PROFILE.stream_id WHERE type.type_text = 'Consultant' AND STREAM.streamtext = '" + stream + "' ORDER BY fdmuser.lastname, fdmUser.firstname";
            }
            else
            {
                qry = "SELECT FDMUSER.User_id, FDMUSER.username, FDMUSER.FirstName, FDMUSER.LastName, FDMUSER.Location, FDMUSER.Email FROM FDMUSER JOIN TYPE ON FDMUSER.type_id = TYPE.type_id WHERE type_text = 'Consultant' ORDER BY fdmuser.lastname";
            
            }

            IReadCommand cmd = new ReadCommand();
            DataTable dt = cmd.Execute(qry);

            users = (from DataRow row in dt.Rows

                     select new DbUser
                     {
                         UserId = int.Parse(row["USER_ID"].ToString()),
                         Username = row["USERNAME"].ToString(),
                         FirstName = row["FIRSTNAME"].ToString(),
                         LastName = row["LASTNAME"].ToString(),
                         Location = row["LOCATION"].ToString(),
                         Email = row["EMAIL"].ToString()
                     }).ToList();
            return users;
        }
    }
}
