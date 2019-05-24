using Parsing.Impl.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parsing.Impl
{
    public static class Extensions
    {
        public static string GetFileName(string path)
            => System.IO.Path.GetFileName(path);
        public static string GetFileExtension(string path)
            => System.IO.Path.GetExtension(path);

        public static CategorieLvl GetLvl(string lvl)
        {
            if (CategorieLvl.Critical.ToString().Equals(lvl))
                return CategorieLvl.Critical;

            else if (CategorieLvl.VeryImportant.ToString().Equals(lvl))
                return CategorieLvl.VeryImportant;

            else if (CategorieLvl.Important.ToString().Equals(lvl))
                return CategorieLvl.Important;

            else if (CategorieLvl.Minor.ToString().Equals(lvl))
                return CategorieLvl.Minor;

            return CategorieLvl.Unknown;
        }

        public static AnswerLvl GetAnswerLvl(string lvl)
        {
            if (AnswerLvl.Perfect.ToString().Equals(lvl))
                return AnswerLvl.Perfect;

            else if (AnswerLvl.Well.ToString().Equals(lvl))
                return AnswerLvl.Well;

            else if (AnswerLvl.NotBad.ToString().Equals(lvl))
                return AnswerLvl.NotBad;

            else if (AnswerLvl.Bad.ToString().Equals(lvl))
                return AnswerLvl.Bad;

            else if (AnswerLvl.Terrible.ToString().Equals(lvl))
                return AnswerLvl.Terrible;

            return AnswerLvl.Unknown;
        }
    }
}
