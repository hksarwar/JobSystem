using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FDMJobSystemLogic
{
    public class GetCompanyForAutoFill
    {
        public List<string> Execute()
        {
            string cmdString = "Select distinct COMPANY from JOBPOST";
            IReadCommand cmd = new ReadCommand();
            List<string> company = new List<string>();
            DataTable dt = cmd.Execute(cmdString);

            company = (from row in dt.AsEnumerable() select Convert.ToString(row["COMPANY"])).ToList();
            
            return company;
        }

    }
}
