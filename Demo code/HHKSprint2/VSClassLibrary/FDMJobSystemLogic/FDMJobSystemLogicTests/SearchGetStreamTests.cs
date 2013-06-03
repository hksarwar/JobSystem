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
    public class SearchGetStreamTests
    {
        [Test]
        public void Test_SreachGetStatusClass_ExecuteMethod_Returns_A_List_of_strings()
        {
            SearchGetStream stream = new SearchGetStream();
            Assert.IsInstanceOf(typeof(List<string>), stream.Execute());
        }

        [Test]
        public void Test_SreachGetStatusClass_ExecuteMethod_Returns_A_List_of_size_Seven()
        {
            SearchGetStream stream = new SearchGetStream();
            int result = stream.Execute().Count;
            Assert.AreEqual(7, result);
        }
    }
}
