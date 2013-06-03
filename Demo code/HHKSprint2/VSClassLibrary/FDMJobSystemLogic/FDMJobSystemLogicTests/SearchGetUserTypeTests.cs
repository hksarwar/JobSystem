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
    public class SearchGetUserTypeTests
    {
        [Test]
        public void Test_SreachGetStatusClass_ExecuteMethod_Returns_A_List_of_strings()
        {
            SearchGetUserType userType = new SearchGetUserType();
            Assert.IsInstanceOf(typeof(List<string>), userType.Execute());
        }

        [Test]
        public void Test_SreachGetStatusClass_ExecuteMethod_Returns_A_List_of_sise_Five()
        {
            SearchGetUserType userType = new SearchGetUserType();
            int result = userType.Execute().Count;
            Assert.AreEqual(5, result);
        }
    }
}
