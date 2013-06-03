using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDMJobSystemLogic
{
    public interface IGetOptions
    {
        List<string> GetStatuses();
        List<string> GetStreams();
        List<string> GetTStatuses();
        List<string> GetCompanies();
        List<string> GetLocations();
    }
}
