using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace FDMJobSystemLogic
{
    public class GetUserSkills
    {
        public List<string> Execute(int userId)
        {
            string cmdString = "SELECT skilltext FROM skill s JOIN ( SELECT skill_id FROM userskill WHERE user_id = '" + userId + "')us ON s.skill_id = us.skill_id";
            IReadCommand cmd = new ReadCommand();
            List<string> skills = new List<string>();
            DataTable dt = cmd.Execute(cmdString);


            skills = (from row in dt.AsEnumerable() select Convert.ToString(row["SKILLTEXT"])).ToList();

            return skills;
        }
    }
}
