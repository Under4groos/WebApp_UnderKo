using Newtonsoft.Json;
using System.Text;
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
            catch (Exception)
            {

                return default(T);
            }
        }

        public string SerializeObject(T obj)
        {
            try
            {
                using (Stream stream = new MemoryStream())
                {
                    xmlSerializer.Serialize(stream, obj);
                    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                    {

                        return reader.ReadToEnd();
                    }


                };
            }
            catch (Exception)
            {

                return JsonConvert.NaN;
            }
        }
    }
}
