using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace Test
{
    public interface IWriteCommand
    {
        bool Execute();
    }
}
