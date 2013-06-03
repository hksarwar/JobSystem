using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDMJobSystemLogic
{
    public class GetStatusID
    {
        public string Read(string status)
        {
            string cmdString = "SELECT status_id FROM Status WHERE StatusText = '" + status + "'";
            IReadOneCommand cmd = new ReadOneCommand();
            return cmd.Execute(cmdString).ToString();
        }
    }
}
