using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDMJobSystemLogic
{
    public class GetOneUser
    {
        public string Read(int userId)
        {
            string cmdString = "SELECT SUBSTR(firstname||' '||lastname,0,30) FROM FDMUser WHERE user_id = '" + userId + "'";
            IReadOneCommand cmd = new ReadOneCommand();
            return cmd.Execute(cmdString).ToString();
        }
    }
}
