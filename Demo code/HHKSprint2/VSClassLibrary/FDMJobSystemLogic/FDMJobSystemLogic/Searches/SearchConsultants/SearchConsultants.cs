using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace FDMJobSystemLogic
{
    public class SearchConsultants : ISearch
    {
       public List<DbUser> Search(string stream, string status, List<string> skills)
        {
            List<string> sortedUsers = new List<string>();
            List<Tuple<string, int>> unsortedUsers = new List<Tuple<string, int>>();
            List<DbUser> finalUsers = new List<DbUser>();
            
            // search on: skills, stream, status
            // status = training, available, all available, placed

            // get all users with stream and status match
            string qry = GetQry(stream, status, skills);

            IReadCommand read = new ReadCommand();
            DataTable dt = read.Execute(qry);
            List<string> users = (from row in dt.AsEnumerable() select Convert.ToString(row["USER_ID"])).ToList();
            
            for (int k = 0; k < users.Count(); k++)
            {
                sortedUsers.Add(users[k]);
            }

            // match skills
            List<string> users2 = new List<string>();
            // check if skills are empty
            if (skills.Count > 0)
            {
                // if not: for each required skill
                for (int i = 0; i < skills.Count(); i++)
                {
                    // select all users that have skill
                    string qry2 = "SELECT FDMUSER.user_id FROM FDMUSER JOIN USERSKILL ON FDMUSER.user_id=USERSKILL.user_id JOIN Skill ON Skill.skill_id = USERSKILL.skill_id WHERE skilltext = '" + skills[i] + "'";
                    IReadCommand read2 = new ReadCommand();
                    DataTable dt2 = read.Execute(qry2);
                    List<string> users3 = (from row in dt.AsEnumerable() select Convert.ToString(row["USER_ID"])).ToList();
                    for (int j = 0; j < users3.Count(); j++)
                    {
                        users2.Add(users3[j]);
                    }
                    // return list of users
                }

                //count how often user appears in skills - how many of the relevant skills they have
                var groups = users2.GroupBy(v => v);
                foreach (var group in groups)
                {
                    Tuple<string, int> user = new Tuple<string, int>(group.Key, group.Count());
                    unsortedUsers.Add(user);
                }

                // sort unique users by skill count
                unsortedUsers.Sort((a, b) => a.Item2.CompareTo(b.Item2));

                for (int k = 0; k < unsortedUsers.Count(); k++)
                {
                    sortedUsers.Add(unsortedUsers[k].Item1.ToString());
                }

                IEnumerable<string> relevantUsers = sortedUsers.Intersect(users);

                foreach (var user in relevantUsers.ToList())
                {
                    UserProfile profile = new UserProfile();
                    DbUser userProfile = profile.GetUserDetails(int.Parse(user));
                    finalUsers.Add(userProfile);
                }
            }
            else
            {
                for (int i = 0; i < sortedUsers.Count(); i++)
                {
                    UserProfile profile = new UserProfile();
                    DbUser userProfile = profile.GetUserDetails(int.Parse(sortedUsers[i]));
                    finalUsers.Add(userProfile);
                }
            }
            return finalUsers;
        }

        public string GetQry(string stream, string status, List<string> skills)
        {
            string qry;
            if (stream != "All")
            {
                if (status != "All Available")
                {
                    qry = "SELECT FDMUSER.user_id FROM FDMUSER JOIN PROFILE ON FDMUSER.user_id = PROFILE.user_id JOIN STREAM ON PROFILE.stream_id = STREAM.stream_id JOIN TRAINEE_STATUS ON profile.tstatus_id = trainee_status.tstatus_id WHERE streamText = '" + stream + "' AND tstatustext = '" + status + "'";
                }
                else //not placed
                {
                    qry = "SELECT FDMUSER.user_id FROM FDMUSER JOIN PROFILE ON FDMUSER.user_id = PROFILE.user_id JOIN TRAINEE_STATUS ON profile.tstatus_id = trainee_status.tstatus_id WHERE trainee_status.tstatustext = 'Training' OR trainee_status.tstatustext = 'Available' INTERSECT SELECT FDMUSER.user_id FROM FDMUSER JOIN PROFILE ON FDMUSER.user_id = PROFILE.user_id JOIN STREAM ON PROFILE.stream_id = STREAM.stream_id WHERE streamText = '" + stream + "'";
                }
            }
            else
            {
                if (status != "All Available")
                {
                    qry = "SELECT FDMUSER.user_id FROM FDMUSER JOIN PROFILE ON FDMUSER.user_id = PROFILE.user_id JOIN TRAINEE_STATUS ON profile.tstatus_id = trainee_status.tstatus_id WHERE tstatustext = '" + status + "'";
                }
                else // not placed
                {
                    qry = "SELECT FDMUSER.user_id FROM FDMUSER JOIN PROFILE ON FDMUSER.user_id = PROFILE.user_id JOIN TRAINEE_STATUS ON profile.tstatus_id = trainee_status.tstatus_id WHERE tstatustext = 'Available' OR tstatustext = 'Training'";
                }
            }

            return qry;
        }


    }
}
