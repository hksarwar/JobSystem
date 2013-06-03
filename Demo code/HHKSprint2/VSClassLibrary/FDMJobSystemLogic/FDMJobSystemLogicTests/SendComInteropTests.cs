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
    public class SendComInteropTests
    {
        [Test]
        public void TestSendMailSendsAnEmail()
        {
            DbEmail testMail = new DbEmail();
            testMail.Sender = "kimberley.jackson@fdmgroup.com";
            testMail.Recipient = "hinnah.sarwar@fdmgroup.com";
            testMail.Subject = "hi hinnah";
            testMail.Body = "test";
            SendComInteropEmail email = new SendComInteropEmail();
            Assert.IsTrue(email.SendMail(testMail));
        }
    }
}
