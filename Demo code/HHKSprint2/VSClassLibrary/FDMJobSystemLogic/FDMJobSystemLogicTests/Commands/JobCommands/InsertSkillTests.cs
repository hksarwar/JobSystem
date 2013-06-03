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
    public class InsertSkillTests
    {
        #region DetermineIfExists method tests
        [Test]
        public void TestDetermineIfExistsReturnsFalseWithNonExistingSkill()
        {
            InsertSkill ins = new InsertSkill();
            Assert.IsFalse(ins.DetermineIfExists("prolog"));
        }

        [Test]
        public void TestDetermineIfExistsReturnsTrueWithExistingSkill()
        {
            InsertSkill ins = new InsertSkill();
            Assert.IsTrue(ins.DetermineIfExists("java"));
        }

        #endregion

        #region FormatSkill method tests
        [Test]
        public void TestFormatSkillReturnsCorrectSkillString()
        {
            string skill = "dot net";
            InsertSkill ins = new InsertSkill();
            string newSkill = ins.FormatSkill(skill);
            Assert.AreEqual("Dot Net", newSkill);
        }

        #endregion

        #region GetCommand method tests

        [Test]
        public void TestGetCommandReturnsTrueWithExistingSkill()
        {
            string skill = "SQL";
            InsertSkill ins = new InsertSkill();
            string newSkill = ins.FormatSkill(skill);
            Assert.IsTrue(ins.GetCommand(skill));
        }

        [Test]
        public void TestGetCommandReturnsTrueWithNonExistingSkillAndAddsItToTheDatabase()
        {
            string skill = "python";
            InsertSkill ins = new InsertSkill();
            bool insert = ins.GetCommand(skill);
            Assert.IsTrue(insert);
        }
        #endregion
    }
}
