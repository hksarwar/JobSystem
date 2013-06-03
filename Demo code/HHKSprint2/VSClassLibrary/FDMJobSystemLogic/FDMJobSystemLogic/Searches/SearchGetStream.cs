using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace FDMJobSystemLogic
{
    public class SearchGetStream : IReadSearchFactory<string>
    {
        public List<string> Execute()
        {
            string qry = "select STREAM.streamtext from STREAM";
            IReadCommand cmd = new ReadCommand();
            List<string> streams = new List<string>();
            DataTable dt = cmd.Execute(qry);

            streams = (from row in dt.AsEnumerable() select Convert.ToString(row["STREAMTEXT"])).ToList();
            return streams;
        }
    }
}
