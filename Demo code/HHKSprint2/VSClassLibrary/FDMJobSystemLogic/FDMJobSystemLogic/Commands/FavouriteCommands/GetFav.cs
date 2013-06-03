using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace FDMJobSystemLogic
{
    public class GetFav : IReadCommandFactory<DbJob>
    {
        int fav_id;
        Guid sessionID;

        public List<DbJob> Execute(DbJob job)
        {
            FindUser find = new FindUser();
            int userId = int.Parse(find.GetUserIDBySessionId(sessionID).ToString());

            string qry = "SELECT JOBPOST.job_id, Stream_id, Status_id, Description, Title, DatePosted, Deadline, Company, Location FROM JobPost JOIN FAVOURITE on JOBPOST.Job_id = FAVOURITE.Job_id WHERE FAVOURITE.User_id = " +
                          userId +"ORDER BY DatePosted";
            IReadCommand cmd = new ReadCommand();
            DataTable dt = cmd.Execute(qry);
            List<DbJob> favJobs = new List<DbJob>(dt.Rows.Count);


            //Get text for stream and status
            GetOneStatus status = new GetOneStatus();
            GetOneStream stream = new GetOneStream();

            favJobs = (from DataRow row in dt.Rows

                          select new DbJob
                          {
                              JobId = int.Parse(row["JOB_ID"].ToString()),
                              Stream = stream.Read(int.Parse(row["STREAM_ID"].ToString())),
                              Status = status.Read(int.Parse(row["STATUS_ID"].ToString())),
                              Description = row["DESCRIPTION"].ToString(),
                              Title = row["TITLE"].ToString(),
                              DatePosted = DateTime.Parse(row["DATEPOSTED"].ToString()),
                              Deadline = DateTime.Parse(row["DEADLINE"].ToString()),
                              Company = row["COMPANY"].ToString(),
                              Location = row["LOCATION"].ToString()
                          }).ToList();

            for (int i = 0; i < favJobs.Count; i++)
            {
               // favJobs[i].JobId = job.JobId;
                favJobs[i].UserId = userId;
            }

            return favJobs;
        }

        public void setFav_id(int fav_id)
        {
            this.fav_id = fav_id;
        }

        public void setSessionId(Guid sessionID)
        {
            this.sessionID = sessionID;
        }
    }
}
