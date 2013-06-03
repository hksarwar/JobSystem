using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDMJobSystemLogic
{
    public class GetStreamID
    {
        public string Read(string stream)
        {
            string cmdString = "SELECT stream_id FROM Stream WHERE StreamText = '" + stream + "'";
            IReadOneCommand cmd = new ReadOneCommand();
            return cmd.Execute(cmdString).ToString();
        }
    }
}
