using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using FDMJobSystemLogic;
using System.Data;

namespace FDMJobSystemLogicTests.Commands.JobCommands
{
    [TestFixture]
    public class GetCompanyForAutoFillTests
    {
        [Test]
        public void Test_GetCompanyForAutoFillClass_ExecuteMethod_Returns_A_DataTable()
        {
            GetCompanyForAutoFill comp = new GetCompanyForAutoFill();
            Assert.IsInstanceOf(typeof(List<string>), comp.Execute());
        }

        [Test]
        public void Test_GetCompanyForAutoFillClass_ExecuteMethod_Doesnot_return_An_Empty_DataTable()
        {
            GetCompanyForAutoFill comp = new GetCompanyForAutoFill();
            //Console.WriteLine(comp.Execute().Count);
            Assert.NotNull(comp.Execute());
        }
    }
}
