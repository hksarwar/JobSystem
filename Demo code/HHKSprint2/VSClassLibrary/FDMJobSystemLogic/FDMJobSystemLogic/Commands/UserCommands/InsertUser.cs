using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDMJobSystemLogic
{
    public class InsertUser : IWriteCommandFactory<DbUser>// WriteCommandFactory, 
    {
        public bool GetCommand(List<DbUser> user, int stream_id)
        {
            string cmdString = "sp_add_user(" + user[0].TypeId + ",'" + user[0].Username + "','" +
                                   user[0].Password + "','" +
                                   user[0].FirstName + "','" + user[0].LastName + "','" + user[0].Email + "','" +
                                   user[0].Location + "'," + stream_id + ")";
            IWriteCommand cmd = new WriteCommand();
            cmd.SetCommand(cmdString);
            
            if (cmd.Execute())
            {
                return true;
            }
            return false;
        }
        
    }
}
