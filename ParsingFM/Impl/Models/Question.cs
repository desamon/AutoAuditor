using ParsingFM.Impl.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingFM.Impl.Models
{
    public class Question
    {
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
        public CategorieLvl QuestionLvl { get; set; }
        public AnswerLvl AnswerLvl { get; set; }
    }
}
