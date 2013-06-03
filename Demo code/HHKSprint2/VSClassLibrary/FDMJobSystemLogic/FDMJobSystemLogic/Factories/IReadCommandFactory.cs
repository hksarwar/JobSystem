using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDMJobSystemLogic
{
    public interface IReadCommandFactory<T>
    {
        List<T> Execute(T obj);
    }
}
