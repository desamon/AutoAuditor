using Logger.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parsing.Interface
{
    public interface IParsingFactory
    {
        IParsing Create();
        IParsing Create(ILog logger, string referencePath, string filePath);
        IParsing Create(ILog logger, string path);
    }
}
