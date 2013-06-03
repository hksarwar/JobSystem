using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FDMJobSystemLogic
{
    public class GetJobSkills
    {
        public List<string> Execute(int jobId)
        {
            string cmdString = "SELECT skilltext FROM skill s JOIN ( SELECT skill_id FROM jobskill WHERE job_id = '" + jobId + "')js ON s.skill_id = js.skill_id";
            IReadCommand cmd = new ReadCommand();
            List<string> skills = new List<string>();
            DataTable dt = cmd.Execute(cmdString);


            skills = (from row in dt.AsEnumerable() select Convert.ToString(row["SKILLTEXT"])).ToList();

            return skills;
        }
    }
}
