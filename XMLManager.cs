using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GameStructure.Managers
{
    public static class XMLManager
    {
        public static T Load<T>(string path)
        {
            using (TextReader reader = new StreamReader(path))
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                return (T)xml.Deserialize(reader);
            }
        }

        public static void Save<T>(string path, T obj)
        {
            using (TextWriter writer = new StreamWriter(path))
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                xml.Serialize(writer, obj);
            }
        }
    }
}
