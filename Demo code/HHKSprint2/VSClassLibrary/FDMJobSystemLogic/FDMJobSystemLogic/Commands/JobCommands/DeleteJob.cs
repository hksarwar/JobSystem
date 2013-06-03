using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.OleDb;
using System.Data;

namespace FDMJobSystemLogic
{
    public class DeleteJob : IWriteCommandFactory<DbJob>
    {
        public bool GetCommand(List<DbJob> obj, int stream_id)
        {
            ConnectionString cnString = new ConnectionString();
            IDbConnection cn = new OleDbConnection(cnString.GetConnString());
            InsertJob insJob = new InsertJob();
            try
            {
                cn.Open();
                IDbTransaction tran = cn.BeginTransaction();
                IDbCommand cmd = new OleDbCommand("sp_del_job", (OleDbConnection)cn);
                cmd.Transaction = tran;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new OleDbParameter("@jobId", obj[0].JobId));
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
