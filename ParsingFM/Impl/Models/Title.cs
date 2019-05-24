using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ParsingFM.Impl.Models
{
    public class Title
    {
        public string Name { get; set; }

        [XmlElement("Criterion")]
        public List<Criterion> Criterions { get; set; }
    }
}
