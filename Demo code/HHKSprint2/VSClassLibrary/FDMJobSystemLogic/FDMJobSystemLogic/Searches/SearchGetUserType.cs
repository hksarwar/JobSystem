using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace FDMJobSystemLogic
{
    public class SearchGetUserType : IReadSearchFactory<string>
    {
        public List<string> Execute()
        {
            string qry = "select TYPE.type_text from TYPE";
            IReadCommand cmd = new ReadCommand();
            List<string> usertypes = new List<string>();
            DataTable dt = cmd.Execute(qry);

            usertypes = (from row in dt.AsEnumerable() select Convert.ToString(row["TYPE_TEXT"])).ToList();
            return usertypes;
        }

    }
}
