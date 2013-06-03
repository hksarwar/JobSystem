using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace FDMJobSystemLogic
{
    public class EditPassword
    {
        public bool Execute(DbUser alteredUser)
        {
            FindUser fuser = new FindUser();
            List<DbUser> userList = fuser.Execute(alteredUser.Username);
            alteredUser.UserId = userList[0].UserId;
            ConnectionString cnString = new ConnectionString();
            IDbConnection cn = new OleDbConnection(cnString.GetConnString());

            IDbCommand cmd = new OleDbCommand("sp_update_password", (OleDbConnection)cn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cn.Open();
                IDbTransaction tran = cn.BeginTransaction();
                cmd.Transaction = tran;

                // Add job
                cmd.Parameters.Add(new OleDbParameter("@userID", alteredUser.UserId));
                cmd.Parameters.Add(new OleDbParameter("@newPass", alteredUser.Password));

                int affectedRows = cmd.ExecuteNonQuery();

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
