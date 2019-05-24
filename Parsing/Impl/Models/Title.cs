using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Parsing.Impl.Models
{
    public class Title
    {
        public string Name { get; set; }

        [XmlElement("Criterion")]
        public List<Criterion> Criterions { get; set; }
    }
}
