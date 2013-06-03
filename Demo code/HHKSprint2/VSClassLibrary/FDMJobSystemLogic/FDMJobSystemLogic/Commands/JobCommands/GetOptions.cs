using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace FDMJobSystemLogic.Commands.JobCommands
{
    public class GetOptions
    {
        
        public List<string> Execute(string qry)
        {
            string cmdString = "select Status.StatusText from Status";
            IReadCommand cmd = new ReadCommand();
            DataTable dt = cmd.Execute(cmdString);
            List<string> status = new List<string>();

            status = (from row in dt.AsEnumerable() select Convert.ToString(row["STATUSTEXT"])).ToList();
            return status;
        }
    }
}
