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
    public class GetFavTests
    {
        [Test]
        public void Test_GetFavClass_ExecuteMethod_Retruns_A_List_of_DbJob()
        {
            DbJob job = new DbJob();
            job.JobId = 1;
            List<DbJob> jobList = new List<DbJob>();
            jobList.Add(job);

            GetFav getFav = new GetFav();
            getFav.setSessionId ( Guid.Parse("023bf663-97ea-421d-89fc-611edea5f79d"));

            List<DbJob> jobs = getFav.Execute(job);
            Assert.IsInstanceOf(typeof(List<DbJob>), jobs);
        }

        [Test]
        public void Test_GetFavClass_ExecuteMethod_Retruns_A_True_When_User_Has_Favr()
        {
            DbJob job = new DbJob();
            job.JobId = 1;
            List<DbJob> jobList = new List<DbJob>();
            jobList.Add(job);

            GetFav getFav = new GetFav();
            getFav.setSessionId(Guid.Parse("023bf663-97ea-421d-89fc-611edea5f79d"));

            List<DbJob> jobs = getFav.Execute(job);
            Assert.AreEqual(3, jobs.Count);
        }
    }
}
