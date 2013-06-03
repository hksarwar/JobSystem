using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using FDMJobSystemLogic;

namespace FDMJobSystemLogic
{
    public class LogIn : ILoginfactory
    {
        public int GetUserID(string username, string password)
        {
            string qry = "SELECT user_id FROM FDMUser WHERE username = " + username + " and password = " + password;
            IReadOneCommand cmd = new ReadOneCommand();
            int u = int.Parse(cmd.Execute(qry)[0].ToString());
            return u;
        }
    }
}
