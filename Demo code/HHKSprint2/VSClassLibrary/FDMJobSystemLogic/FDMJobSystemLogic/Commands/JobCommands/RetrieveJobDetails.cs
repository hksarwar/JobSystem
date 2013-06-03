using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace FDMJobSystemLogic
{
    public class RetrieveJobDetails : IRetrieveJobDetails
    {
        public DbJob GetDetails(int jobID)
        {
            try
            {
                string qry = "SELECT Job_id, User_id, Stream_id, Status_id, Description, Title, DatePosted, Deadline, Company, Location FROM JobPost WHERE job_id = " + jobID;
                IReadCommand cmd = new ReadCommand();
                DataTable dt = cmd.Execute(qry);

                //Get text for stream and status
                GetOneStatus status = new GetOneStatus();
                GetOneStream stream = new GetOneStream();

                List<DbJob> jobs = (from DataRow row in dt.Rows

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

                DbJob job = jobs[0];
                string qry2 = "SELECT skill.skilltext FROM SKILL JOIN JOBSKILL ON skill.skill_id = jobskill.skill_id WHERE job_id = " + jobID;
                IReadCommand cmd2 = new ReadCommand();
                DataTable dt2 = cmd.Execute(qry2);

                job.Skills = (from row in dt2.AsEnumerable() select Convert.ToString(row["SKILLTEXT"])).ToList();

                return job;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new DbJob();
            }
        }
    }
}
