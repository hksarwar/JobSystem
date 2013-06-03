using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.OleDb;
using System.Data;

namespace FDMJobSystemLogic
{
    public class InserFav : IWriteCommandFactory<DbUser>
    {
        public bool GetCommand(List<DbUser> obj, int job_id)
        {
            if (DetermineIfExists(obj[0].UserId, job_id))
            {
                //Console.WriteLine(formattedSkill);
                return true;
            }
            else
            {
                ConnectionString cnString = new ConnectionString();
                IDbConnection cn = new OleDbConnection(cnString.GetConnString());

                IDbCommand cmd = new OleDbCommand("sp_add_favourite", (OleDbConnection)cn);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    cn.Open();
                    IDbTransaction tran = cn.BeginTransaction();
                    cmd.Transaction = tran;

                    cmd.Parameters.Add(new OleDbParameter("@userId", obj[0].UserId));
                    cmd.Parameters.Add(new OleDbParameter("@jobId", job_id));

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
                    return false;
                }
                finally
                {
                    cn.Close();
                }
                return true;
            }
        }

        public bool DetermineIfExists(int user_id, int job_id)
        {
            string cmdString = "SELECT fav_id FROM FAVOURITE WHERE  FAVOURITE.user_id= " + user_id +
                                 "AND FAVOURITE.Job_id =" + job_id;
            IReadOneCommand cmd = new ReadOneCommand();
            string id = cmd.Execute(cmdString);
            if (id == "0")
            {
                // does not exist
                return false;
            }
            return true;
        }
    }
}
