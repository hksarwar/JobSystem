using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FDMJobSystemLogic
{
    public class UserLocForAutoFill
    {
        public List<string> Execute()
        {
            string cmdString = "Select distinct Location from FDMUSER";
            IReadCommand cmd = new ReadCommand();
            List<string> location = new List<string>();
            DataTable dt = cmd.Execute(cmdString);

            location = (from row in dt.AsEnumerable() select Convert.ToString(row["LOCATION"])).ToList();

            return location;
        }
    }
}
