using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using FDMJobSystemLogic;

namespace FDMJobSystemLogicTests.Commands.UserCommands
{
    [TestFixture]
    public  class ForgottenPasswordTests
    {
        [Test]
        public void Test_ForgottenPasswordClass_EmailPasswordMethod_Retruns_true_For_Valid_Username()
        {
            ForgottenPassword pswd = new ForgottenPassword();
            Assert.IsTrue(pswd.EmailPassword("kimberley.jackson"));
        }
    }
}
