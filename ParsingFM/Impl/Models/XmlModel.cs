using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ParsingFM.Impl.Models
{
    public class XmlModel
    {
        [XmlArray("Collection"), XmlArrayItem("Item")]
        public List<CategorieModel> XmlCollection { get; set; }
    }
}
