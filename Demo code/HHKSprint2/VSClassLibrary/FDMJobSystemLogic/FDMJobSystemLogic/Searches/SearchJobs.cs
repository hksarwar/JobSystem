using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace FDMJobSystemLogic.Searches.SearchJobs
{
    public class SearchJobs
    {
        public List<DbJob> Execute(string stream, string status, string location, string company, List<string> skills)
        {
            List<DbJob> finalJobs = new List<DbJob>();
            List<string> sortedJobs = new List<string>();

            // search based on stream, status, skills, company and location

            // get jobs with stream, status, loaction and company match
            string qry = "SELECT JOBPOST.job_id FROM JOBPOST JOIN STREAM ON JOBPOST.stream_id = STREAM.stream_id JOIN STATUS ON JOBPOST.status_id = STATUS.status_id WHERE statusText = '" + status + "' AND streamText = '" + stream + "' AND company = '" + company + "' AND location = '" + location + "'";

            IReadCommand read = new ReadCommand();
            DataTable dt = read.Execute(qry);
            List<string> jobs = (from row in dt.AsEnumerable() select Convert.ToString(row["JOB_ID"])).ToList();

            for (int i = 0; i < jobs.Count(); i++)
            {
                sortedJobs.Add(jobs[i]);
            }


            // match skills

            return finalJobs;
        }

        public string GetQry(string stream, string status, List<string> skills)
        {
            string qry;
            if (stream != "All")
            {
                if (status != "All Available")
                {
                    qry = "SELECT FDMUSER.user_id FROM FDMUSER JOIN PROFILE ON FDMUSER.user_id = PROFILE.user_id JOIN STREAM ON PROFILE.stream_id = STREAM.stream_id JOIN TRAINEE_STATUS ON profile.tstatus_id = trainee_status.tstatus_id WHERE streamText = '" + stream + "' AND tstatustext = '" + status + "'";
                }
                else //not placed
                {
                    qry = "SELECT FDMUSER.user_id FROM FDMUSER JOIN PROFILE ON FDMUSER.user_id = PROFILE.user_id JOIN STREAM ON PROFILE.stream_id = STREAM.stream_id JOIN TRAINEE_STATUS ON profile.tstatus_id = trainee_status.tstatus_id WHERE streamText = '" + stream + "' AND tstatustext = 'Training' OR tstatustext = 'Available'";
                }
            }
            else
            {
                if (status != "All Available")
                {
                    qry = "SELECT FDMUSER.user_id FROM FDMUSER JOIN PROFILE ON FDMUSER.user_id = PROFILE.user_id JOIN TRAINEE_STATUS ON profile.tstatus_id = trainee_status.tstatus_id WHERE tstatustext = '" + status + "'";
                }
                else // not placed
                {
                    qry = "SELECT FDMUSER.user_id FROM FDMUSER JOIN PROFILE ON FDMUSER.user_id = PROFILE.user_id JOIN TRAINEE_STATUS ON profile.tstatus_id = trainee_status.tstatus_id WHERE tstatustext = 'Available' OR tstatustext = 'Training'";
                }
            }

            return qry;
        }

    }
}
