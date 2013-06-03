using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace FDMJobSystemLogic
{
    class RecentJobs : IReadSearchFactory<DbJob>
    {

        public List<DbJob> Execute()
        {
            string qry = "SELECT Job_id, User_id, Stream_id, Status_id, Description, Title, DatePosted, Deadline, Company, Location FROM JobPost ORDER BY DatePosted";
            IReadCommand cmd = new ReadCommand();
            
            DataTable dt = cmd.Execute(qry);

            List<DbJob> recentJobs = new List<DbJob>(dt.Rows.Count);

            recentJobs = (from DataRow row in dt.Rows

                          select new DbJob
                     {
                         //JobId = row["JOBID"].ToString(),
                         

                     }).ToList();
            return recentJobs;
        }
    }
}
