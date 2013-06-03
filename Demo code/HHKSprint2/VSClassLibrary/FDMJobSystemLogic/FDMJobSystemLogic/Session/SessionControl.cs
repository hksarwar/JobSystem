using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace FDMJobSystemLogic
{
    public class SessionControl : ISessionControlFactory
    {
        public Guid GetSessionID(Guid currentSessionID)
        {
            try
            {
                string qry = "SELECT session_guid FROM Sessions WHERE session_guid = '" + currentSessionID.ToString() + "'";
                IReadCommand cmd = new ReadCommand();

                List<string> u = new List<string>();


                DataTable dt = cmd.Execute(qry);

                u = (from row in dt.AsEnumerable() select Convert.ToString(row["SESSION_GUID"])).ToList();
                Guid g = Guid.Parse(u[0].ToString());
                return g;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Guid.Empty;
            }
        }
    }
}
