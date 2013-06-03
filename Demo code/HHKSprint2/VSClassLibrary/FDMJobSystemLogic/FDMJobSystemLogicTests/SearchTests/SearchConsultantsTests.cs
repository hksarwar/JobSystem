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
    public class SearchConsultantsTests
    {
        SearchConsultants search = new SearchConsultants();
        List<string> skills = new List<string>();

        public void Setup()
        {
            skills.Add("SQL");
        }

        #region GetQry method tests

        [Test]
        public void TestGetQryReturnsTheCorrectQueryWithAStreamAndStatus()
        {
            Setup();
            string stream = "Java";
            string status = "Available";
            string correctQry = "SELECT FDMUSER.user_id FROM FDMUSER JOIN PROFILE ON FDMUSER.user_id = PROFILE.user_id JOIN STREAM ON PROFILE.stream_id = STREAM.stream_id JOIN TRAINEE_STATUS ON profile.tstatus_id = trainee_status.tstatus_id WHERE streamText = '" + stream + "' AND tstatustext = '" + status + "'";
            Assert.AreEqual(correctQry, search.GetQry(stream, status, skills));
        }

        [Test]
        public void TestGetQryReturnsTheCorrectQueryWithAStream()
        {
            Setup();
            string stream = "Java";
            string status = "All Available";
            string correctQry = "SELECT FDMUSER.user_id FROM FDMUSER JOIN PROFILE ON FDMUSER.user_id = PROFILE.user_id JOIN STREAM ON PROFILE.stream_id = STREAM.stream_id JOIN TRAINEE_STATUS ON profile.tstatus_id = trainee_status.tstatus_id WHERE streamText = '" + stream + "' AND tstatustext = 'Training' OR tstatustext = 'Available'";
            Assert.AreEqual(correctQry, search.GetQry(stream, status, skills));
        }

        [Test]
        public void TestGetQryReturnsTheCorrectQueryWithAStatus()
        {
            Setup();
            string stream = "All";
            string status = "Available";
            string correctQry = "SELECT FDMUSER.user_id FROM FDMUSER JOIN PROFILE ON FDMUSER.user_id = PROFILE.user_id JOIN TRAINEE_STATUS ON profile.tstatus_id = trainee_status.tstatus_id WHERE tstatustext = '" + status + "'";
            Assert.AreEqual(correctQry, search.GetQry(stream, status, skills));
        }

        [Test]
        public void TestGetQryReturnsTheCorrectQueryWithNoInput()
        {
            Setup();
            string stream = "All";
            string status = "All Available";
            string correctQry = "SELECT FDMUSER.user_id FROM FDMUSER JOIN PROFILE ON FDMUSER.user_id = PROFILE.user_id JOIN TRAINEE_STATUS ON profile.tstatus_id = trainee_status.tstatus_id WHERE tstatustext = 'Available' OR tstatustext = 'Training'";
            Assert.AreEqual(correctQry, search.GetQry(stream, status, skills));
        }

        #endregion

        #region Search method tests

        [Test]
        public void TestSearchReturnsTheCorrectUser()
        {
            Setup();
            string stream = "Java";
            string status = "Placed";
            int user_id = 7;
            List<DbUser> users = search.Search(stream, status, skills);
            Assert.AreEqual(user_id, users[0].UserId);
        }

        [Test]
        public void TestSearchReturnsAllUsersThatAreNotPlaced()
        {
            Setup();
            string stream = "All";
            string status = "All Available";
            int userCount = 5;
            List<DbUser> users = search.Search(stream, status, skills);
            Assert.AreEqual(userCount, users.Count());
        }

        #endregion
    }
}
