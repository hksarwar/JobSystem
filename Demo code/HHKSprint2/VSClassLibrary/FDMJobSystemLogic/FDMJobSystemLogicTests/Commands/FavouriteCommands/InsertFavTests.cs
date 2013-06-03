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
    public class InsertFavTests
    {
        [Test]
        public void Test_InsertFavClass_GetCommandMethod_Retruns_A_bool()
        {
            int job_id = 1;
            DbUser user = new DbUser();
            user.UserId = 1;
            List<DbUser> userList = new List<DbUser>();
            userList.Add(user);
            InserFav fav = new InserFav();

            bool result = fav.GetCommand(userList, job_id);
            Assert.IsInstanceOf(typeof(bool), result);
        }
    }
}
