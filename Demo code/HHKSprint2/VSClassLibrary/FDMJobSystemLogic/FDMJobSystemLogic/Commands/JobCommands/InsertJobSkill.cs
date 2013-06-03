using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDMJobSystemLogic
{
    public class InsertJobSkill : IWriteCommandFactory<string>
    {
        public bool GetCommand(List<string> skills, int skill_id)
        {
            IWriteCommand cmd = new WriteCommand();

            foreach (string skill in skills)
            {
                string cmdString = "sp_add_jobSkill(" + skill_id + ")";

                cmd.SetCommand(cmdString);
                cmd.Execute();
            }

            if (cmd.Execute() == true)
            {
                return true;
            }
            return false;

        }
    }
}
