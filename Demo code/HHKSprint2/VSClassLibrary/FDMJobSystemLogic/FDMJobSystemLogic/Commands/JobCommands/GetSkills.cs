using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FDMJobSystemLogic
{
    public class GetSkills
    {
        public List<string> Execute()
        {
            string cmdString = "SELECT skilltext FROM Skill ORDER BY skilltext";
            IReadCommand cmd = new ReadCommand();
            List<string> skills = new List<string>();
            DataTable dt = cmd.Execute(cmdString);


            skills = (from row in dt.AsEnumerable() select Convert.ToString(row["SKILLTEXT"])).ToList();
                
            return skills;
        }
    }
}
