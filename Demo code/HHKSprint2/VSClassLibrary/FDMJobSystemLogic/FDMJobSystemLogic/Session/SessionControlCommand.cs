using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace FDMJobSystemLogic
{
    public class SessionControlCommand : ISessionControlCommand
    {
        public Guid SessionStart(int userId, int typeID)
        {
            // Create the Guid for the session
            Guid g = Guid.NewGuid();

            // Insert session info into database
            try
            {
                string qry = "INSERT INTO SESSIONS (session_id, session_guid, User_id, Type_id) VALUES ( session_id_seq.NEXTVAL, '" + g.ToString() + "', " + userId.ToString() + ", " + typeID.ToString() + ")";
                IWriteCommand cmd = new WriteCommand();

                if (cmd.Execute(qry))
                {
                    return g;
                }
                else
                {
                    return Guid.Empty;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Guid.Empty;
            }
        }

        public DbUser GetUser(Guid sessionId)
        {
            DbUser user = new DbUser();

            List<DbUser> u = new List<DbUser>();

            // Get the user out of the database based on the session id
            try
            {
                string qry = "SELECT FDMUser.user_id, FDMUser.username, FDMUser.password, FDMUser.firstname, FDMUser.lastname, FDMUser.email, FDMUser.type_id, FDMUser.Location FROM FDMUser JOIN SESSIONS ON FDMUser.user_id = Sessions.user_id WHERE session_guid = '" + sessionId.ToString() + "'";
                IReadCommand cmd = new ReadCommand();
                //List<string> u = new List<string>();
                cmd.Execute(qry);



                DataTable dt = cmd.Execute(qry);

                u = (from DataRow row in dt.Rows

                     select new DbUser
                     {
                         UserId = (int)row["USER_ID"],
                         Username = row["USERNAME"].ToString(),
                         Password = row["PASSWORD"].ToString(),
                         FirstName = row ["FIRSTNAME"].ToString(),
                         LastName = row["LASTNAME"].ToString(),
                         Email = row["EMAIL"].ToString(),
                         Location = row["LOCATION"].ToString(),
                         TypeId = (int)row["TYPE_ID"]

                     }).ToList();

                //// Translate into User object
                user = u[0];
                //user.UserId = int.Parse(u[0]);
                //user.Username = u[1];
                ////user.Password = u[2];
                //user.FirstName = u[3];
                //user.LastName = u[4];
                //user.Email = u[5];
                //user.TypeId = int.Parse(u[6]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return user;
        }


        public bool EndSession(Guid sessionId)
        {
            try
            {
                string qry = "DELETE FROM Sessions WHERE session_guid = '" + sessionId.ToString() + "'";
                IWriteCommand cmd = new WriteCommand();
                if (cmd.Execute(qry))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
