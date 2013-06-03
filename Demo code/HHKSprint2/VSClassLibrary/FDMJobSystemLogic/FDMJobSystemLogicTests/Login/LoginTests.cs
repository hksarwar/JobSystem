using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Moq;
using NUnit.Framework;
using FDMJobSystemLogic;

namespace FDMJobSystemLogicTests.Login
{
    [TestFixture]
    public class LogInTests
    {
        #region GetUserID tests
        [Test]
        public void TestGetUserIDReturnsAnInteger()
        {
            string username = "katie.hodgkiss";
            string password = "password";
 
            LogIn log = new LogIn();
            int id = log.GetUserID(username, password);
            Assert.IsInstanceOf(typeof(int), id);

        }
        #endregion

    }
}
