using System.Xml.Serialization;

namespace WebApp_UnderKo.Module.Xaml
{
    public class XamlObjFile<T>
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

        public void ObjectSerialize(T data, string path)
        {
            try
            {

                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    xmlSerializer.Serialize(fs, data);

                    Console.WriteLine("Object has been serialized");
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }
        public T ObjectDeSerialize(string path)
        {
            T? class_ = default(T);
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    class_ = (T)xmlSerializer.Deserialize(fs);

                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return class_;
        }
    }
}
