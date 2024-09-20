using System.Text.Json.Serialization;

namespace WebApp_Socket.Models
{
    public class HtopModel
    {
        public string Data { get; set; } = string.Empty;
    }
    [JsonSerializable(typeof(HtopModel[]))]
    internal partial class HtopModel_JsonSerializerContext : JsonSerializerContext
    {

    }
}
