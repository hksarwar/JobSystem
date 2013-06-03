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
    public class GetRecsTests
    {
        [Test]
        public void TestRecommendationsReturnsAListOfRecommendationsForTheLoggedInUser()
        {
            Guid sessionID = Guid.Parse("91dd4a1a-cb89-4dd4-b4aa-25432e2457c4");
            GetRecommendations getRecs = new GetRecommendations();
            List<DbRecommendation> recs = getRecs.Execute(sessionID);
            Assert.Greater(recs.Count(), 0);
        }
    }
}
