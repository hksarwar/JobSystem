using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Moq;
using NUnit.Framework;
using FDMJobSystemLogic;

namespace FDMJobSystemLogicTests.Commands.CommentCommands
{
    [TestFixture]
    public class DeleteCommentsTests
    {
        [Test]
        public void TestDeleteCommentWorksWithExistingComment()
        {
            int commentId = 1;
            DeleteComment delComment = new DeleteComment();
            Assert.IsTrue(delComment.GetCommand(commentId));
        }
    }
}
