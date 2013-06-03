using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  

using System.Data;

namespace FDMJobSystemLogic
{
   public class MyJobs : IReadCommandFactory<DbJob>
    {
       public List<DbJob> Execute(DbJob job)
       {
           string cmdString = "select JOBPOST.job_id, JOBPOST.stream_id,JOBPOST.status_id,JOBPOST.Location, JOBPOST.Company, JOBPOST.DatePosted, JOBPOST.Deadline, JOBPOST.Title, JOBPOST.description from JOBPOST WHERE JOBPOST.User_id =" + job.UserId;
           IReadCommand cmd = new ReadCommand();
           DataTable dt = cmd.Execute(cmdString);


           GetOneStatus status = new GetOneStatus();
           GetOneStream stream = new GetOneStream();

            List<DbJob> jobs = (from DataRow row in dt.Rows

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

            for (int i = 0; i < jobs.Count; i++)
            {
                jobs[i].UserId = job.UserId;
            }
            return jobs;
        }
    }
}
