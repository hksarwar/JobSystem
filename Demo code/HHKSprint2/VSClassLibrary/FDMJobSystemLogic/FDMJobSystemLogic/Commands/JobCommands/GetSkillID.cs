using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDMJobSystemLogic
{
    public class GetSkillId : IReadOneCommandFactory
    {
        public string Read(string qry)
        {
            string cmdString = "SELECT skill_id FROM Skill WHERE SkillText = '" + qry + "'";
            IReadOneCommand cmd = new ReadOneCommand();
            string result = cmd.Execute(cmdString).ToString();
            return result;
        }
    }
}
