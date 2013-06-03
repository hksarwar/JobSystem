using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.OleDb;
using System.Data;

namespace FDMJobSystemLogic
{
    public class ReadOneCommand : IReadOneCommand
    {
        public string Execute(string qry)
        {
            ConnectionString cnString = new ConnectionString();
            IDbConnection cn = new OleDbConnection(cnString.GetConnString());
            IDbCommand cmd = new OleDbCommand(qry, (OleDbConnection)cn);
           
            try
            {
                // open the connection
                cn.Open();
                // execute the query
                // read the data into a data reader
                string id = cmd.ExecuteScalar().ToString();
                return id;
            }
            catch (Exception)
            {
            }
            finally
            {
                cn.Close();
            }
            return "0";
        }
    }
}
