using Logger.Interface;
using Parsing.Impl.Enums;
using Parsing.Impl.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Parsing.Impl.Parsers
{
    public class XmlParser
    {
        #region Fields
        private readonly string _path;
        private static ILog _logger;
        private List<Title> _titles
            = new List<Title>();
        #endregion

        #region Constructors
        public XmlParser(string path, ILog logger)
        {
            _path = path;
            _logger = logger;
        }
        #endregion

        #region Methods
        public List<Title> Run()
        {
            #region logger
            _logger.Info($"XmlParser Run with {_path} ...");
            #endregion

            Parser();

            return _titles;
        }

        private void Parser()
        {
            var xDoc = LoadDoc(new XmlDocument());
            var xRoot = LoadElement(xDoc);
            XmlMileage(xRoot);
        }

        private XmlDocument LoadDoc(XmlDocument xDoc)
        {
            xDoc.Load(_path);
            return xDoc;
        }

        private XmlElement LoadElement(XmlDocument xDoc)
            => xDoc.DocumentElement;

        private void XmlMileage(XmlElement xRoot)
        {
            var criterions = new List<Criterion>();
            var questions = new List<Question>();

            foreach (XmlNode title in xRoot)
            {
                var titleName = title.Attributes.GetNamedItem("name");

                //CriterionMileage(title, criterions, questions);

                foreach (XmlNode criterion in title.ChildNodes)
                {
                    var criterionName = criterion.Attributes.GetNamedItem("name");
                    var criterionCategorie = criterion.Attributes.GetNamedItem("categorieLvl");

                    foreach (XmlNode question in criterion.ChildNodes)
                    {
                        var questionChild = question.FirstChild;
                        var questionLvl = questionChild.Attributes.GetNamedItem("categorieLvl");
                        var questionText = questionChild.InnerText;

                        var answerChild = question.LastChild;
                        var answerLvl = answerChild.Attributes.GetNamedItem("result");
                        var answerText = answerChild.InnerText;

                        if (questionText != null)
                        {
                            questions.Add(new Question
                            {
                                QuestionText = questionText,
                                AnswerText = answerText,
                                QuestionLvl = Extensions.GetLvl(questionLvl.Value),
                                AnswerLvl = Extensions.GetAnswerLvl(answerLvl.Value)
                            });
                        }
                    }

                    if (criterionName != null && criterionCategorie != null)
                    {
                        criterions.Add(new Criterion
                        {
                            Name = criterionName.Value,
                            //Lvl = criterionCategorie.Value,
                            Lvl = Extensions.GetLvl(criterionCategorie.Value),
                            Questions = questions
                        });

                        questions = new List<Question>();
                    }
                }

                if (title != null)
                {
                    _titles.Add(new Title
                    {
                        Name = titleName.Value,
                        Criterions = criterions
                    });

                    criterions = new List<Criterion>();
                }
            }
        }

        //private void CriterionMileage(XmlNode title, List<Criterion> criterions, List<Question> questions)
        //{
        //    foreach (XmlNode criterion in title.ChildNodes)
        //    {
        //        var criterionName = criterion.Attributes.GetNamedItem("name");
        //        var criterionCategorie = criterion.Attributes.GetNamedItem("categorieLvl");

        //        QuestionMileage(criterion, questions);

        //        if (criterionName != null && criterionCategorie != null)
        //        {
        //            criterions.Add(new Criterion
        //            {
        //                Name = criterionName.Value,
        //                Lvl = criterionCategorie.Value,
        //                Questions = questions
        //            });

        //            questions = new List<Question>();
        //        }
        //    }
        //}

        //private void QuestionMileage(XmlNode criterion, List<Question> questions)
        //{
        //    foreach (XmlNode question in criterion.ChildNodes)
        //    {
        //        var questionText = question.FirstChild.InnerText;
        //        var questionAnswer = question.LastChild.InnerText;

        //        if (questionText != null)
        //        {
        //            questions.Add(new Question
        //            {
        //                QuestionText = questionText,
        //                AnswerText = questionAnswer
        //            });
        //        }
        //    }
        //}
        #endregion
    }
}
