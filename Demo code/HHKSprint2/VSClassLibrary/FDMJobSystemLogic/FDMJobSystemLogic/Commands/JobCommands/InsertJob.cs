using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.OleDb;
using System.Data;

namespace FDMJobSystemLogic
{
    public class InsertJob //: IWriteCommandFactory<DbJob>
    {
        public bool GetCommand(DbJob job, List<string> skills, Guid sessionID)
        {
            //string cmdString = "sp_add_job(" + job[0].UserId + ",'" + job[0].StreamId + "','" +
            //                       job[0].StatusId + "','" + job[0].Description + "','" +
            //                       job[0].Title + "','" + job[0].Deadline + "','" +
            //                       job[0].Company + "'," + job[0].Location + ")";
            //IWriteCommand cmd = new WriteCommand();
            //cmd.SetCommand(cmdString);

            //if (cmd.Execute())
            //{
            //    return true;
            //}
            //return false;

            ConnectionString cnString = new ConnectionString();
            IDbConnection cn = new OleDbConnection(cnString.GetConnString());

            IDbCommand cmd = new OleDbCommand("sp_add_job", (OleDbConnection)cn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cn.Open();
                IDbTransaction tran = cn.BeginTransaction();
                cmd.Transaction = tran;

                // Get IDs
                GetStatusID statusid = new GetStatusID();
                int status_ID = int.Parse(statusid.Read(job.Status));

                GetStreamID streamid = new GetStreamID();
                int stream_ID = int.Parse(streamid.Read(job.Stream));

                FindUser find = new FindUser();
                int userId = int.Parse(find.GetUserIDBySessionId(sessionID).ToString());

                // Add job
                cmd.Parameters.Add(new OleDbParameter("@user_id", userId));
                cmd.Parameters.Add(new OleDbParameter("@stream_id", stream_ID));
                cmd.Parameters.Add(new OleDbParameter("@status_id", status_ID));
                cmd.Parameters.Add(new OleDbParameter("@description", job.Description));
                cmd.Parameters.Add(new OleDbParameter("@title", job.Title));
                cmd.Parameters.Add(new OleDbParameter("@deadline", job.Deadline));
                cmd.Parameters.Add(new OleDbParameter("@company", job.Company));
                cmd.Parameters.Add(new OleDbParameter("@location", job.Location));

                int affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    // Add jobskills
                    for (int i = 0; i < skills.Count(); i++)
                    {
                        IDbCommand cmd2 = new OleDbCommand("sp_add_jobSkill", (OleDbConnection)cn);
                        cmd2.Transaction = tran;
                        cmd2.CommandType = CommandType.StoredProcedure;

                        string formattedSkill = FormatSkill(skills[i]);
                        GetSkillId id = new GetSkillId();
                        int skillid = int.Parse(id.Read(formattedSkill));
                        cmd2.Parameters.Add(new OleDbParameter("@skill_id", int.Parse(skillid.ToString())));
                        affectedRows = affectedRows + cmd2.ExecuteNonQuery();
                    }
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

        public string FormatSkill(string skill)
        {
            string[] splitSkill = skill.Split();
            string newSkill = "";
            for (int i = 0; i < splitSkill.Count(); i++)
            {
                char letter = char.ToUpper(splitSkill[i][0]);
                string word = letter + splitSkill[i].Substring(1);
                if (i > 0)
                {
                    newSkill = newSkill + " " + word;
                }
                else
                {
                    newSkill = newSkill + word;
                }
            }
            return newSkill;
        }
    }
}
