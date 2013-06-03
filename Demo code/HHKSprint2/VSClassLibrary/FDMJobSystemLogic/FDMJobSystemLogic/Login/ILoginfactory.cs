using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDMJobSystemLogic
{
    public interface ILoginfactory
    {
        int GetUserID(string username, string password);
    }
}
