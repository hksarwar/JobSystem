using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.OleDb;

namespace Test
{
    public abstract class WriteCommandFactory : CommandFactory
    {

        OleDbCommand cmd = new OleDbCommand();

        protected OleDbCommand command
        {
            get { cmd.Connection = base.connection; return cmd; }
        }


        protected void SetParameters(Dictionary<string, object> parameters)
        {
            foreach (var x in parameters)
            {
                OleDbParameter p = new OleDbParameter(x.Key, x.Value);
                cmd.Parameters.Add(p);
            }
        }

    }
}
