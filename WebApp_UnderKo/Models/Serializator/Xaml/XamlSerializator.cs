using Newtonsoft.Json;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace WebApp_UnderKo.Models.Serializator.Xaml
{
    public class XamlSerializator<T>
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        public T DeserializeObject(string serialize_str)
        {
            try
            {
                using (Stream stream = new MemoryStream(Encoding.ASCII.GetBytes(serialize_str)))
                {
                    return (T)xmlSerializer.Deserialize(stream);
                }


            }
            catch (Exception e)
            {
                G_.logger.NewLine(e.Message);
                return default(T);
            }
        }

        public string SerializeObject(T obj)
        {

            try
            {
                using (var sww = new StringWriter())
                {
                    using (XmlTextWriter writer = new XmlTextWriter(sww) { Formatting = System.Xml.Formatting.Indented })
                    {
                        xmlSerializer.Serialize(writer, obj);
                        return sww.ToString();
                    }
                }

            }
            catch (Exception e)
            {
                G_.logger.NewLine(e.Message);
                return JsonConvert.NaN;
            }
        }
    }
}
