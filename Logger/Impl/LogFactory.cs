using Logger.Interface;
using Ninject;
using Ninject.Parameters;
using Ninject.Syntax;

namespace Logger.Impl
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
