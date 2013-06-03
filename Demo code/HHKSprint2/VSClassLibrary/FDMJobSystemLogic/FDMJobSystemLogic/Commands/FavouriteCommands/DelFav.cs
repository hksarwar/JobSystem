using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.OleDb;
using System.Data;

namespace FDMJobSystemLogic
{
    public class DelFav : IWriteCommandFactory<DbUser>
    {
        public bool GetCommand(List<DbUser> user, int job_id)
        {
            ConnectionString cnString = new ConnectionString();
            IDbConnection cn = new OleDbConnection(cnString.GetConnString());
            try
            {
                cn.Open();
                IDbTransaction tran = cn.BeginTransaction();
                IDbCommand cmd = new OleDbCommand("sp_del_favourite", (OleDbConnection)cn);
                cmd.Transaction = tran;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new OleDbParameter("@userId", user[0].UserId));
                cmd.Parameters.Add(new OleDbParameter("@jobId", job_id));
                int affectedRows = cmd.ExecuteNonQuery();
                tran.Commit();
                return true;
            }
            catch (Exception e)
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
