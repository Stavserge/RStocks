using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RStocks.XMLStorage.Common
{
    public static class XmlFileStorage
    {
        static Dictionary<string, object> _cache = new Dictionary<string, object>(); 
        
        public static T GetContainerFromFile<T>(string fileName) where T :class
        {
            if (_cache.ContainsKey(fileName) == true)
                return (_cache[fileName] as T);
            var fs = new FileStream(fileName, FileMode.Open);
            //StringReader stringReader = new StringReader();
            XmlSerializer xserial = new XmlSerializer(typeof(T));
            var m  = xserial.Deserialize(fs);
            fs.Close();
            _cache.Add(fileName, m as T);
            return m as T;
        }

        public static void SaveContainerToFile<T>(T container, string fileName) where T : class
        {
            if (_cache.ContainsKey(fileName) == false)
                _cache.Add(fileName,container);
            _cache[fileName] = container;
            StringWriter stringWriter = new StringWriter();
            XmlSerializer xserial = new XmlSerializer(typeof(T));
            var fs = new FileStream(fileName, FileMode.OpenOrCreate);
            fs.SetLength(0);
            xserial.Serialize(fs, container);
            fs.Close();
            
        }
    }
}
