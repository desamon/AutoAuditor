using AutoAuditor.Impl.Extension;
using AutoAuditor.Interface;
using Logger.Interface;
using Ninject;
using Parsing.Impl;
using Parsing.Impl.Models;
using Parsing.Interface;
using System;
using System.Collections.Generic;

namespace AutoAuditor.Impl.Context
{
    public class InitializationContext : IContext
    {
        #region Fields
        private const string _defaultPath = "./Reference.xml";
        private static readonly object _locker = new object();

        private Dictionary<string, List<Title>> _parsingResult { get; set; }
        private List<string> _paths { get; set; }

        private StandardKernel _kernelParsing;
        private static ILog _logger;
        private readonly string _referencePath;
        private readonly string _filePath;
        #endregion

        #region Constructors
        public InitializationContext(ILog logger, string filePath, string referencePath = null)
        {
            _logger = logger;
            _referencePath = string.IsNullOrEmpty(referencePath) ? _defaultPath : referencePath;
            _filePath = filePath;

            Initialization();
        }
        #endregion

        #region Methods
        private void Initialization()
        {
            _kernelParsing = new StandardKernel(new ParsingConfigModule());

            _parsingResult = new Dictionary<string, List<Title>>();
            _paths = new List<string>
            {
                _filePath
                ,_referencePath
            };
        }

        public T Invoke<T>()
            where T: class, new()
        {
            #region logger
            _logger.Info("InitializationContext Invoke run...");
            #endregion

            try
            {
                ToParsing();

                #region logger
                _logger.Info($"Parsing is completed... count {_parsingResult.Count}");
                #endregion

                return _parsingResult as T;
            }
            catch (AggregateException ex)
            {
                ExceptionHandler.Aggregate(ex, _logger, ">>> InitializationContext Invoke");
            }
            catch(Exception ex)
            {
                ExceptionHandler.Another(ex, _logger, ">>> InitializationContext Invoke");
            }

            return null;
        }

        private void ToParsing()
        {
            var parser = _kernelParsing.Get<IParsingFactory>()
                .Create(_logger, _filePath);

            var fileName = System.IO.Path.GetFileNameWithoutExtension(_filePath);
            var resultParsing = parser.Start();

            lock (_locker)
                _parsingResult.Add(fileName, resultParsing);
        }
        #endregion
    }
}
