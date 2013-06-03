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
    public class EditPasswordTests
    {
        [Test]
        public void Test_EditPasswordClass_ExecuteMethod_Retruns_True_After_Updating_The_Password()
        {
            DbUser user = new DbUser();
            user.Username = "kimberley.jackson";
            user.Password = "hello";
            EditPassword editPass = new EditPassword();
            Assert.IsTrue(editPass.Execute(user));
        }
    }
}
