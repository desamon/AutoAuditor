using Ninject.Modules;
using ParsingFM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingFM.Impl
{
    public class ParsingConfigModule : NinjectModule
    {
        #region Override
        public override void Load()
        {
            Bind<IParsing>().To<Parsing>();
            Bind<Parsing>().ToSelf();

            Bind<IParsingFactory>().To<ParsingFactory>();
            Bind<ParsingFactory>().ToSelf();
        }
        #endregion
    }
}
