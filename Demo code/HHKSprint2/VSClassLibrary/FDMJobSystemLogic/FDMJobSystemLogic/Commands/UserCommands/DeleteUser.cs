using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDMJobSystemLogic
{
    public class DeleteUser : IWriteCommandFactory<DbUser>
    {
        public List<DbJob> CheckJobExists(string username)
        {
            FindUser tempUser = new FindUser();
            DbUser deluser = new DbUser();
            DbJob job = new DbJob();
            MyJobs jobs = new MyJobs();
            List<DbJob> jobcount = new List<DbJob>();
            try
            {
                deluser = tempUser.GetUserByUsername(username);
                if (deluser.TypeId == 1)
                {
                    job.UserId = deluser.UserId;
                    jobcount = jobs.Execute(job);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return jobcount;
        }

        public bool GetCommand(List<DbUser> user, int stream_id)
        {
            FindUser tempUser = new FindUser();
            IWriteCommand cmd = new WriteCommand();
            DbUser deluser = new DbUser();
            bool result = false;
            try
            {
                string username = user[0].Username;
                deluser = tempUser.GetUserByUsername(username);
                if (deluser.UserId == 0)
                {
                    return result;
                }
                else
                {
                    string cmdString = "sp_del_user_and_constraints(" + deluser.UserId + ")";
                    cmd.SetCommand(cmdString);

                    if (cmd.Execute())
                    {
                        Console.WriteLine(cmdString);
                        result = true;
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }
    }
}
