using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    public class InsertWatchListFactory : WriteCommandFactory, IWriteCommandFactory
    {
        public IWriteCommand GetCommand(int id, int shareholder)
        {
            base.command.CommandText = "INSERT INTO watchlist (company_id,share_holder_id)VALUES(?,?)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@company", id);
            parameters.Add("@shareholder", shareholder);
            base.SetParameters(parameters);
            base.dataAdapter.InsertCommand = base.command;
            return new WriteCommand(base.connection, base.dataAdapter);
        }
    }
}
