using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDMJobSystemLogic.Commands.JobCommands
{
    public class GetJobID
    {
        public string Read()
        {
            string cmdString = "SELECT job_id_seq.CURRVAL FROM Dual";
            IReadOneCommand cmd = new ReadOneCommand();
            return cmd.Execute(cmdString).ToString();
        }
    }
}
