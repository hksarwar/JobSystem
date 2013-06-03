using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Moq;
using NUnit.Framework;
using FDMJobSystemLogic;

namespace FDMJobSystemLogicTests.SearchTests
{
    
    [TestFixture]
    public class SearchJobTests
    {
        SearchJobs search = new SearchJobs();
        List<string> skills = new List<string>();

        public void Setup()
        {
            skills.Add("Java");
        }

        #region Test GetQryStreamStatus
        [Test]
        public void TestGetQryStreamStatusReturnsTheCorrectQueryWithAStreamAndStatus()
        {
            string stream = "Java";
            string status = "Interviewing";
            string correctQry = "SELECT JOBPOST.job_id FROM JOBPOST JOIN STREAM ON JOBPOST.stream_id = STREAM.stream_id JOIN STATUS ON JOBPOST.status_id = STATUS.status_id WHERE statusText = '" + status + "' AND streamText = '" + stream + "'";
            Assert.AreEqual(correctQry, search.GetQryStreamStatus(stream, status));
        }

        [Test]
        public void TestGetQryStreamStatusReturnsTheCorrectQueryWithAStream()
        {
            string stream = "Java";
            string status = "All";
            string correctQry = "SELECT JOBPOST.job_id FROM JOBPOST JOIN STREAM ON JOBPOST.stream_id = STREAM.stream_id WHERE streamText = '" + stream + "'";
            Assert.AreEqual(correctQry, search.GetQryStreamStatus(stream, status));
        }

        [Test]
        public void TestGetQryStreamStatusReturnsTheCorrectQueryWithAStatus()
        {
            string stream = "All";
            string status = "Potential";
            string correctQry = "SELECT JOBPOST.job_id FROM JOBPOST JOIN STATUS ON JOBPOST.status_id = STATUS.status_id WHERE statusText = '" + status + "'";
            Assert.AreEqual(correctQry, search.GetQryStreamStatus(stream, status));
        }

        [Test]
        public void TestGetQryStreamStatusReturnsTheCorrectQueryWithNoInput()
        {
            string stream = "All";
            string status = "All";
            string correctQry = "SELECT JOBPOST.job_id FROM JOBPOST";
            Assert.AreEqual(correctQry, search.GetQryStreamStatus(stream, status));
        }

#endregion

        #region Test GetQryLocComp

        [Test]
        public void TestGetQryLocCompReturnsTheCorrectQueryWithALocationAndCompany()
        {
            string location = "Manchester";
            string company = "Barclays";
            string correctQry = "SELECT JOBPOST.job_id FROM JOBPOST WHERE location = '" + location + "' AND company = '" + company + "'";
            Assert.AreEqual(correctQry, search.GetQryLocComp(location, company));
        }

        [Test]
        public void TestGetQryLocCompReturnsTheCorrectQueryWithALocation()
        {
            string location = "Luton";
            string company = "All";
            string correctQry = "SELECT JOBPOST.job_id FROM JOBPOST WHERE location = '" + location + "'";
            Assert.AreEqual(correctQry, search.GetQryLocComp(location, company));
        }

        [Test]
        public void TestGetQryLocCompReturnsTheCorrectQueryWithACompany()
        {
            string location = "Any";
            string company = "ASDA";
            string correctQry = "SELECT JOBPOST.job_id FROM JOBPOST WHERE company = '" + company + "'";
            Assert.AreEqual(correctQry, search.GetQryLocComp(location, company));
        }

        [Test]
        public void TestGetQryLocCompReturnsTheCorrectQueryWithNoInput()
        {
            string location = "Any";
            string company = "All";
            string correctQry = "SELECT JOBPOST.job_id FROM JOBPOST";
            Assert.AreEqual(correctQry, search.GetQryLocComp(location, company));
        }

        #endregion

        [Test]
        public void TestSearchReturnsTheCorrectJob()
        {
            Setup();
            string stream = ".Net";
            string status = "Potential";
            string location = "Surrey";
            string company = "RBI";
            int job_id = 1;
            List<DbJob> job = search.Search(stream, status, location, company, skills);
            Assert.AreEqual(job_id, job[0].JobId);
        }

        [Test]
        public void TestSearchReturnsAllJobsWithOpenStatus()
        {
            string stream = "All";
            string status = "Open";
            string location = "Any";
            string company = "All";
            int job_id = 2;
            int job_id2 = 5;
            List<DbJob> job = search.Search(stream, status, location, company, skills);
            Assert.AreEqual(job_id, job[0].JobId);
            Assert.AreEqual(job_id2, job[1].JobId);
        }

        [Test]
        public void TestSearchReturnsAllJobsWithLutonAsLocation()
        {
            string stream = "All";
            string status = "All";
            string location = "Luton";
            string company = "All";
            int job_id = 4;
            List<DbJob> job = search.Search(stream, status, location, company, skills);
            Assert.AreEqual(job_id, job[0].JobId);
        }

        [Test]
        public void TestSearchReturnsAllJobsWithDotNetSkill()
        {
            Setup();
            string stream = "All";
            string status = "All";
            string location = "Any";
            string company = "All";
            int job_id = 2;
            List<DbJob> job = search.Search(stream, status, location, company, skills);
            for (int i = 0; i < job.Count(); i++)
            {
                Console.WriteLine(job[i]);
                
            }
            Assert.AreEqual(job_id, job[0].JobId);
        }

    }
}
