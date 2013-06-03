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
    public class FindUserTests
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
    }
}
