using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDMJobSystemLogic
{
    public interface IReadOneCommand
    {
        string Execute(string qry);
    }
}
