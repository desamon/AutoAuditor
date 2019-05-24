using Parsing.Impl.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Parsing.Impl.Models
{
    public class Criterion
    {
        public string Name { get; set; }
        public CategorieLvl Lvl { get; set; }

        [XmlElement("Question")]
        public List<Question> Questions { get; set; }
    }
}
