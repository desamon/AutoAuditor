using AutoAuditorFM.Impl.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAuditorFM.Impl.Models
{

    public static class LinguisticValue
    {
        public static double GetValue(AnswerLvl meaning, CategorieLvl lvl)
        {
            switch (lvl)
            {
                case CategorieLvl.Critical:
                    return Critical(meaning);

                case CategorieLvl.VeryImportant:
                    return VeryImportant(meaning);

                case CategorieLvl.Important:
                    return Important(meaning);

                case CategorieLvl.Minor:
                    return Minor(meaning);

                case CategorieLvl.Unknown:
                    return 0.0;
            }
            return 0.0;
        }

        private static double Critical(AnswerLvl meaning)
        {
            if (meaning.Equals(AnswerLvl.Perfect))
                return 1;
            else if (meaning.Equals(AnswerLvl.Well))
                return 0.95;
            else if (meaning.Equals(AnswerLvl.NotBad))
                return 0.9;
            else if (meaning.Equals(AnswerLvl.Bad))
                return 0.85;
            else if (meaning.Equals(AnswerLvl.Terrible))
                return 0.8;

            return 0.0;
        }

        private static double VeryImportant(AnswerLvl meaning)
        {
            if (meaning.Equals(AnswerLvl.Perfect))
                return 0.75;
            else if (meaning.Equals(AnswerLvl.Well))
                return 0.7;
            else if (meaning.Equals(AnswerLvl.NotBad))
                return 0.65;
            else if (meaning.Equals(AnswerLvl.Bad))
                return 0.6;
            else if (meaning.Equals(AnswerLvl.Terrible))
                return 0.55;

            return 0.0;
        }

        private static double Important(AnswerLvl meaning)
        {
            if (meaning.Equals(AnswerLvl.Perfect))
                return 0.5;
            else if (meaning.Equals(AnswerLvl.Well))
                return 0.45;
            else if (meaning.Equals(AnswerLvl.NotBad))
                return 0.4;
            else if (meaning.Equals(AnswerLvl.Bad))
                return 0.35;
            else if (meaning.Equals(AnswerLvl.Terrible))
                return 0.3;

            return 0.0;
        }

        private static double Minor(AnswerLvl meaning)
        {
            if (meaning.Equals(AnswerLvl.Perfect))
                return 0.25;
            else if (meaning.Equals(AnswerLvl.Well))
                return 0.2;
            else if (meaning.Equals(AnswerLvl.NotBad))
                return 0.15;
            else if (meaning.Equals(AnswerLvl.Bad))
                return 0.1;
            else if (meaning.Equals(AnswerLvl.Terrible))
                return 0.05;

            return 0.0;
        }
    }
}
