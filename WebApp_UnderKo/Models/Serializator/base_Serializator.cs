namespace WebApp_UnderKo.Models.Serializator
{
    public interface base_Serializator
    {
        public string SerializeObject(object obj);
        public object DeserializeObject(string serialize_str);

    }
}
