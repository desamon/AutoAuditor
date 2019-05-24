using AutoAuditor.Impl.Context;
using Logger.Impl;
using Logger.Interface;
using Ninject;
using Parsing.Impl.Models;
using System.Collections.Generic;

namespace AutoAuditor.Impl
{
    public class Service
    {
        #region Fields
        private ILog _logger;
        private static string _referencePath;
        private static string _filePath;
        #endregion

        #region Constructors
        public Service(string referencePath = null, string filePath = null)
        {
            _referencePath = referencePath;
            _filePath = filePath;

            Initialization();
        }
        #endregion

        #region Methods
        private void Initialization()
        {
            var kernelLogger = new StandardKernel(new LogConfigModule());
            _logger = kernelLogger.Get<ILogFactory>().Create();

            if (_referencePath is null && _filePath is null)
                _logger.Warning($"Reference and file paths is emoty...");
        }

        public void Start()
        {
            #region logger
            _logger.Info("Service Start run...");
#if DEBUG
            _logger.Debug("Create InitializationContext instance...");
#endif
            #endregion

            var context = new InitializationContext(_logger, _filePath, _referencePath);
            var result = context.Invoke<Dictionary<string, List<Title>>>();

            #region logger
            _logger.Info("InitializationContext completed...");
#if DEBUG
            _logger.Debug("Create CalculationContext instance...");
#endif
            #endregion

            var calculation = new CalculationContext(_logger, result);
            calculation.Invoke<List<string>>();

        }
        #endregion
    }
}
