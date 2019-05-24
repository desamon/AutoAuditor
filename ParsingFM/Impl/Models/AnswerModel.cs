using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ParsingFM.Impl.Models
{
    public class AnswerModel
    {
        [XmlElement("Answer")]
        public string Answer { get; set; }

        [XmlAttribute("ImportAnswer")]
        public double ImportAnswer { get; set; }
        [XmlElement("Comment")]
        public string Comment { get; set; }

    }
}
