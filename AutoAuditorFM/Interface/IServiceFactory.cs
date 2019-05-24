using AutoAuditorFM.Impl.Models;
using LoggerFM.Interface;
using ParsingFM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAuditorFM.Interface
{
    public interface IServiceFactory
    {
        IService Create(Result[] result, ILog logger, IParsing parsing, string name);
    }
}
