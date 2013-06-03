using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.OleDb;
using System.Data;

namespace FDMJobSystemLogic
{
    public class DeleteUserSkill
    {
        public bool GetCommand(string skill, int userID)
        {
            ConnectionString cnString = new ConnectionString();
            IDbConnection cn = new OleDbConnection(cnString.GetConnString());

            try
            {
                cn.Open();
                IDbTransaction tran = cn.BeginTransaction();

                // Add userskill
                IDbCommand cmd = new OleDbCommand("sp_del_userSkill", (OleDbConnection)cn);
                cmd.Transaction = tran;
                cmd.CommandType = CommandType.StoredProcedure;

                Console.WriteLine(userID);
                InsertSkill ins = new InsertSkill();
                string formattedSkill = ins.FormatSkill(skill);
                GetSkillId id = new GetSkillId();
                int skillid = int.Parse(id.Read(formattedSkill));
                cmd.Parameters.Add(new OleDbParameter("@userID", int.Parse(userID.ToString())));
                cmd.Parameters.Add(new OleDbParameter("@skillID", int.Parse(skillid.ToString())));
                int affectedRows = cmd.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    tran.Commit();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {

                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
