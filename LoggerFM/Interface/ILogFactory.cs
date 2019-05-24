using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerFM.Interface
{
    public interface ILogFactory
    {
        ILog Create();
        ILog Create(string folder);
    }
}
