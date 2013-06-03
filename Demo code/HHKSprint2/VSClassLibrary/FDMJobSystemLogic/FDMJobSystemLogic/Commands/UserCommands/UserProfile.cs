using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace FDMJobSystemLogic
{
    public class UserProfile
    {
        public DbUser GetUserDetails(int userid)
        {
            // Get user details
            string qry2 = "SELECT FDMUSER.user_id, FDMUSER.firstname, FDMUSER.lastname, FDMUSER.email, FDMUSER.location, Profile.degree, Profile.modules, Profile.tstatus_id, profile.stream_id FROM FDMUSER JOIN Profile ON FDMUSER.user_id = profile.user_id WHERE FDMUSER.user_id = " + userid;
            IReadCommand cmd2 = new ReadCommand();
            DataTable dt = cmd2.Execute(qry2);

            List<DbUser> users = (from DataRow row in dt.Rows

                         select new DbUser
                         {
                             UserId = int.Parse(row["USER_ID"].ToString()),
                             FirstName = row["FIRSTNAME"].ToString(),
                             LastName = row["LASTNAME"].ToString(),
                             Email = row["EMAIL"].ToString(),
                             Location = row["LOCATION"].ToString(),
                             Degree = row["DEGREE"].ToString(),
                             Modules = row["MODULES"].ToString(),
                             TStatus = row["TSTATUS_ID"].ToString(),
                             Stream = row["STREAM_ID"].ToString()
                         }).ToList();

            
            //string tstatusId = (from row in dt.AsEnumerable() select Convert.ToString(row["TSTATUS_ID"])).ToString();
            //string streamId = (from row in dt.AsEnumerable() select Convert.ToString(row["STREAM_ID"])).ToString();

            // Get stream and tstatus text
            string qry3 = "SELECT streamtext FROM Stream WHERE stream_id = " + users[0].Stream;
            IReadOneCommand cmd3 = new ReadOneCommand();

            users[0].Stream = cmd3.Execute(qry3);

            // Get stream and tstatus text
            string qry4 = "SELECT tstatustext FROM Trainee_Status WHERE tstatus_id = " + users[0].TStatus;
            IReadOneCommand cmd4 = new ReadOneCommand();
            users[0].TStatus = cmd3.Execute(qry4);

            // Get userskills
            users[0].Skills = GetUserSkills(users[0].UserId);
            users[0].Name = users[0].FirstName + " " + users[0].LastName;
            return users[0];
        }
     
        public List<string> GetUserSkills(int userId)
        {
            string qry2 = "SELECT skilltext FROM skill s JOIN ( SELECT skill_id FROM userskill WHERE user_id = '" + userId + "')us ON s.skill_id = us.skill_id";
            IReadCommand cmd2 = new ReadCommand();
            DataTable dt = cmd2.Execute(qry2);
            List<string> skills = new List<string>();

            skills = (from row in dt.AsEnumerable() select Convert.ToString(row["SKILLTEXT"])).ToList();

            return skills;
        }
    }
}
