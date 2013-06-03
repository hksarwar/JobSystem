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
    class SessionControlTests
    {
        SessionControlCommand cmd = new SessionControlCommand();
        SessionControl ctrl = new SessionControl();

        #region GetSessionID tests

        [Test]
        public void TestGetSessionIDReturnsASessionID()
        {
            int user_id = 1;
            int type_id = 3;

            Guid current_session_id = cmd.SessionStart(user_id, type_id);
            Guid id = ctrl.GetSessionID(current_session_id);
            Assert.IsInstanceOf(typeof(Guid), id);
        }

        [Test]
        public void TestGetSessionIdReturnsTheCorrectSessionId()
        {
            int user_id = 1;
            int type_id = 3;

            Guid current_session_id = cmd.SessionStart(user_id, type_id);
            Guid id = ctrl.GetSessionID(current_session_id);

            Console.WriteLine(current_session_id);
            Console.WriteLine(id);

            Assert.AreEqual(current_session_id, id);
        }

        #endregion
    }
}
