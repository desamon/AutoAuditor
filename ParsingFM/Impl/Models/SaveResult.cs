using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ParsingFM.Impl.Models
{
    public class SaveResult
    {
        [XmlElement("Categorie")]
        public string Categorie { get; set; }
        [XmlElement("Result")]
        public string Result { get; set; }
        [XmlElement("Questions")]
        public List<QuestionsResult> Questions { get; set; }
    }
}
