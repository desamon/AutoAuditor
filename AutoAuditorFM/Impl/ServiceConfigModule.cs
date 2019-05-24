using AutoAuditorFM.Interface;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAuditorFM.Impl
{
    public class ServiceConfigModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IServiceFactory>().To<ServiceFactory>();
            Bind<ServiceFactory>().ToSelf();

            Bind<IService>().To<Service>();
            Bind<Service>().ToSelf();
        }
    }
}
