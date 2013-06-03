using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDMJobSystemLogic
{
    public class GetOneStream
    {
        public string Read(int streamId)
        {
            string cmdString = "SELECT StreamText FROM Stream WHERE stream_id = '" + streamId + "'";
            IReadOneCommand cmd = new ReadOneCommand();
            return cmd.Execute(cmdString).ToString();
        }
    }
}
