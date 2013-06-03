using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Moq;
using NUnit.Framework;
using FDMJobSystemLogic;

namespace FDMJobSystemLogicTests
{
    [TestFixture]
    public class InsertJobTests
    {
        public DbJob SetupJob()
        {
            DbJob job = new DbJob();
            job.Location = "Manchester";
            job.Status = "Interviewing";
            job.Stream = "Testing";
            job.Title = "Testing insert job";
            job.Description = "A series of tests to test that a job is added to the database along with related skills.";
            job.UserId = 9;
            job.Deadline = DateTime.Now;
            job.DatePosted = DateTime.Now;
            job.Company = "Barclays";

            return job;
        }

        public List<string> SetupSkills()
        {
            List<string> skills = new List<string>();
            skills.Add("python");
            skills.Add("java");
            skills.Add("prolog");

            return skills;
        }

        //[Test]
        //public void TestGetCommandReturnsTrueWithValidJobDetails()
        //{
        //    DbJob job = SetupJob();
        //    List<string> skills = SetupSkills();

        //    InsertSkill ins = new InsertSkill();
        //    for (int i = 0; i < skills.Count(); i++)
        //    {
        //        ins.GetCommand(skills[i]);
        //    }
        //    InsertJob insJob = new InsertJob();
        //    bool addJob = insJob.GetCommand(job, skills);
        //    Assert.IsTrue(addJob);
        //}
    }
}
