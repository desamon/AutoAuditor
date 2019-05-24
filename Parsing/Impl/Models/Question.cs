using Parsing.Impl.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parsing.Impl.Models
{
    public class Question
    {
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
        public CategorieLvl QuestionLvl { get; set; }
        public AnswerLvl AnswerLvl { get; set; }
    }
}
