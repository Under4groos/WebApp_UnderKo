using Newtonsoft.Json;
using WebApp_UnderKo.Models.Serializator.Json;
using WebApp_UnderKo.Models.Serializator.Xaml;

namespace WebApp_UnderKo.Models.Serializator
{
    public class Serializator<T>
    {
        public JsonSerializator<T> json_XamlProject_Serializator = new JsonSerializator<T>();
        public XamlSerializator<T> xaml_XamlProject_Serializator = new XamlSerializator<T>();

        public T DeserializeObject(string serialize_str, enumType type = enumType.json)
        {
            try
            {
                switch (type)
                {
                    case enumType.xaml:
                        return xaml_XamlProject_Serializator.DeserializeObject(serialize_str);

                    case enumType.json:
                        return json_XamlProject_Serializator.DeserializeObject(serialize_str);

                    default:
                        return default;
                }


            }
            catch (Exception e)
            {
                G_.logger.NewLine(e.Message);
                return default;
            }
        }

        public string SerializeObject(T obj, enumType type = enumType.json)
        {
            try
            {
                switch (type)
                {
                    case enumType.xaml:
                        return xaml_XamlProject_Serializator.SerializeObject(obj);
                        ;
                    case enumType.json:
                        return json_XamlProject_Serializator.SerializeObject(obj);

                    default:
                        return $"Error! Type not found: {type}";
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
