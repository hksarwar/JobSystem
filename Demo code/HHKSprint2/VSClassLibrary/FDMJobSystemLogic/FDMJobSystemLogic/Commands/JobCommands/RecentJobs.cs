using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace FDMJobSystemLogic
{
    public class RecentJobs : IReadSearchFactory<DbJob>
    {
        string streamText;

        public List<DbJob> Execute()
        {
            string qry;

            if (streamText != "All")
            {
                qry = "SELECT JobPost.Job_id, JobPost.User_id, JobPost.Stream_id, JobPost.Status_id, JobPost.Description, JobPost.Title, JobPost.DatePosted, JobPost.Deadline, JobPost.Company, JobPost.Location FROM JobPost JOIN stream ON stream.stream_id = jobpost.stream_id WHERE streamtext = '" + this.streamText + "' ORDER BY JOBPOST.DatePosted DESC";
            }
            else
            {
                qry = "SELECT JobPost.Job_id, JobPost.User_id, JobPost.Stream_id, JobPost.Status_id, JobPost.Description, JobPost.Title, JobPost.DatePosted, JobPost.Deadline, JobPost.Company, JobPost.Location FROM JobPost JOIN stream ON stream.stream_id = jobpost.stream_id WHERE jobpost.dateposted >= trunc(sysdate)-7 OR jobpost.deadline BETWEEN trunc(sysdate) AND trunc(sysdate)+14 ORDER BY JOBPOST.DatePosted DESC";

            }
            IReadCommand cmd = new ReadCommand();
            DataTable dt = cmd.Execute(qry);
            List<DbJob> recentJobs = new List<DbJob>(dt.Rows.Count);


            //Get text for stream and status
            GetOneStatus status = new GetOneStatus();
            GetOneStream stream = new GetOneStream();

            recentJobs = (from DataRow row in dt.Rows

                          select new DbJob
                     {
                         JobId = int.Parse(row["JOB_ID"].ToString()),
                         UserId = int.Parse(row["USER_ID"].ToString()),
                         Stream = stream.Read(int.Parse(row["STREAM_ID"].ToString())),
                         Status = status.Read(int.Parse(row["STATUS_ID"].ToString())),
                         Description = row["DESCRIPTION"].ToString(),
                         Title = row["TITLE"].ToString(),
                         //DatePosted = DateTime.Parse(row["DATEPOSTED"].ToString()),
                         //Deadline = DateTime.Parse(row["DEADLINE"].ToString()),
                         Company = row["COMPANY"].ToString(),
                         Location = row["LOCATION"].ToString()
                     }).ToList();

            for (int i = 0; i < recentJobs.Count(); i++)
            {
                GetDates(recentJobs[i]);
            }

            return recentJobs;
        }

        public DbJob GetJob(int jobId)
        {
            string qry = "SELECT Job_id, User_id, Stream_id, Status_id, Description, Title, DatePosted, Deadline, Company, Location FROM JobPost WHERE job_id = " + jobId;
            IReadCommand cmd = new ReadCommand();
            DataTable dt = cmd.Execute(qry);
            


            //Get text for stream and status
            GetOneStatus status = new GetOneStatus();
            GetOneStream stream = new GetOneStream();

            List<DbJob> recentJobs = (from DataRow row in dt.Rows

                          select new DbJob
                          {
                              JobId = int.Parse(row["JOB_ID"].ToString()),
                              UserId = int.Parse(row["USER_ID"].ToString()),
                              Stream = stream.Read(int.Parse(row["STREAM_ID"].ToString())),
                              Status = status.Read(int.Parse(row["STATUS_ID"].ToString())),
                              Description = row["DESCRIPTION"].ToString(),
                              Title = row["TITLE"].ToString(),
                              DatePosted = DateTime.Parse(row["DATEPOSTED"].ToString()),
                              Deadline = DateTime.Parse(row["DEADLINE"].ToString()),
                              Company = row["COMPANY"].ToString(),
                              Location = row["LOCATION"].ToString()
                          }).ToList();

            return recentJobs[0];
        }

        public void SetStringStream(string stream)
        {
            this.streamText = stream;
        }

        public string GetUserStream(int user_id)
        {
            string qry = "SELECT stream.streamtext FROM stream JOIN PROFILE ON Profile.stream_id = stream.stream_id JOIN FDMUSER ON  profile.user_id = fdmuser.user_id WHERE FDMUSER.user_id = " + user_id;
            IReadOneCommand cmd = new ReadOneCommand();
            return cmd.Execute(qry);
        }

        public void GetDates(DbJob job)
        {
            // Get dateposted
            string qry = "select to_char(max(DatePosted), 'DD/MM/YYYY') from JOBPOST WHERE job_id = " + job.JobId;
            IReadOneCommand cmd = new ReadOneCommand();
            job.DatePosted = DateTime.Parse(cmd.Execute(qry));

            // Get deadline
            string qry2 = "select to_char(max(Deadline), 'DD/MM/YYYY') from JOBPOST WHERE job_id = " + job.JobId;
            IReadOneCommand cmd2 = new ReadOneCommand();
            job.Deadline = DateTime.Parse(cmd.Execute(qry2));
        }
    }
}
