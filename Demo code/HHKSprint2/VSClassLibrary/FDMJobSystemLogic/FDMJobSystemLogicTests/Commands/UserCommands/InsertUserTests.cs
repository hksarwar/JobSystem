using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Moq;
using NUnit.Framework;
using FDMJobSystemLogic;

namespace FDMJobSystemLogicTests.Commands.UserCommands
{
    [TestFixture]
    public class InsertUserTests
    {

        InsertUser addUser;
        List<DbUser> user;
        [Test]
        public void Test_InsertUserClass_GetCommandMethod_Returns_A_Bool()
        {
            Initialiser();
            bool result = addUser.GetCommand(user, 2);
            Assert.IsInstanceOf(typeof(bool), result);
        }

        [Test]
        public void Test_InsertUserClass_GetCommandMethod_Returns_True_With_Valid_UserDetails()
        {
            Initialiser();
            bool result = addUser.GetCommand(user, 2);
            Assert.IsTrue(result);
        }

        [Test]
        public void Test_InsertUserClass_GetCommandMethod_Returns_False_With_Invalid_UserDetails()
        {
            Initialiser();
            bool result = addUser.GetCommand(user, 0);
            Assert.IsFalse(result);
        }

        private void Initialiser()
        {

            addUser = new InsertUser();
            user = new List<DbUser>();
            user.Add(new DbUser());
            user[0].Username = "Thomas.Shore";
            user[0].Password = "password";
            user[0].FirstName = "Thomas";
            user[0].LastName = "Shore";
            user[0].Email = "thomas.shore@fdmgroup.com";
            user[0].Location = "Manchester";
            user[0].TypeId = 3;
            user.Add(new DbUser());
        }
    }
}
