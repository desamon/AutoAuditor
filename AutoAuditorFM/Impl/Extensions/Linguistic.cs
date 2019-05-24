using AutoAuditorFM.Impl.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAuditorFM.Impl.Models
{
    public static class Linguistic
    {
        public static double GetValue(double question, double answer)
        {
            var questionLvl = GetQuestionCategorie(question);
            var answerLvl = GetAnswerCategore(answer);
            return LinguisticValue.GetValue(answerLvl, questionLvl);
        }

        public static CategorieLvl GetQuestionCategorie(double question)
        {
            if (question >= 0.76) return CategorieLvl.Critical;
            if (question >= 0.51) return CategorieLvl.VeryImportant;
            if (question >= 0.26) return CategorieLvl.Important;
            if (question <= 0.25) return CategorieLvl.Minor;

            return CategorieLvl.Unknown;
        }

        public static AnswerLvl GetAnswerCategore(double answer)
        {
            if (answer >= 0.81) return AnswerLvl.Perfect;
            if (answer >= 0.61) return AnswerLvl.Well;
            if (answer >= 0.41) return AnswerLvl.NotBad;
            if (answer >= 0.21) return AnswerLvl.Bad;
            if (answer <= 0.2) return AnswerLvl.Terrible;

            return AnswerLvl.Unknown;
        }
    }
}
