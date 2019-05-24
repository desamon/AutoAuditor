using LoggerFM.Interface;
using ParsingFM.Impl.Extension;
using ParsingFM.Impl.Models;
using ParsingFM.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Serialization;

namespace ParsingFM.Impl.Parsers
{
    public class XmlParsing : IXmlParser
    {
        #region Fields
        private readonly string _path;
        private static ILog _logger;
        #endregion

        #region Constructors
        public XmlParsing(string path, ILog logger)
        {
            _path = path;
            _logger = logger;
        }
        #endregion

        #region Methods
        public List<SaveResult> LoadResult()
        {
            var xml = File.ReadAllText(_path);
            var result = XmlTools.XmlDeserializable<XmlSave>(xml);

            return ResultMileage(result);
        }

        private List<SaveResult> ResultMileage(XmlSave xml)
        {
            var xmlCollection = xml.XmlCollection;
            var source = new List<SaveResult>();

            foreach(var categorie in xmlCollection)
            {
                var categorieName = categorie.Categorie;
                var resultValue = categorie.Result;
                var questions = new List<QuestionsResult>();

                foreach (var question in categorie.Questions)
                {
                    questions.Add(new QuestionsResult
                    {
                        Question = question.Question,
                        Answer = question.Answer,
                        Value = question.Value
                    });
                }
                source.Add(new SaveResult
                {
                    Categorie = categorieName,
                    Result = resultValue,
                    Questions = questions
                });
            }
            return source;
        }

        public List<TemplateParsing> XmlParsingStart()
        {
            var xml = File.ReadAllText(_path);
            var result = XmlTools.XmlDeserializable<XmlModel>(xml);

            return XmlMileage(result);
        }
        
        private List<TemplateParsing> XmlMileage(XmlModel xml)
        {
            var xmlCollection = xml.XmlCollection;
            var sources = new List<TemplateParsing>();

            foreach(var categorie in xmlCollection)
            {
                var categorieName = categorie.Categorie;

                foreach(var question in categorie.Questions)
                {
                    var questionText = question.Question;
                    var questionImport = question.ImportQuestion;

                    foreach(var answer in question.Answers)
                    {
                        sources.Add(new TemplateParsing
                        {
                            Categorie = categorieName,
                            Question = questionText,
                            Answer = answer.Answer,
                            ImportQuestion = questionImport.ToString(),
                            ImportAnswer = answer.ImportAnswer.ToString(),
                            Comment = answer.Comment
                        });
                    }
                }
            }
            return sources;
        }
        #endregion
    }
}
