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
    public class RecentJobTests
    {
        [Test]
        public void Test_RecentJobsClass_ExecuteMethod_Returns_A_List_of_DbJob()
        {
            RecentJobs rJobs = new RecentJobs();
            Assert.IsInstanceOf(typeof(List<DbJob>), rJobs.Execute());
        }

        [Test]
        public void TestRecentJobsExecuteMethodReturnsAListOfJobsForTrainer()
        {
            string stream = "All";
            RecentJobs recJobs = new RecentJobs();
            recJobs.SetStringStream(stream);
            List<DbJob> jobs = recJobs.Execute();
            Assert.AreEqual(5, jobs.Count());
        }

        [Test]
        public void TestRecentJobsExecuteMethodReturnsAListOfJobsForConsultant()
        {
            int user_id = 1;
            RecentJobs recJobs = new RecentJobs();
            recJobs.GetUserStream(user_id);
            List<DbJob> jobs =  recJobs.Execute();
            Assert.AreEqual(1, jobs.Count());
        }
    }
}
