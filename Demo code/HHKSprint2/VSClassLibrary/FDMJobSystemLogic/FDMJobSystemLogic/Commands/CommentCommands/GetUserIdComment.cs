using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDMJobSystemLogic
{
    public class GetUserIdComment
    {
        public int GetUserIdByCommentId(int commentId)
        {
            string cmdString = "select user_id FROM COMMENTS WHERE comment_id = '" + commentId + "'";
            IReadOneCommand readCmd = new ReadOneCommand();
            int userId = int.Parse(readCmd.Execute(cmdString));
            return userId;
        }
    }
}
