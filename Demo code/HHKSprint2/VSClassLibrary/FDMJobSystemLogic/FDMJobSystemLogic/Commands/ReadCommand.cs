using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.OleDb;
using System.Data;

namespace FDMJobSystemLogic
{
    public class ReadCommand : IReadCommand
    {
        //public List<string> Execute(string qry)
        //{
        //    ConnectionString cnString = new ConnectionString();
        //    IDbConnection cn = new OleDbConnection(cnString.GetConnString());
        //    IDbCommand cmd = new OleDbCommand(qry, (OleDbConnection)cn);
        //    List<string> contents = new List<string>();

        //    try
        //    {
        //        // open the connection
        //        cn.Open();
        //        // execute the query
        //        // read the data into a data reader
        //        IDataReader rdr = cmd.ExecuteReader();


        //        while (rdr.Read())
        //        {
        //            for (int i = 0; i < rdr.FieldCount; i++)
        //            {
        //                contents.Add(rdr[i].ToString());
        //            }
        //        }
        //        return contents;
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    finally
        //    {
        //        cn.Close();
        //    }
        //        return contents;
        //}

        public DataTable Execute(string qry)
        {
            ConnectionString cnString = new ConnectionString();
            IDbConnection cn = new OleDbConnection(cnString.GetConnString());
            IDbCommand cmd = new OleDbCommand(qry, (OleDbConnection)cn);
            //List<DbUser> contents = new List<DbUser>();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter((OleDbCommand)cmd);

            try
            {
                // open the connection
                cn.Open();
                da.Fill(dt);
                
                //contents = (from DataRow row in dt.Rows

                //                select new DbUser
                //                {
                //                    UserId = (int)row["SHARE_HOLDER_ID"],
                //                    FirstName = row["FIRST_NAME"].ToString(),
                //                    LastName = row["LAST_NAME"].ToString()

                //                }).ToList();
            }
            catch (Exception)
            {
            }
            finally
            {
                cn.Close();
            }
            return dt;
        }

    }
}
