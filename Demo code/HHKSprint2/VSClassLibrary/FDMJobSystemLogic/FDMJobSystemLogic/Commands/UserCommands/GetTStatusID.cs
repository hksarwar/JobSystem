using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDMJobSystemLogic
{
    public class GetTStatusID
    {
        public string Read(string tstatus)
        {
            string cmdString = "SELECT tstatus_id FROM TRAINEE_STATUS WHERE TSTATUSTEXT = '" + tstatus + "'";
            IReadOneCommand cmd = new ReadOneCommand();
            return cmd.Execute(cmdString).ToString();
        }
    }
}
