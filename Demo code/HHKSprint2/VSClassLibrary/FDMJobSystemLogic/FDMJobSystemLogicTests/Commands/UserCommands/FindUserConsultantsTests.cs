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
    public class FindUserConsultantsTests
    {
        [Test]
        public void TestGetConsultantsReturnsAListOfConsultants()
        {
            FindUser find = new FindUser();
            List<DbUser> users = find.GetConsultants("Java");
            Console.WriteLine(users.Count());
            Console.WriteLine(users[0].Username);
            Assert.Greater(users.Count(), 0);
        }
    }
}
