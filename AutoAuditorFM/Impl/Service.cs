using AutoAuditorFM.Impl.Context;
using AutoAuditorFM.Impl.Models;
using AutoAuditorFM.Interface;
using LoggerFM.Interface;
using ParsingFM.Impl.Models;
using ParsingFM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAuditorFM.Impl
{
    public class Service: IService
    {
        #region Fields
        private Result[] _result;
        private ILog _logger;
        private IParsing _parsing;
        private IContext _context;
        private readonly string _name;
        #endregion

        #region Constructors
        public Service(Result[] result, ILog logger, IParsing parsing, string name)
        {
            _result = result;
            _logger = logger;
            _parsing = parsing;
            _name = name;
            _context = new CalculationContext();
        }
        #endregion

        #region Methods
        public void Invoke()
        {
            var finalResult = _context.Invoke(_result);
            ToParsing(finalResult);
        }

        private void ToParsing(List<FinalModel> result)
        {
            var resultCollection = new List<XmlSave>();
            var categories = new List<SaveResult>();

            foreach(var categorie in result)
            {
                var questions = new List<QuestionsResult>();
                foreach(var question in categorie.Questions)
                {
                    questions.Add(new QuestionsResult
                    {
                        Question = question.Question,
                        Answer = question.Answer,
                        Value = question.Value.ToString()
                    });
                }
                categories.Add(new SaveResult
                {
                    Categorie = categorie.Categorie,
                    Questions = questions,
                    Result = categorie.Result.ToString()
                });
            }

            resultCollection.Add(new XmlSave { XmlCollection = categories });

            _parsing.Save(_name, resultCollection);
        }
        #endregion
    }
}
