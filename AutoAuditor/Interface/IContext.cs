using Parsing.Impl.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAuditor.Interface
{
    public interface IContext
    {
        T Invoke<T>() where T : class, new();
    }
}
