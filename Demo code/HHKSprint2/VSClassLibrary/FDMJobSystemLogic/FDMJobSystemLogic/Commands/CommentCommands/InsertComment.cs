using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace FDMJobSystemLogic
{
    public class InsertComment
    {
        public bool GetCommand(int jobId, Guid sessionId, string commentText)
        {
            ConnectionString cnString = new ConnectionString();
            IDbConnection cn = new OleDbConnection(cnString.GetConnString());

            IDbCommand cmd = new OleDbCommand("sp_add_comment", (OleDbConnection)cn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cn.Open();

                //Get user id
                FindUser find = new FindUser();
                int userId = int.Parse(find.GetUserIDBySessionId(sessionId).ToString());

                cmd.Parameters.Add(new OleDbParameter("@user_id", userId));
                cmd.Parameters.Add(new OleDbParameter("@job_id", jobId));
                cmd.Parameters.Add(new OleDbParameter("@comText", commentText));

                cmd.ExecuteNonQuery();
                return true;

            }
            catch(OleDbException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cn.Close();
            }

            return false;
        }
    }
}
