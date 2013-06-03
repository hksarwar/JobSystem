using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.OleDb;
using System.Data;

namespace FDMJobSystemLogic
{
    public class InsertSkill  // not really needed anymore as have stored procedure
    {
        public bool GetCommand(string skill)
        {
            //IWriteCommand cmd = new WriteCommand();
            //string qry = "INSERT INTO Skill (skill_id, skilltext) VALUES (skill_id_seq.nextval, '" + skill + "')";
            //if (cmd.Execute(qry) == true)
            //{
            //    return true;
            //}
            //return false;

            string formattedSkill = FormatSkill(skill);
            
            // if exists do nothing
            if (DetermineIfExists(formattedSkill))
            {
                Console.WriteLine(formattedSkill);
                return true;
            }
            // else add the skill to the database
            else
            {
                ConnectionString cnString = new ConnectionString();
                IDbConnection cn = new OleDbConnection(cnString.GetConnString());

                try
                {
                    cn.Open();
                    IDbTransaction tran = cn.BeginTransaction();

                    // Add skill
                    int affectedRows = 0;

                    IDbCommand cmd = new OleDbCommand("sp_add_skill", (OleDbConnection)cn);
                    cmd.Transaction = tran;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OleDbParameter("@skilltxt", formattedSkill));
                    affectedRows = cmd.ExecuteNonQuery();


                    if (affectedRows > 0)
                    {
                        tran.Commit();
                        return true;
                    }
                    else
                    {
                        tran.Rollback();
                        return false;
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

        public bool DetermineIfExists(string skill)
        {
            string cmdString = "SELECT skill_id FROM Skill WHERE upper(SkillText) = '" + skill.ToUpper() + "'";
            IReadOneCommand cmd = new ReadOneCommand();
            string id = cmd.Execute(cmdString);
            if (id == "0")
            {
                // does not exist
                return false;
            }
            return true;
        }

        public string FormatSkill(string skill)
        {
            string[] splitSkill = skill.Split();
            string newSkill = "";
            for (int i = 0; i < splitSkill.Count(); i++)
            {
                for (int j = 0; j < splitSkill[i].Count(); j++)
                {
                    // find first letter in word and capitalise it
                    if (char.IsLetter(splitSkill[i][j]))
                    {
                        char letter = char.ToUpper(splitSkill[i][j]);
                        string word = letter + splitSkill[i].Substring(1);

                        // Concatenate the words together to re-form the skill
                        if (i > 0)
                        {
                            // if it isnt the first word
                            newSkill = newSkill + " " + word;
                        }
                        else
                        {
                            // if it is the first word - no space
                            newSkill = newSkill + word;
                        }
                        break;
                    }
                    else
                    {
                        j = j + 1;

                    }
                }
            }
            return newSkill;
        }
    }
}
