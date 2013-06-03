using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDMJobSystemLogic
{
   public interface IWriteCommandFactory<T>
    {
       bool GetCommand(List<T> obj, int stream_id);
    }
}
