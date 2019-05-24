using AutoAuditorFM.Impl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAuditorFM.Impl.Extensions
{
    internal static class Extension
    {
        internal static double GetResultValue(List<QuestionResult> questions)
        {
            var result = 0.0;

            foreach(var question in questions)
            {
                result += question.Value;
            }

            return result / questions.Count;
        }
    }
}
