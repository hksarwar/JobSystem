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
    public class LoginCommandTests
    {
        ILoginCommand cmd = new LoginCommand();

        #region VerifyDetails tests
        [Test]
        public void TestVerifyDetailsReturnsAGuidWithASuccesfulLoginPair()
        {
            string username = "roxanne.cuddy";
            string password = "password";
            string type_id = "Account Manager";

            Guid g = cmd.VerifyDetails(username, password, type_id);

            Console.WriteLine(g);
            Assert.AreNotEqual(Guid.Empty, g);
        }

        [Test]
        public void TestVerifyDetailsReturnsAnEmptyGuidWithAnUnsuccesfulLoginPair()
        {
            string username = "roxanne.cuddy";
            string type_id = "Account Manager";
            string password = "pas-word";

            Guid g = cmd.VerifyDetails(username, password, type_id);
            Assert.AreEqual(Guid.Empty, g);
        }
        #endregion

        #region VerifyDetails(overload1) tests
        [Test]
        public void TestVerifyDetailsOverload1ReturnsAGuidWithASuccesfulLoginPair()
        {
            string username = "katie.hodgkiss";
            string password = "password";
            string type_id = "Consultant";
            string type_id2 = "Trainee";

            Guid g = cmd.VerifyDetails(username, password, type_id, type_id2);
            Assert.IsInstanceOf(typeof(Guid), g);
        }

        [Test]
        public void TestVerifyDetailsOverload1ReturnsAnEmptyGuidWithAnUnsuccesfulLoginPair()
        {
            string username = "katie.hodgkiss";
            string password = "pas-word";
            string type_id = "Consultant";
            string type_id2 = "Trainee";

            Guid g = cmd.VerifyDetails(username, password, type_id, type_id2);
            Assert.AreEqual(Guid.Empty, g);
        }

        [Test]
        public void Test_VerifyDeatals_Overload1_Returns_A_Guid_With_successful_Login_pair()
        {
            string username = "katie.hodgkiss";
            string password = "password";
            string type_id = "Consultant";
            string type_id2 = "Trainee";

            Guid g = cmd.VerifyDetails(username, password, type_id, type_id2);
            Assert.AreNotEqual(Guid.Empty, g);
        }
        #endregion

        #region TerminateSession tests

        // Manual test
        [Test]
        public void TestTerminateSessionDeletesTheSessionFromTheDatabase()
        {
            string username = "roxanne.cuddy";
            string password = "password";
            string type_id = "Account Manager";

            Guid session_id = cmd.VerifyDetails(username, password, type_id);
            Console.WriteLine(session_id);
            Assert.IsInstanceOf(typeof(Guid), session_id);
            cmd.TerminateSession(session_id);
        }

        #endregion
    }
}
