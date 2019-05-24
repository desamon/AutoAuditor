using ParsingFM.Impl.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ParsingFM.Impl.Extension
{
    internal static class Extensions
    {
        internal static string GetFileName(string path)
            => System.IO.Path.GetFileName(path);
        internal static string GetFileExtension(string path)
            => System.IO.Path.GetExtension(path);

        internal static CategorieLvl GetLvl(string lvl)
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

        internal static AnswerLvl GetAnswerLvl(string lvl)
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

        internal static void SaveXml(string path, string values)
        {
            if (File.Exists(path))
                File.Delete(path);

            using (var sw = new StreamWriter(path, false))
                sw.Write(values);

            MessageBox.Show($"Xml файл сохранен: {path}");
        }

        internal static void CreateDirectory(string directory)
        {
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);
        }
    }
}
