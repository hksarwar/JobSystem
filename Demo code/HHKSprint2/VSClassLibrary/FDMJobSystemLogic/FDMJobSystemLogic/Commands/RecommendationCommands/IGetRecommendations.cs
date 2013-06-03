using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDMJobSystemLogic
{
    public interface IGetRecommendations
    {
        List<DbRecommendation> Execute(Guid sessionID);
    }
}
