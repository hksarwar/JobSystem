using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.OleDb;

namespace FDMJobSystemLogic
{
    public class DeleteComment
    {
        public bool GetCommand(int commentId)
        {
            ConnectionString cnString = new ConnectionString();
            IDbConnection cn = new OleDbConnection(cnString.GetConnString());

            IDbCommand cmd = new OleDbCommand("sp_delete_comment", (OleDbConnection)cn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cn.Open();

                cmd.Parameters.Add(new OleDbParameter("@comment_id", commentId));

                cmd.ExecuteNonQuery();
                return true;

            }
            catch (OleDbException e)
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
