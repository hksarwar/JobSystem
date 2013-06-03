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
    public class SendEmailTests
    {
        [Test]
        public void Test()
        {
            Guid sessionID = Guid.Parse("9485548e-deee-400e-8ca0-f0d7e87237ad");
            string subject = "Hello";
            string body = "This is a test.";
            string recipientEmail = "hannah.williams@fdmgroup.com";
            List<string> cc = new List<string>();
            string file = "";

            SendEmail email = new SendEmail();
            bool success = email.Execute(sessionID, subject, body, recipientEmail, cc, file);
            Assert.IsTrue(success);
        }
    }
}
