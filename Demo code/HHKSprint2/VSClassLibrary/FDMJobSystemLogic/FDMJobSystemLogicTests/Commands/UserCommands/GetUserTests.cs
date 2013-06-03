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
    public class GetUserTests
    {
        [Test]
        public void Test_GetUserClass_ExecuteMethod_Returns_A_List_of_strings()
        {
            FindUser usernames = new FindUser();
            Assert.IsInstanceOf(typeof(List<string>), usernames.Execute());
        }

        [Test]
        public void Test_GetUserClass_UniqueUsernameMethod_Returns_A_bool()
        {
            FindUser usernames = new FindUser();
            Assert.IsInstanceOf(typeof(bool), usernames.UniqueUsername("hinnah.sarwar"));
        }

        [Test]
        public void Test_GetUserClass_UniqueUsernameMethod_Returns_False_When_Username_Already_Exsist_in_The_Database()
        {
            FindUser usernames = new FindUser();
            Assert.IsFalse(usernames.UniqueUsername("hinnah.sarwar"));
        }

        [Test]
        public void Test_GetUserClass_NumOfUsersMethod_Returns_An_Int()
        {
            string firstName = "Hinnah";
            string lastName = "Sarwar";
            FindUser usernames = new FindUser();
            Assert.IsInstanceOf(typeof(int),usernames.NumOfUsers(firstName, lastName));
        }

        [Test]
        public void Test_GetUserClass_NumOfUsersMethod_Returns_One_With_OneOccurance()
        {
            string firstName = "Hinnah";
            string lastName = "Sarwar";
            FindUser usernames = new FindUser();
            Assert.AreEqual(1, usernames.NumOfUsers(firstName, lastName));
        }

        [Test]
        public void Test_GetUserClass_NumOfUsersMethod_Returns_Three_With_MoreThanOneOccurance()
        {
            string firstName = "Thomas";
            string lastName = "Shore";
            FindUser usernames = new FindUser();
            Assert.AreNotEqual(1, usernames.NumOfUsers(firstName, lastName));
        }

        [Test]
        public void Test_GetUserClass_UniqueUsernameMethod_Returns_True_When_Username_Doesnot_Exsist_in_The_Database()
        {
            FindUser usernames = new FindUser();
            Assert.IsTrue(usernames.UniqueUsername("sean.thurgood"));
        }

        [Test]
        public void TestFindUserClass_ExecuteMethod_Accepts_Username_And_returns_A_ListOf_DbUser()
        {
            FindUser users = new FindUser();
            Assert.IsInstanceOf(typeof(List<DbUser>), users.Execute("hinnah.sarwar"));
        }

        [Test]
        public void TestFindUserClass_ExecuteMethod_Returns_One_With_Valid_UserName()
        {
            FindUser users = new FindUser();
            Assert.AreEqual(1, users.Execute("hinnah.sarwar").Count);
        }

        [Test]
        public void Test_FindUserClass_ExecuteMethod_Returns_A_Listof_DbUsers()
        {
            FindUser user = new FindUser();
            DbUser findUser = new DbUser();
            findUser.TypeId = 1;
            Assert.IsInstanceOf(typeof(List<DbUser>), user.Execute(findUser));
        }

        [Test]
        public void Test_FindUserClass_ExecuteMethod_Returns_MoreThanOneUser_InThe_Listof_DbUsers()
        {
            FindUser user = new FindUser();
            DbUser findUser = new DbUser();
            findUser.TypeId = 1;
            findUser.Username = "roxanne.cuddy";
            Assert.AreNotEqual(0, user.Execute(findUser).Count);
        }

        [Test]
        public void Test_FindUserClass_GetUserIdBySessionIdMethod_Returns_An_Int()
        {
            FindUser user = new FindUser();
            SessionControlCommand cmd = new SessionControlCommand();
            Guid session_id = cmd.SessionStart(1, 3);
            Assert.IsInstanceOf(typeof(string), user.GetUsernameBySessionId(session_id));
        }

        [Test]
        public void Test_FindUserClass_GetUserIdBySessionIdMethod_Returns_Correct_UserId()
        {
            FindUser user = new FindUser();
            SessionControlCommand cmd = new SessionControlCommand();
            Guid session_id = cmd.SessionStart(1, 3);
            Assert.AreEqual("katie.hodgkiss", user.GetUsernameBySessionId(session_id));
        }
    }
}
