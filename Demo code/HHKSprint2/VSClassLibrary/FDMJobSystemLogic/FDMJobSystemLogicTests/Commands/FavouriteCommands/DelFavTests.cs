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
    public class DelFavTests
    {
        [Test]
        public void Test_DelFavClass_GetCommandMethod_Returns_A_bool()
        {
            int job_id = 1;
            DbUser user = new DbUser();
            user.UserId = 1;
            List<DbUser> userList = new List<DbUser>();
            userList.Add(user);

            DelFav fav = new DelFav();
            bool result =  fav.GetCommand(userList, job_id);
            Assert.IsInstanceOf(typeof(bool), result);
        }

        [Test]
        public void Test_DelFavClass_GetCommandMethod_Returns_True_When_JobId_Exists()
        {
            int job_id = 1;
            DbUser user = new DbUser();
            user.UserId = 1;
            List<DbUser> userList = new List<DbUser>();
            userList.Add(user);

            DelFav fav = new DelFav();
            bool result = fav.GetCommand(userList, job_id);
            Assert.IsTrue(result);
        }
    }
}
