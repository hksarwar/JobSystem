using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDMJobSystemLogic
{
   public interface IWriteCommand
    {
      bool Execute(string qry);
      bool Execute();
      void SetCommand(string qry);
    }
}
