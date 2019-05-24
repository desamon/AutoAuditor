using LoggerFM.Interface;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerFM.Impl
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
