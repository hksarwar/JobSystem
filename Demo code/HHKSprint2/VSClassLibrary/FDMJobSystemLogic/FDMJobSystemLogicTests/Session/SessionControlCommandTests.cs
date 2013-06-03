using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Moq;
using NUnit.Framework;
using FDMJobSystemLogic;

namespace FDMJobSystemLogicTests.Session
{
    [TestFixture]
    public class SessionControlCommandTests
    {
        SessionControlCommand cmd = new SessionControlCommand();

        #region SessionStart tests
        [Test]
        public void TestSessionStartReturnsAGuidWhenSuccesfullyAddedToTheDatabase()
        {
            int user_id = 1;
            int type_id = 3;

            Guid g = cmd.SessionStart(user_id, type_id);
            Assert.IsInstanceOf(typeof(Guid), g);

            // Manual test to determine if session record has been added to the database
            // Test succedded 4/1/13 @ 15:11
        }
        #endregion

        #region GetUser tests

        [Test]
        public void TestGetUserReturnsAUser()
        {
            int user_id = 1;
            int type_id = 3;

            Guid session_id = cmd.SessionStart(user_id, type_id);
            DbUser u = cmd.GetUser(session_id);
            Assert.IsInstanceOf(typeof(Guid), session_id);
        }

        [Test]
        public void TestGetUserReturnsTheCorrectUser()
        {
            int user_id = 1;
            string username = "katie.hodgkiss";
            int type_id = 3;

            Guid session_id = cmd.SessionStart(user_id, type_id);
            DbUser u = cmd.GetUser(session_id);
            Assert.AreEqual(username, u.Username);
        }

        [Test]
        public void TestGetUserReturnsAnEmptyUserWhenAnInvalidSessionIdIsInput()
        {
            Guid session_id = Guid.NewGuid();
            DbUser u = cmd.GetUser(session_id);
            Assert.AreEqual(null, u.Username);
        }

        #endregion

        #region EndSession tests

        [Test]
        public void TestEndSessionReturnsTrueAndDeletesTheSessionFromTheDatabaseWhenUserEndsSession()
        {
            int user_id = 1;
            //string username = "katie.hodgkiss";
            int type_id = 3;

            Guid session_id = cmd.SessionStart(user_id, type_id);
            bool success = cmd.EndSession(session_id);
            Assert.IsTrue(success);

            // Manual test to determine if session record has been deleted from the database
            // Test succedded 4/1/13 @ 15:11
        }

        [Test]
        public void TestEndSessionReturnsFalseWhenUserEndsSessionAndSessionCannotBeFound()
        {
            Guid session_id = Guid.NewGuid();
            bool success = cmd.EndSession(session_id);
            Assert.IsFalse(success);
        }

        #endregion
    }
}
