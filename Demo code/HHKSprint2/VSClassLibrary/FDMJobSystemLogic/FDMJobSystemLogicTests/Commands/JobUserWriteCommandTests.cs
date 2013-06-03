using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Moq;
using NUnit.Framework;
using FDMJobSystemLogic;

using System.Data;
using System.Data.OleDb;

namespace FDMJobSystemLogicTests.Commands
{
    [TestFixture]
    public class JobUserWriteCommandTests
    {
        [Test]
        public void Test_JobUserWriteCommand_ExecuteMethod_Returns_A_Bool()
        {
            ConnectionString str = new ConnectionString();
            IDbConnection cn = new OleDbConnection(str.GetConnString());
            IDbDataAdapter da = new OleDbDataAdapter();
            JobUserWriteCommand write = new JobUserWriteCommand(cn, da);
            bool result = write.Execute();
            Assert.IsInstanceOf(typeof(bool), result);

        }
    }
}
