using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.OleDb;

namespace Test
{
    public class WriteCommand : Command, IWriteCommand
    {

        public WriteCommand(IDbConnection cn, IDbDataAdapter da)
        {
            base.cn = cn;
            base.da = da;
        }

        public bool Execute()
        {

            try
            {
                cn.Open();
                if (da.InsertCommand != null)
                {
                    da.InsertCommand.ExecuteNonQuery();
                }
                else if (da.DeleteCommand != null)
                {
                    da.DeleteCommand.ExecuteNonQuery();
                }
                else if (da.UpdateCommand != null)
                {
                    da.UpdateCommand.ExecuteNonQuery();
                }
                
                return true;
            }
            catch(OleDbException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                cn.Close();
            }
        }

    }
}
