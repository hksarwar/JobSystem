using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.OleDb;
using System.Data;

namespace FDMJobSystemLogic
{
    public class UpdateJob : IWriteCommandFactory<DbJob>
    {

        public bool GetCommand(List<DbJob> obj, int stream_id)
        {
            string cmdString = "UPDATE JOBPOST SET jobpost.user_id =" + obj[0].UserId 
                                + " WHERE jobpost.job_id = " + obj[0].JobId;
            IWriteCommand cmd = new WriteCommand();

            if (cmd.Execute(cmdString))
            {
                return true;
            }
            return false;
        }

        public bool GetCommand(List<DbJob> obj)
        {
            ConnectionString cnString = new ConnectionString();
            IDbConnection cn = new OleDbConnection(cnString.GetConnString());

            IDbCommand cmd = new OleDbCommand("sp_update_job", (OleDbConnection)cn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cn.Open();
                IDbTransaction tran = cn.BeginTransaction();
                cmd.Transaction = tran;

                // Get IDs
                GetStatusID statusid = new GetStatusID();
                int status_ID = int.Parse(statusid.Read(obj[0].Status));

                GetStreamID streamid = new GetStreamID();
                int stream_ID = int.Parse(streamid.Read(obj[0].Stream));

                // Add job
                cmd.Parameters.Add(new OleDbParameter("@jobId", obj[0].JobId));
                cmd.Parameters.Add(new OleDbParameter("@streamId", stream_ID));
                cmd.Parameters.Add(new OleDbParameter("@statusId", status_ID));
                cmd.Parameters.Add(new OleDbParameter("@descr", obj[0].Description));
                cmd.Parameters.Add(new OleDbParameter("@jTitle", obj[0].Title));
                cmd.Parameters.Add(new OleDbParameter("@ddline", obj[0].Deadline));
                cmd.Parameters.Add(new OleDbParameter("@comp", obj[0].Company));
                cmd.Parameters.Add(new OleDbParameter("@loc", obj[0].Location));

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

        public bool GetCommand(List<DbJob> job, List<string> deletedSkills)
        {
            ConnectionString cnString = new ConnectionString();
            IDbConnection cn = new OleDbConnection(cnString.GetConnString());
            InsertJob insJob = new InsertJob();
            try
            {
                cn.Open();
                IDbTransaction tran = cn.BeginTransaction();
                IDbCommand cmd = new OleDbCommand("sp_del_jobskill", (OleDbConnection)cn);
                cmd.Transaction = tran;
                cmd.CommandType = CommandType.StoredProcedure;

                for (int j = 0; j < deletedSkills.Count(); j++)
                {
                    string formattedSkill = insJob.FormatSkill(deletedSkills[j]);
                    GetSkillId id = new GetSkillId();
                    int delskillid = int.Parse(id.Read(formattedSkill));

                    cmd.Parameters.Add(new OleDbParameter("@jobId", job[0].JobId));
                    cmd.Parameters.Add(new OleDbParameter("@delSkillId", delskillid));
                    int affectedRows = cmd.ExecuteNonQuery();
                }
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

        public bool addNewSkills(int job_id, List<string> newlyAddedSkills)
        {
            ConnectionString cnString = new ConnectionString();
            IDbConnection cn = new OleDbConnection(cnString.GetConnString());

            IDbCommand cmd = new OleDbCommand("sp_update_jobskill", (OleDbConnection)cn);
            cmd.CommandType = CommandType.StoredProcedure;

            InsertJob insJob = new InsertJob();

            for (int i = 0; i < newlyAddedSkills.Count(); i++)
            {

                string formattednewSkill = insJob.FormatSkill(newlyAddedSkills[i]);
                GetSkillId newId = new GetSkillId();
                int addedskillid = int.Parse(newId.Read(formattednewSkill));

                try
                {
                    cn.Open();
                    IDbTransaction tran = cn.BeginTransaction();
                    cmd.Transaction = tran;

                    cmd.Parameters.Add(new OleDbParameter("@jobId", job_id));
                    cmd.Parameters.Add(new OleDbParameter("@addedSkillId", addedskillid));

                    int affectedRows = cmd.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        //    // Add jobskills
                        //    for (int i = 0; i < skills.Count(); i++)
                        //    {
                        //        IDbCommand cmd2 = new OleDbCommand("sp_add_jobSkill", (OleDbConnection)cn);
                        //        cmd2.Transaction = tran;
                        //        cmd2.CommandType = CommandType.StoredProcedure;

                        //        string formattedSkill = FormatSkill(skills[i]);
                        //        GetSkillId id = new GetSkillId();
                        //        int skillid = int.Parse(id.Read(formattedSkill));
                        //        cmd2.Parameters.Add(new OleDbParameter("@skill_id", int.Parse(skillid.ToString())));
                        //        affectedRows = affectedRows + cmd2.ExecuteNonQuery();
                        //    }
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
            }
            return false;
        }
    }
}
