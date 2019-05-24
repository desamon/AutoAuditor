using LoggerFM.Interface;
using ParsingFM.Impl.Enums;
using ParsingFM.Impl.Extension;
using ParsingFM.Impl.Models;
using ParsingFM.Impl.Parsers;
using ParsingFM.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace ParsingFM.Impl
{
    public class Parsing : IParsing
    {
        #region Fields
        private static ILog _logger;
        private string _path;
        private IXmlParser _xmlParser { get; set; }
        #endregion

        #region Constructors
        public Parsing(ILog logger, string path=null)
        {
            _logger = logger;
            _path = path;
        }
        #endregion

        #region Methods
        public void Start<Input>(Input elem)
            where Input : class
        {
            DictParser(elem as Dictionary<string, List<TemplateParsing>>);
        }

        public Output Start<Output>()
            where Output: class
        {
            var templates = XmlParser();
            return templates as Output;
        }

        public Output Start<Input, Output>(Input elem)
            where Input: class
            where Output: class
        {
            return null;
        }

        public Output LoadResult<Output>()
            where Output: class
        {
            var xmlParsing = new XmlParsing(_path, _logger);
            var templates = xmlParsing.LoadResult();

            return templates as Output;
        }

        public void Save(string name, List<XmlSave> values)
        {
            var xml = "";
            foreach (var value in values)
            {
                xml = XmlTools.XmlSerializable(value);
            }

            var path = $"./xmlResult/{name}_result.xml";
            Extensions.CreateDirectory("./xmlResult");
            Extensions.SaveXml(path, xml.Replace("utf-16", "utf-8"));
        }
        private List<TemplateParsing> XmlParser()
        {
            _xmlParser = new XmlParsing(_path, _logger);
            return _xmlParser.XmlParsingStart();
        }

        private void DictParser<Dict>(Dict dictionary)
            where Dict: Dictionary<string, List<TemplateParsing>>
        {
            foreach(var name in dictionary.Keys)
            {
                var dictParser = new ParserTemplate(dictionary[name]);
                var values = dictParser.StartParsing();
                var xml = XmlTools.XmlSerializable(values);
                var path = $"./xmls/{name}.xml";
                Extensions.CreateDirectory("./xmls");
                Extensions.SaveXml(path, xml.Replace("utf-16", "utf-8"));
            }
        }
        #endregion
    }
}
