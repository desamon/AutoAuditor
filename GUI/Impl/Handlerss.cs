using GUI.Impl.Models;
using GUI.Impl.Extension;
using LoggerFM.Interface;
using Ninject;
using ParsingFM.Impl;
using ParsingFM.Impl.Models;
using ParsingFM.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GUI.Impl
{
    public abstract class Handlerss
    {
        #region Fields
        #endregion

        #region Constructors

        #endregion

        #region Methods
        public ObservableCollection<Template> GetTemplate(string path, ILog logger)
        {
            var kernel = new StandardKernel(new ParsingConfigModule());
            var parsing = kernel.Get<IParsingFactory>().Create(logger, path);
            var source = new ObservableCollection<Template>();

            var templates = parsing.Start<List<TemplateParsing>>();

            foreach(var row in templates)
            {
                var newRow = Extensions.TemplateConvertor<TemplateParsing, Template>(row);
                source.Add(newRow);
            }

            return source;
        }
        #endregion
    }
}
