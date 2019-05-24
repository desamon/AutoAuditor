using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ParsingFM.Impl.Models
{
    public class QuestionModel
    {
        [XmlElement("Question")]
        public string Question { get; set; }

        [XmlAttribute("ImportQuestion")]
        public double ImportQuestion { get; set; }

        [XmlElement("Answers")]
        public List<AnswerModel> Answers { get; set; }
    }
}
