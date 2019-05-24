using AutoAuditorFM.Impl.Models;
using AutoAuditorFM.Interface;
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

namespace AutoAuditorFM.Impl
{
    public class ServiceFactory : IServiceFactory
    {
        #region Fields
        private IResolutionRoot _resolutionRoot;
        #endregion

        #region Constructors
        public ServiceFactory(IResolutionRoot resolutionRoot)
        {
            _resolutionRoot = resolutionRoot;
        }
        #endregion

        #region Methods
        public IService Create(Result[] result, ILog logger, IParsing parsing, string name)
        {
            return _resolutionRoot.Get<IService>(
                new ConstructorArgument(nameof(result), result)
                , new ConstructorArgument(nameof(logger), logger)
                , new ConstructorArgument(nameof(parsing), parsing)
                ,new ConstructorArgument(nameof(name), name));
        }
        #endregion
    }
}
