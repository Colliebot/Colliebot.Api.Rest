using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Linq;

namespace Colliebot.Api.Rest
{
    public sealed class ApiError
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("detail")]
        public string Detail { get; set; }
        [JsonProperty("stacktrace")]
        public string StackTrace { get; set; } = "";

        public ApiError() { }
        public ApiError(string message)
        {
            Message = message;
        }
        public ApiError(ModelStateDictionary modelState)
        {
            Message = "Invalid parameters.";

            Detail = modelState
                .FirstOrDefault(x => x.Value.Errors.Any())
                .Value?.Errors?.FirstOrDefault()?.ErrorMessage;
        }
    }
}
