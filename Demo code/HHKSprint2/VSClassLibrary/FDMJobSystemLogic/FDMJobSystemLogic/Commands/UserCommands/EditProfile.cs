using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.OleDb;
using System.Data;

namespace FDMJobSystemLogic
{
    public class EditProfile
    {
        public bool Execute(DbUser alteredUser)
        {
            // update user details
            GetStreamID id = new GetStreamID();
            string stream_id = id.Read(alteredUser.Stream);

            GetTStatusID id2 = new GetTStatusID();
            string tstatus_id = id2.Read(alteredUser.TStatus);


            ConnectionString cnString = new ConnectionString();
            IDbConnection cn = new OleDbConnection(cnString.GetConnString());

            IDbCommand cmd = new OleDbCommand("sp_update_profile", (OleDbConnection)cn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cn.Open();
                IDbTransaction tran = cn.BeginTransaction();
                cmd.Transaction = tran;

                // Add job
                cmd.Parameters.Add(new OleDbParameter("@userLocation", alteredUser.Location));
                cmd.Parameters.Add(new OleDbParameter("@userID", alteredUser.UserId));
                cmd.Parameters.Add(new OleDbParameter("@userStream", stream_id));
                cmd.Parameters.Add(new OleDbParameter("@tstatID", tstatus_id));
                cmd.Parameters.Add(new OleDbParameter("@userDegree", alteredUser.Degree));
                cmd.Parameters.Add(new OleDbParameter("@userModules", alteredUser.Modules));

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
