using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.OleDb;

namespace FDMJobSystemLogic
{
    public class WriteProcedureCommand : IWriteProcedureCommand
    {
        public bool Execute(string qry)
        {
            ConnectionString cnString = new ConnectionString();
            IDbConnection cn = new OleDbConnection(cnString.GetConnString());
            IDbCommand cmd = new OleDbCommand(qry, (OleDbConnection)cn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cn.Open();
                IDbTransaction tran = cn.BeginTransaction();
                cmd.Transaction = tran;

                int affectedRows = cmd.ExecuteNonQuery();
                Console.WriteLine(affectedRows);
                if (affectedRows > 0)
                {
                    tran.Commit();
                    return true;
                }
                else
                {
                    tran.Rollback();
                }
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
