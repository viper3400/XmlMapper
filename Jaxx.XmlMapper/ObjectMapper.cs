using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Jaxx.XmlMapper
{
    /// <summary>
    /// Class for mapping source object into destination objects based on a xml map file.
    /// </summary>
    public class ObjectMapper : IObjectMapper
    {
        /// <summary>
        /// Constructor. Takes the path to the xml map file.
        /// </summary>
        /// <param name="mapFile"></param>
        public ObjectMapper(string mapFile)
        {
            mapList = new Dictionary<string, string>();

            StreamReader str = new StreamReader(mapFile);
            XmlSerializer xSerializer = new XmlSerializer(typeof(ObjectMapping));

            ObjectMapping deserialized = (ObjectMapping)xSerializer.Deserialize(str);

            foreach (var mapping in deserialized.Mapping)
            {
                mapList.Add(mapping.src.FirstOrDefault().Value, mapping.dest.FirstOrDefault().Value);
            }

            str.Close();
        }

        /// <summary>
        /// A dictionary with the source & destination pairs from xml
        /// </summary>
        private Dictionary<string, string> mapList;

        /// <summary>
        /// Maps a source string to its destination string.
        /// </summary>
        /// <param name="sourceString"></param>
        /// <returns>Returns the destination string or an emtpy string if source string was not found.</returns>
        public string Map(string sourceString)
        {
            if (mapList.ContainsKey(sourceString))
            {
                return mapList[sourceString];
            }
            else return "";

        }
    }
}
