using ParsingFM.Impl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Impl.Models
{
    public class LoadQuestions
    {
        public string Categorie { get; set; }
        public string Question { get; set; }
        public double ImportQuestion { get; set; }
        public List<AnswerModel> Answers { get; set; }
    }
}
