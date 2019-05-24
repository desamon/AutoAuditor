using AutoAuditorFM.Impl.Models;
using GUI.Impl.Models;
using ParsingFM.Impl.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Impl.Extension
{
    internal class Extensions
    {
        internal static Output TemplateConvertor<Input, Output>(Input template)
            where Input: class
            where Output: class, new()
        {
            dynamic input = template;
            dynamic output = null;

            if (typeof(Output) == typeof(Template))
            {
                output = new Template();
            }
            else if(typeof(Output) == typeof(TemplateParsing))
            {
                output = new TemplateParsing();
            }

            output.Categorie = input.Categorie;
            output.Question = input.Question;
            output.Answer = input.Answer;
            output.ImportAnswer = input.ImportAnswer;
            output.ImportQuestion = input.ImportQuestion;
            output.Comment = input.Comment;

            return output as Output;
        }

        internal static ObservableCollection<LoadTemplate> GetFiles(string path)
        {
            var files = Directory.GetFiles(path);
            var source = new ObservableCollection<LoadTemplate>();

            foreach (var file in files)
            {
                source.Add(new LoadTemplate
                {
                    Path = file,
                    TemplateName = Path.GetFileNameWithoutExtension(file)
                });
            }

            return source;
        }

        internal static Result[] ConvertResult(Template[] source)
        {
            var index = source
                .Where(w => w != null)
                .Count();

            var result = new Result[index];

            foreach (var row in source)
            {
                if (row is null) continue;

                index--;

                var res = new Result
                {
                    Categorie = row.Categorie,
                    Question = row.Question,
                    Answer = row.Answer,
                    ImportAnswer = Convert.ToDouble(row.ImportAnswer),
                    ImportQuestion = Convert.ToDouble(row.ImportQuestion),
                    Comment = row.Comment
                };

                result[index] = res;
            }

            return result;
        }
    }
}
