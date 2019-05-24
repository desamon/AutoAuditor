using AutoAuditor.Impl.Extension;
using AutoAuditor.Impl.Models;
using AutoAuditor.Interface;
using Logger.Interface;
using Parsing.Impl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAuditor.Impl.Context
{
    public class CalculationContext : IContext
    {
        #region Fields
        private Dictionary<string, List<Title>> _resultTemplate;
        private static ILog _logger;
        private static readonly object _locker = new object();
        private static int _processorCount = Environment.ProcessorCount;
        #endregion

        #region Constructors
        public CalculationContext(ILog logger, Dictionary<string, List<Title>> result)
        {
            _logger = logger;
            _resultTemplate = result;
        }
        #endregion

        #region Methods
        public T Invoke<T>()
            where T: class, new()
        {
            #region logger
            _logger.Info("Calculation Context run...");
            #endregion

            try
            {
                Distributor();
            }
            catch (AggregateException ex)
            {
                ExceptionHandler.Aggregate(ex, _logger, ">>> CalculationContext Invoke");
            }
            catch (Exception ex)
            {
                ExceptionHandler.Another(ex, _logger, ">>> CalctulactionContext Invoke");
            }

            return null;
        }

        private void Distributor()
        {
            #region logger
            _logger.Info("Calculaction run...");
            #endregion

            #region parallel settings
            var parallelOption = new ParallelOptions()
            {
                MaxDegreeOfParallelism = _processorCount
            };
            #endregion

            Parallel.ForEach(_resultTemplate.Keys, parallelOption, key =>
            {
                var titleList = _resultTemplate[key];
                Calculaction(titleList);
            });
        }

        private void Calculaction(List<Title> titleList)
        {
            var result = new List<AuditResult>();

            foreach (var title in titleList)
            {
                var titleName = title.Name;
                var criterions = title.Criterions;

                foreach (var criterion in criterions)
                {
                    var criterionName = criterion.Name;
                    var criterionLvl = criterion.Lvl;
                    var questions = criterion.Questions;
                    var criterionResult = 0.0;

                    var questionResult = new List<QuestionResult>();

                    foreach (var question in questions)
                    {
                        var questionText = question.QuestionText;
                        var answer = question.AnswerText;
                        var questionLvl = question.QuestionLvl;
                        var answerLvl = question.AnswerLvl;

                        var value = LinguisticValue.GetValue(answerLvl, questionLvl);

                        questionResult.Add(new QuestionResult
                        {
                            Question = questionText,
                            Answer = answer,
                            Result = value
                        });

                        criterionResult += value;
                    }

                    result.Add(new AuditResult
                    {
                        Title = titleName,
                        Criterion = criterionName,
                        QuestionsResult = questionResult,
                        Value = Extension.Extension.GetCriterionValue(criterionResult, questionResult.Count)
                    });
                }
            }
            Console.WriteLine("");
        }
        #endregion
    }
}
