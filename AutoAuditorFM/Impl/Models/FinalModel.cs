using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAuditorFM.Impl.Models
{
    public class FinalModel
    {
        public string Categorie { get; set; }
        public double Result { get; set; }
        public List<QuestionResult> Questions { get; set; }
    }
}
