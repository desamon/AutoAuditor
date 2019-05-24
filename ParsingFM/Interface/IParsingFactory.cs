using LoggerFM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingFM.Interface
{
    public interface IParsingFactory
    {
        IParsing Create();
        IParsing Create(ILog logger, string referencePath, string filePath);
        IParsing Create(ILog logger, string path);
    }
}
