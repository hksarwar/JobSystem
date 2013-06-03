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
    public class UserProfileTests
    {
        [Test]
        public void TestUserProfileGetUserDetailsReturnsTheCorrectUser()
        {
            int userID = 1;
            UserProfile profile = new UserProfile();
            DbUser user = profile.GetUserDetails(userID);
            Assert.AreEqual("Katie", user.FirstName);
        }
    }
}
