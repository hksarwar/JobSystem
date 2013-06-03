using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace FDMJobSystemLogic
{
    public class GetOptions : IGetOptions
    {
        public List<string> GetStatuses()
        {
            string cmdString = "select StatusText from Status";
            IReadCommand cmd = new ReadCommand();
            DataTable dt = cmd.Execute(cmdString);
            List<string> status = new List<string>();

            status = (from row in dt.AsEnumerable() select Convert.ToString(row["STATUSTEXT"])).ToList();
            return status;
        }

        public List<string> GetStreams()
        {
            string cmdString = "select streamtext from Stream ORDER BY StreamText";
            IReadCommand cmd = new ReadCommand();
            DataTable dt = cmd.Execute(cmdString);
            List<string> stream = new List<string>();

            stream = (from row in dt.AsEnumerable() select Convert.ToString(row["STREAMTEXT"])).ToList();
            return stream;
        }

        public List<string> GetTStatuses()
        {
            string cmdString = "select tStatusText from trainee_Status ORDER BY tStatusText";
            IReadCommand cmd = new ReadCommand();
            DataTable dt = cmd.Execute(cmdString);
            List<string> status = new List<string>();

            status = (from row in dt.AsEnumerable() select Convert.ToString(row["TSTATUSTEXT"])).ToList();
            return status;
        }

        public List<string> GetCompanies()
        {
            string qry = "select DISTINCT JOBPOST.company from JOBPOST";
            IReadCommand cmd = new ReadCommand();
            List<string> companies = new List<string>();
            DataTable dt = cmd.Execute(qry);

            companies = (from row in dt.AsEnumerable() select Convert.ToString(row["COMPANY"])).ToList();
            return companies;
        }

        public List<string> GetLocations()
        {
            string qry = "select DISTINCT JOBPOST.location from JOBPOST";
            IReadCommand cmd = new ReadCommand();
            List<string> locations = new List<string>();
            DataTable dt = cmd.Execute(qry);

            locations = (from row in dt.AsEnumerable() select Convert.ToString(row["LOCATION"])).ToList();
            return locations;
        }
    }
}
