using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDMJobSystemLogic
{
    public class EmailAccountManager
    {
        public bool Execute(Guid sessionID, string recipientEmail)
        {
            try
            {
                // Get userEmail
                string qry = "SELECT email FROM FDMUSER JOIN SESSIONS ON FDMUSER.user_id = SESSIONS.user_id WHERE session_guid = '" + sessionID.ToString() + "'";
                ReadOneCommand cmd = new ReadOneCommand();
                string userEmail = cmd.Execute(qry);

                DbEmail email = new DbEmail();
                email.Sender = userEmail;
                email.Recipient = recipientEmail;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
