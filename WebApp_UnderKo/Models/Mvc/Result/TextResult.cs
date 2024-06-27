using Microsoft.AspNetCore.Mvc;

namespace WebApp_UnderKo.Models.Mvc.Result
{
    public class TextResult : JsonResult
    {
        public TextResult(object? value) : base(value)
        {
        }

        public TextResult(object? value, object? serializerSettings) : base(value, serializerSettings)
        {
        }
    }
}
