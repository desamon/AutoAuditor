using Logger.Interface;
using Ninject.Modules;

namespace Logger.Impl
{
    public class LogConfigModule : NinjectModule
    {
        #region Override
        public override void Load()
        {
            Bind<ILog>().To<Log>();
            Bind<Log>().ToSelf();

            Bind<ILogFactory>().To<LogFactory>();
            Bind<LogFactory>().ToSelf();
        }
        #endregion
    }
}
