using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    public interface IWriteCommandFactory
    {
        IWriteCommand GetCommand(List<Job> job);
    }
}
