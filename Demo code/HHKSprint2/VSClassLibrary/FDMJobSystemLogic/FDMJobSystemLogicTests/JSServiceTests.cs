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
    public class JSServiceTests
    {
    //    IJSService service = new JSService();

    //    #region Job tests
    //    public DbJob SetupJob()
    //    {
    //        DbJob job = new DbJob();
    //        job.Location = "Manchester";
    //        job.Status = "Interviewing";
    //        job.Stream = "Testing";
    //        job.Title = "Testing insert job";
    //        job.Description = "A series of tests to test that a job is added to the database along with related skills.";
    //        job.UserId = 9;
    //        job.Deadline = DateTime.Now;
    //        job.DatePosted = DateTime.Now;
    //        job.Company = "Barclays";

    //        return job;
    //    }

    //    public List<string> SetupSkills()
    //    {
    //        List<string> skills = new List<string>();
    //        skills.Add("python");
    //        skills.Add("java");
    //        skills.Add("prolog");

    //        return skills;
    //    }

    //    [Test]
    //    public void TestInsertJobInsertsAJobIntoTheDatabase()
    //    {
    //        DbJob job = SetupJob();
    //        List<string> skills = SetupSkills();

    //        IJSService service = new JSService();
    //        service.InsertJob(job, skills);
    //    }

        //[Test]
        //public void TestInsertJobInsertsAJobIntoTheDatabase()
        //{
        //    DbJob job = new DbJob();
        //    job.JobId = 5;

        //    List<DbJob> jobs = new List<DbJob>();
        //    jobs.Add(job);

        //    List<string> skills = new List<string>();
        //    skills.Add(".Net");
        //    skills.Add("Java");


        //    IJSService service = new JSService();
        //    bool result = service.UpdateJobSkill(jobs, skills);

        //    Assert.IsInstanceOf(typeof(bool), result);
        //}
    //    #endregion
    }
}
