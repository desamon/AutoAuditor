using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ParsingFM.Impl.Models
{
    public class QuestionsResult
    {
        [XmlElement("Question")]
        public string Question { get; set; }
        [XmlElement("Answer")]
        public string Answer { get; set; }
        [XmlElement("Value")]
        public string Value { get; set; }
    }
}
