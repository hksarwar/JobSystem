using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDMJobSystemLogic
{
    public interface ISearch
    {
        List<DbUser> Search(string stream, string status, List<string> skills);
    }
}
