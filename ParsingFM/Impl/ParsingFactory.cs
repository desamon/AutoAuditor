using LoggerFM.Interface;
using Ninject;
using Ninject.Parameters;
using Ninject.Syntax;
using ParsingFM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingFM.Impl
{
    public class ParsingFactory : IParsingFactory
    {
        #region Fields
        private readonly IResolutionRoot _resolutionRoot;
        #endregion

        #region Constructors
        public ParsingFactory(IResolutionRoot resolutionRoot)
        {
            _resolutionRoot = resolutionRoot;
        }
        #endregion

        #region Methods
        public IParsing Create()
        {
            return _resolutionRoot.Get<IParsing>();
        }

        public IParsing Create(ILog logger, string path)
        {
            return _resolutionRoot.Get<IParsing>(
                new ConstructorArgument(nameof(logger), logger)
                , new ConstructorArgument(nameof(path), path));
        }

        public IParsing Create(ILog logger, string referencePath, string filePath)
        {
            return _resolutionRoot.Get<IParsing>(
                new ConstructorArgument(nameof(logger), logger)
                , new ConstructorArgument(nameof(referencePath), referencePath)
                , new ConstructorArgument(nameof(filePath), filePath));
        }
        #endregion
    }
}
