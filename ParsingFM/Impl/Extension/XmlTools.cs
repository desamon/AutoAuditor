using ParsingFM.Impl.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ParsingFM.Impl.Extension
{
    internal static class XmlTools
    {
        internal static string XmlSerializable<Type>(Type values)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Type));
            StringWriter stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter, values);

            return stringWriter.ToString();
        }

        internal static Type XmlDeserializable<Type>(string xml)
        {
            var reader = new StringReader(xml);
            return (Type)new XmlSerializer(typeof(Type)).Deserialize(reader);
        }
    }
}
