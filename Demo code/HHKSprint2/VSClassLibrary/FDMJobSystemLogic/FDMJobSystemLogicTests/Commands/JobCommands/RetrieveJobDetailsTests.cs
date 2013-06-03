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
    public class RetrieveJobDetailsTests
    {
        [Test]
        public void TestGetDetailsReturnsAJob()
        {
            int jobID = 1;
            RetrieveJobDetails get = new RetrieveJobDetails();
            DbJob job = get.GetDetails(jobID);
            Console.WriteLine(job.Title);
            Console.WriteLine(job.Skills[0]);
            string title = "Ace Dot Net Dev";
            Assert.AreEqual(title, job.Title.ToString());
        }
    }
}
