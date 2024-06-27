using Newtonsoft.Json;
namespace WebApp_UnderKo.Models.Serializator.Json
{
    public class JsonSerializator<T>
    {
        public T DeserializeObject(string serialize_str)
        {
            try
            {
                return (T)JsonConvert.DeserializeObject(serialize_str);
            }
            catch (Exception)
            {

                return default;
            }
        }

        public string SerializeObject(T obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj, Formatting.Indented);
            }
            catch (Exception)
            {

                return JsonConvert.NaN;
            }
        }
    }
}
