using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.OleDb;
using System.Data;

namespace FDMJobSystemLogic
{
    public class InsertRecommendation //: IWriteCommandFactory<DbUser>
    {
        public bool GetCommand(int recommender_id, int recommended_id, int job_id, string reason)
        {
            if (DetermineIfExists(recommender_id, recommended_id, job_id))
            {
                return true;
            }
            else
            {
                ConnectionString cnString = new ConnectionString();
                IDbConnection cn = new OleDbConnection(cnString.GetConnString());

                IDbCommand cmd = new OleDbCommand("sp_add_recommendation", (OleDbConnection)cn);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    cn.Open();
                    IDbTransaction tran = cn.BeginTransaction();
                    cmd.Transaction = tran;

                    cmd.Parameters.Add(new OleDbParameter("@userId", recommender_id));
                    cmd.Parameters.Add(new OleDbParameter("@user_Id", recommended_id));
                    cmd.Parameters.Add(new OleDbParameter("@jobId", job_id));
                    cmd.Parameters.Add(new OleDbParameter("@reason", reason));

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

        public bool DetermineIfExists(int recommender_id, int recommended_id, int job_id)
        {
            string cmdString = "SELECT recommendation_id FROM RECOMMENDATIONS WHERE RECOMMENDATIONS.recomender_id= " + recommender_id + "AND RECOMMENDATIONS.Job_id =" + job_id + " AND RECOMMENDATIONS.recomendee_id= " + recommended_id;
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
