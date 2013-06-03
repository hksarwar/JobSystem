using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDMJobSystemLogic
{
    public interface ISearchJob
    {
        List<DbJob> Search(string stream, string status, string location, string company, List<string> skills);
    }
}
