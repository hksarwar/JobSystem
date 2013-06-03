using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace Test
{
    public class AddJob : WriteCommandFactory, IWriteCommandFactory
    {
        public IWriteCommand GetCommand(List<Job> job, List<string> skill)
        {

            base.command.CommandType = CommandType.StoredProcedure;
            base.command.CommandText = "sp_add_job";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("user_id", job[0].UserId);
            parameters.Add("stream_id", job[0].StreamId);
            parameters.Add("status_id", job[0].StatusId);
            parameters.Add("discription", job[0].Description);
            parameters.Add("title", job[0].Title); 
            parameters.Add("deadline", job[0].Deadline);
            parameters.Add("company", job[0].Company);
            parameters.Add("location", job[0].Location);


            return new WriteCommand(base.connection, base.dataAdapter);
            
            //base.command.CommandText = "INSERT INTO watchlist (company_id,share_holder_id)VALUES(?,?)";
            //Dictionary<string, int> parameters = new Dictionary<string, int>();
            //parameters.Add("@company", id);
            //parameters.Add("@shareholder", shareholder);
            //base.SetParameters(parameters);
            //base.dataAdapter.InsertCommand = base.command;
            //return new WriteCommand(base.connection, base.dataAdapter);
        }
    }
}
