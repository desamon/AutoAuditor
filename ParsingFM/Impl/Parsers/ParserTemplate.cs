using ParsingFM.Impl.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ParsingFM.Impl.Parsers
{
    internal class ParserTemplate
    {
        #region Fields
        private List<TemplateParsing> _values;
        private XmlModel _xmlResult { get; set; }
        #endregion

        #region Constructors
        public ParserTemplate(List<TemplateParsing> list)
        {
            _values = list;
        }
        #endregion

        #region Methods
        internal XmlModel StartParsing()
        {
            var categories = new List<CategorieModel>();

            var categorieList = _values
                .Select(s => s.Categorie)
                .Distinct()
                .ToList();

            foreach(var categorie in categorieList)
            {
                var questions = new List<QuestionModel>();

                var questionList = _values
                    .Where(w => w.Categorie == categorie)
                    .Select(s => s.Question)
                    .Distinct()
                    .ToList();

                foreach(var question in questionList)
                {
                    var answers = new List<AnswerModel>();

                    var importQuestion = _values
                        .Where(w => w.Question.Equals(question)
                            && w.Categorie.Equals(categorie))
                        .Select(s => s.ImportQuestion)
                        .FirstOrDefault();

                    var answerList = _values
                        .Where(w => w.Question.Equals(question)
                            && w.Categorie.Equals(categorie))
                        .Select(s => s.Answer)
                        .ToList();

                    foreach(var answer in answerList)
                    {
                        var value = _values
                            .Where(w => w.Categorie.Equals(categorie)
                                && w.Question.Equals(question)
                                && w.Answer.Equals(answer))
                            .Select(s => new AnswerModel
                            {
                                Answer = s.Answer,
                                ImportAnswer = Convert.ToDouble(s.ImportAnswer),
                                Comment = s.Comment
                            })
                            .FirstOrDefault();

                        answers.Add(value);
                    }

                    questions.Add(new QuestionModel
                    {
                        Question = question,
                        ImportQuestion = Convert.ToDouble(importQuestion),
                        Answers = answers
                    });
                }

                categories.Add(new CategorieModel
                {
                    Categorie = categorie,
                    Questions = questions
                });
            }

            _xmlResult = new XmlModel
            {
                XmlCollection = categories
            };

            return _xmlResult;
        }

        #endregion
    }
}
