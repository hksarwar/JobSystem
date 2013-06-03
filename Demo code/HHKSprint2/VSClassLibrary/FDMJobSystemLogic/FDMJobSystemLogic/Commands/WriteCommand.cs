using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.OleDb;
using System.Data;

namespace FDMJobSystemLogic
{
   public class WriteCommand : IWriteCommand
    {
        ConnectionString cnString = new ConnectionString();
        IDbConnection cn;// = new OleDbConnection(cnString.GetConnString());
        IDbCommand cmd;// = new OleDbCommand(qry, (OleDbConnection)cn);

        public void SetCommand(string qry)
        {
            cn = new OleDbConnection(cnString.GetConnString());
            cmd = new OleDbCommand(qry, (OleDbConnection)cn);
            cmd.CommandType = CommandType.StoredProcedure;
        }

        public bool Execute()
        {
            try
            {
                cn.Open();

                IDbTransaction tran = cn.BeginTransaction();
                cmd.Transaction = tran;

                int affectedRows = cmd.ExecuteNonQuery();
                Console.WriteLine("Executed non Qurey");
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

        public bool Execute(string qry)
        {
            cn = new OleDbConnection(cnString.GetConnString());
            cmd = new OleDbCommand(qry, (OleDbConnection)cn);
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
