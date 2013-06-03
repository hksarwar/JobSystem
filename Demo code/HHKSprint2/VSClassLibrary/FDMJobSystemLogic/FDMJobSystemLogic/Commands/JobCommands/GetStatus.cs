using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace FDMJobSystemLogic
{
    public class GetStatus : IReadSearchFactory<string>
    {
        
        public List<string> Execute()
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
