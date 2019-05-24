using Logger.Interface;
using Parsing.Impl.Models;
using Parsing.Impl.Parsers;
using Parsing.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Parsing.Impl
{
    public class Parsing : IParsing
    {
        #region Fields
        private static int _processorCount = Environment.ProcessorCount;
        private static readonly object _locker = new object();
        private List<Title> _result { get; set; }

        private static ILog _logger;
        private string _path;
        #endregion

        #region Constructors
        public Parsing(ILog logger, string path)
        {
            _logger = logger;

            Initialization(path);
        }
        #endregion

        #region Methods
        async public void Initialization(string path)
        {
            _result = new List<Title>();

            if (string.IsNullOrEmpty(path))
            {
                await _logger.WarningAsync("Path to file is empty...");
                Console.WriteLine("Path to file is empty...");
                Console.WriteLine("Press any key then close programm...");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
                _path = path;
        }
        public List<Title> Start()
        {
            #region logger
            _logger.Info($"Parsing run... path to file {_path}");
            #endregion

            
            var extension = GetExtension();
            ChooseParser(extension);

            return _result;
        }

        private FileExtension GetExtension()
        {
            var fileName = Extensions.GetFileName(_path);
            var extension = Extensions.GetFileExtension(fileName);

            if (extension.Contains("json")) return FileExtension.json;
            else if (extension.Contains("xml")) return FileExtension.xml;
            else return FileExtension.unknown;
        }

        private void ChooseParser(FileExtension extension)
        {
            switch(extension)
            {
                case FileExtension.unknown:
                    #region logger
                    _logger.Warning("Unknown file extension...");
                    #endregion
                break;

                case FileExtension.xml:
                    #region logger
                    _logger.Info("File extension is xml...");
                    #endregion

                    var xmlParser = new XmlParser(_path, _logger);
                    _result = xmlParser.Run();
                break;

                case FileExtension.json:
                    #region logger
                    _logger.Info("File extension is json");
                    #endregion
                break;
            }
        }
        #endregion
    }
}
