using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDMJobSystemLogic
{
    public interface ISessionControlCommand
    {
        Guid SessionStart(int userId, int typeID);
        DbUser GetUser(Guid sessionId);
        bool EndSession(Guid sessionId);
    }
}
