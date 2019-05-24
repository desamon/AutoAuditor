using AutoAuditorFM.Impl.Extensions;
using AutoAuditorFM.Impl.Models;
using AutoAuditorFM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAuditorFM.Impl.Context
{
    public class CalculationContext: IContext
    {

        #region Methods
        public List<FinalModel> Invoke(Result[] result)
        {
            return Calculation(result);
        }

        private List<FinalModel> Calculation(Result[] result)
        {
            var final = new List<FinalModel>();

            var categories = result
                .Select(s => s.Categorie)
                .Distinct()
                .ToList();

            foreach(var categorie in categories)
            {
                var questions = result
                    .Where(w => w.Categorie.Equals(categorie))
                    .Select(s => new QuestionResult
                    {
                        Question = s.Question,
                        Answer = s.Answer,
                        Value = Linguistic.GetValue(s.ImportQuestion, s.ImportAnswer)
                    })
                    .ToList();

                //var resultValue = 

                final.Add(new FinalModel
                {
                    Categorie = categorie,
                    Questions = questions,
                    Result = Extension.GetResultValue(questions)
                });
            }

            return final;
        }

        #endregion
    }
}
