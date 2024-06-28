using Newtonsoft.Json;
namespace WebApp_UnderKo.Models.Serializator.Json
{
    public class JsonSerializator<T>
    {
        public T DeserializeObject(string serialize_str)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(serialize_str);
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
                return JsonConvert.SerializeObject(obj, Formatting.Indented);
            }
            catch (Exception e)
            {
                G_.logger.NewLine(e.Message);
                return JsonConvert.NaN;
            }
        }
    }
}
