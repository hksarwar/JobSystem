using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace Test
{
    public abstract class Command
    {

        protected IDbConnection cn;

        protected IDbDataAdapter da;

    }
}
