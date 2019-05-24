using LoggerFM.Interface;
using Ninject;
using Ninject.Parameters;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerFM.Impl
{
    public class LogFactory : ILogFactory
    {
        #region Fields
        private readonly IResolutionRoot _resolutionRoot;
        #endregion

        #region Constructors
        public LogFactory(IResolutionRoot resolutionRoot)
        {
            _resolutionRoot = resolutionRoot;
        }
        #endregion

        #region Methods
        public ILog Create()
        {
            return _resolutionRoot.Get<ILog>();
        }

        public ILog Create(string folder)
        {
            return _resolutionRoot.Get<ILog>(
                new ConstructorArgument(nameof(folder), folder));
        }
        #endregion
    }
}
