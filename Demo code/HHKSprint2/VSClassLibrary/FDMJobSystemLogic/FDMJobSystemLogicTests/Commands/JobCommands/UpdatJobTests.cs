using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Moq;
using NUnit.Framework;
using FDMJobSystemLogic;

namespace FDMJobSystemLogicTests.Commands.JobCommands
{
    [TestFixture]
    public class UpdatJobTests
    {
        [Test]
        public void Test_UpdateJobClass_GetCommandMethod_Returns_A_bool()
        {
            DbJob job = new DbJob();
            job.JobId = 6;
            job.UserId = 6;
            job.Stream = "Testing";
            job.Status = "Interviewing";
            job.Company = "MyCompany";
            job.Location = "Manchester";
            job.Title = "updating From Tests";
            job.Description = "I commit this change via NUnit";
            job.Deadline = DateTime.Now;

            List<DbJob> jobList = new List<DbJob>();
            jobList.Add(job);

            UpdateJob upjob = new UpdateJob();
            bool result = upjob.GetCommand(jobList);

            Assert.IsInstanceOf(typeof(bool), result);
        }

        [Test]
        public void Test_UpdateClass_GetCommandMethod_Returns_A_bool()
        {
            DbJob job = new DbJob();
            job.JobId = 5;

            List<DbJob> jobs = new List<DbJob>();
            jobs.Add(job);


            List<string> deleteskills = new List<string>();
            deleteskills.Add(".Net");

            List<string> Addedskills = new List<string>();
            Addedskills.Add("SQL");
            Addedskills.Add("Java");
            Addedskills.Add("VMware");


            UpdateJob upjob = new UpdateJob();
            bool result = upjob.GetCommand(jobs, deleteskills);

            Assert.IsInstanceOf(typeof(bool), result);
        }
    }
}
