using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDMJobSystemLogic
{
    public interface ILoginCommand
    {
        Guid VerifyDetails(string username, string password, string type);
        Guid VerifyDetails(string username, string password, string consultant, string trainee);
        void TerminateSession(Guid sessionId);
    }
}
