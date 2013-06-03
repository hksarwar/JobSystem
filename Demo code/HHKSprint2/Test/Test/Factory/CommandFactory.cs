using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.OleDb;

namespace Test
{
    public abstract class CommandFactory
    {

        string cnString = @"Provider = OraOLEDB.Oracle; OLEDBNet=True; PLSQLRSet=true; Data Source = (DESCRIPTION = (CID = GTU_APP)(ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = oracle.fdmgroup.com)(PORT = 1521)))(CONNECT_DATA = (SID = XE)(SERVER = DEDICATED))); User Id = hannahwilliams; Password = Eddies230686;";
        private OleDbConnection cn = new OleDbConnection();
        private OleDbDataAdapter da = new OleDbDataAdapter();

        protected OleDbConnection connection 
        {
            get { cn.ConnectionString = cnString; return cn; }
        }
        protected OleDbDataAdapter dataAdapter 
        {
            get { return da;}
        }
    }
}
