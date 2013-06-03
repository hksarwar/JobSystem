using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDMJobSystemLogic
{
    public class GetOneStatus
    {
        public string Read(int statusId)
        {
            string cmdString = "SELECT StatusText FROM Status WHERE status_id = '" + statusId + "'";
            IReadOneCommand cmd = new ReadOneCommand();
            return cmd.Execute(cmdString).ToString();
        }
    }
}
