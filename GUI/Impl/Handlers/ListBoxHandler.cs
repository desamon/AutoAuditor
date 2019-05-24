using GUI.Impl.Models;
using GUI.Interface;
using GUI.Impl.Extension;
using LoggerFM.Interface;
using Ninject;
using ParsingFM.Impl;
using ParsingFM.Impl.Models;
using ParsingFM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace GUI.Impl.Handlers
{
    internal class ListBoxHandler : Handlerss, IListBoxHandler
    {
        #region Fields
        private ILog _logger;
        private IParsing _parsing;
        private StandardKernel _kernelParsing;
        #endregion

        #region Constructors
        internal ListBoxHandler(ILog logger)
        {
            _logger = logger;
            _kernelParsing = new StandardKernel(new ParsingConfigModule());
        }
        #endregion

        #region Methods
        public void LoadSelectedTemplate<Element>(LoadTemplate template, Element elem)
            where Element: DataGrid
        {
            var source = this.GetTemplate(template.Path, _logger);
            CallBackWindow.DGObserverCollection(elem, source);
        }
        #endregion
    }
}
