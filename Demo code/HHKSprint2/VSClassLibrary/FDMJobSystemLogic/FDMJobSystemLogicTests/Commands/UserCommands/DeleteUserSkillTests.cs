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
    public class DeleteUserSkillTests
    {
        [Test]
        public void TestGetCommandMethodReturnsTrueWhenDeletingUserSkillFromDatabase()
        {
            string skill = "SQL";
            int userID = 3;
            DeleteUserSkill del = new DeleteUserSkill();
            bool result = del.GetCommand(skill, userID);
            Assert.IsTrue(result);
        }

        [Test]
        public void TestGetCommandMethodReturnsTrueWhenAddingUserSkillToDatabase()
        {
            string skill = "SQL";
            int userID = 3;
            InsertUserSkill ins = new InsertUserSkill();
            bool result = ins.GetCommand(skill, userID);
            Assert.IsTrue(result);
        }


    }
}
