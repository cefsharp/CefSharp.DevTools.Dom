using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CefSharp.Dom.Helpers.Json
{
    internal static class JsonHelper
    {
        public static readonly JsonSerializerSettings DefaultJsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };
    }
}
