using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace FDMJobSystemLogic
{
    public class ViewComments
    {
        public List<DbComments> Execute(int jobId)
        {
            string qry = "SELECT Comment_id, Job_id, User_id, Text, DateAdded FROM Comments WHERE Job_id = " + jobId + " ORDER BY DateAdded ASC";
            IReadCommand cmd = new ReadCommand();
            DataTable dt = cmd.Execute(qry);
            List<DbComments> comments = new List<DbComments>(dt.Rows.Count);

            GetOneUser user = new GetOneUser();

            comments = (from DataRow row in dt.Rows

                          select new DbComments
                          {
                              CommentId = int.Parse(row["COMMENT_ID"].ToString()),
                              JobId = int.Parse(row["JOB_ID"].ToString()),
                              Username = user.Read(int.Parse(row["USER_ID"].ToString())),
                              Text = row["TEXT"].ToString(),
                              DateAdded = DateTime.Parse(row["DATEADDED"].ToString())

                          }).ToList();

            return comments;
        }
    }
}
