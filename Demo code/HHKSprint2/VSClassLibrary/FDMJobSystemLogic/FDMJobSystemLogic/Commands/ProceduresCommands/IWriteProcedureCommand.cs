using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDMJobSystemLogic
{
   public interface IWriteProcedureCommand
    {
        bool Execute(string qry);
    }
}
