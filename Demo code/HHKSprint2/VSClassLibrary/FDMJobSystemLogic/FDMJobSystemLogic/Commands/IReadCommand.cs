using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace FDMJobSystemLogic
{
    public interface IReadCommand
    {
        DataTable Execute(string qry);
    }
}
