using ParsingFM.Impl.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ParsingFM.Impl.Models
{
    public class Criterion
    {
        public string Name { get; set; }
        public CategorieLvl Lvl { get; set; }

        [XmlElement("Question")]
        public List<Question> Questions { get; set; }
    }
}
