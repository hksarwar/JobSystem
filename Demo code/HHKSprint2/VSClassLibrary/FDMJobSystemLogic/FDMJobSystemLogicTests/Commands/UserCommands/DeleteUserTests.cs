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
    public class DeleteUserTests
    {
        DeleteUser delUser;
        List<DbUser> user;

        [Test]
        public void Test_DeleteUserClass_GetCommandMethod_Returns_A_Bool()
        {
            Initialiser();
            bool result = delUser.GetCommand(user, 2);
            Assert.IsInstanceOf(typeof(bool), result);
        }

        [Test]
        public void Test_DeletetUserClass_GetCommandMethod_Returns_True_With_Valid_UserDetails()
        {
            Initialiser();
            bool result = delUser.GetCommand(user, 2);
            Assert.IsTrue(result);
        }

        [Test]
        public void Test_DeleteUserClass_CheckJobExistsMethod_Returns_A_Listof_Jobs()
        {
            Assert.IsInstanceOf(typeof(List<DbJob>), delUser.CheckJobExists("roxanne.cuddy"));
        }

        [Test]
        public void Test_DeleteUserClass_CheckJobExistsMethod_Returns_Zero_for_Any_User_Except_AccountManger()
        {
            Assert.AreEqual(0, delUser.CheckJobExists("hinnah.sarwar").Count);
        }

        [Test]
        public void Test_DeleteUserClass_CheckJobExistsMethod_Returns_GreaterThan_Zero_for_Any_User_Having_JobPosts()
        {
            Assert.AreNotEqual(0, delUser.CheckJobExists("roxanne.cuddy"));
        }

        private void Initialiser()
        {

            delUser = new DeleteUser();
            user = new List<DbUser>();
            user.Add(new DbUser());
            user[0].Username = "hinnah.sarwar";
            //user[0].Password = "password";
            //user[0].FirstName = "Thomas";
            //user[0].LastName = "Shore";
            //user[0].Email = "thomas.shore@fdmgroup.com";
            //user[0].Location = "Manchester";
            //user[0].TypeId = 3;
            //user.Add(new DbUser());
        }
    }
}
