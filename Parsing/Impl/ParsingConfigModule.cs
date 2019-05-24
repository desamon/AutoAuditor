using Ninject.Modules;
using Parsing.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parsing.Impl
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
