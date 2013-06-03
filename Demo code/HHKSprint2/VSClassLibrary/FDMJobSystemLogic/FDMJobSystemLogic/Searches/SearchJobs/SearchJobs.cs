using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace FDMJobSystemLogic
{
    public class SearchJobs : ISearchJob
    {
        public List<DbJob> Search(string stream, string status, string location, string company, List<string> skills)
        {
            List<DbJob> finalJobs = new List<DbJob>();
            List<string> sortedJobs = new List<string>();
            List<string> sortedJobs2 = new List<string>();
            List<string> sortedJobs3 = new List<string>();
            List<string> sortedJobs4 = new List<string>();
            List<Tuple<string, int>> unsortedJobs = new List<Tuple<string, int>>();

            // search based on stream, status, skills, company and location
            
            string qry1 = GetQryStreamStatus(stream, status);
            string qry2 = GetQryLocComp(location, company);

            IReadCommand read = new ReadCommand();
            DataTable dt1 = read.Execute(qry1);
            List<string> jobs1 = (from row in dt1.AsEnumerable() select Convert.ToString(row["JOB_ID"])).ToList();

            for (int i = 0; i < jobs1.Count(); i++)
            {
                sortedJobs.Add(jobs1[i]);
            }

            DataTable dt2 = read.Execute(qry2);
            List<string> jobs2 = (from row in dt2.AsEnumerable() select Convert.ToString(row["JOB_ID"])).ToList();

            for (int i = 0; i < jobs2.Count(); i++)
            {
                sortedJobs2.Add(jobs2[i]);
            }

            //selects matching jobs from both lists
            List<string> relevantJobs = sortedJobs.Intersect(sortedJobs2).ToList();

            for (int k = 0; k < relevantJobs.Count(); k++)
            {
                sortedJobs3.Add(relevantJobs[k]);
            }


            // match skills
            List<string> jobs3 = new List<string>();
            // check if skills are empty
            if (skills.Count > 0)
            {
                // if not: for each required skill
                for (int i = 0; i < skills.Count(); i++)
                {
                    Console.WriteLine(skills[i]);
                    // select all jobs that have skill
                    string qry3 = "SELECT JOBPOST.job_id FROM JOBPOST JOIN JOBSKILL ON JOBPOST.job_id=JOBSKILL.job_id JOIN SKILL ON SKILL.skill_id = JOBSKILL.skill_id WHERE skilltext = '" + skills[i] + "'";
                    IReadCommand read2 = new ReadCommand();
                    DataTable dt3 = read2.Execute(qry3);
                    List<string> jobs4 = (from row in dt3.AsEnumerable() select Convert.ToString(row["JOB_ID"])).ToList();
                    for (int j = 0; j < jobs4.Count(); j++)
                    {
                        jobs3.Add(jobs4[j]);
                        //Console.WriteLine(jobs4[j]);
                    }
                    Console.WriteLine("count " + jobs3.Count().ToString());
                    // return list of jobs
                }

                //count how often job appears in skills - how many of the relevant skills it has
                var groups = jobs3.GroupBy(v => v);
                foreach (var group in groups)
                {
                    Tuple<string, int> job = new Tuple<string, int>(group.Key, group.Count());
                    unsortedJobs.Add(job);
                }

                // sort unique jobs by skill count
                unsortedJobs.Sort((a, b) => a.Item2.CompareTo(b.Item2));
                Console.WriteLine("count unsorted" + unsortedJobs.Count().ToString());

                for (int k = 0; k < unsortedJobs.Count(); k++)
                {
                    sortedJobs4.Add(unsortedJobs[k].Item1.ToString());
                }
                Console.WriteLine("count sorted" + sortedJobs4.Count().ToString());

                IEnumerable<string> relevantJobs2 = sortedJobs4.Intersect(relevantJobs);
                //IEnumerable<string> relevantJobs2 = relevantJobs.Intersect(sortedJobs3);

                foreach (var job in relevantJobs2.ToList())
                {
                    RecentJobs recJobs = new RecentJobs();
                    DbJob jobDesc = recJobs.GetJob(int.Parse(job));
                    finalJobs.Add(jobDesc);
                }
            }
            else
            {
                for (int i = 0; i < sortedJobs4.Count(); i++)
                {
                    RecentJobs recJobs = new RecentJobs();
                    DbJob jobDesc = recJobs.GetJob(int.Parse(sortedJobs4.ToList()[i]));
                    finalJobs.Add(jobDesc);
                }
            }


            return finalJobs;
        }

        // Get qry for stream and status
        public string GetQryStreamStatus(string stream, string status)
        {
            string qry;
            if (stream != "All")
            {
                if (status != "All")
                {
                    qry = "SELECT JOBPOST.job_id FROM JOBPOST JOIN STREAM ON JOBPOST.stream_id = STREAM.stream_id JOIN STATUS ON JOBPOST.status_id = STATUS.status_id WHERE statusText = '" + status + "' AND streamText = '" + stream + "'";
                }
                else 
                {
                    qry = "SELECT JOBPOST.job_id FROM JOBPOST JOIN STREAM ON JOBPOST.stream_id = STREAM.stream_id WHERE streamText = '" + stream + "'";
                }
            }
            else
            {
                if (status != "All")
                {
                    qry = "SELECT JOBPOST.job_id FROM JOBPOST JOIN STATUS ON JOBPOST.status_id = STATUS.status_id WHERE statusText = '" + status + "'";
                }
                else 
                {
                    qry = "SELECT JOBPOST.job_id FROM JOBPOST";
                }
            }

            return qry;
        }

        // Get qry for location and Company
        public string GetQryLocComp(string location, string company)
        {
            string qry;
            if (location != "Any")
            {
                if (company != "All")
                {
                    qry = "SELECT JOBPOST.job_id FROM JOBPOST WHERE location = '" + location + "' AND company = '" + company + "'";
                }
                else
                {
                    qry = "SELECT JOBPOST.job_id FROM JOBPOST WHERE location = '" + location + "'";
                }
            }
            else
            {
                if (company != "All")
                {
                    qry = "SELECT JOBPOST.job_id FROM JOBPOST WHERE company = '" + company + "'";
                }
                else
                {
                    qry = "SELECT JOBPOST.job_id FROM JOBPOST";
                }
            }

            return qry;
        }

    }
}
