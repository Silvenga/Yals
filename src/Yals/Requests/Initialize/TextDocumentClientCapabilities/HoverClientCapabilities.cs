using Newtonsoft.Json;

namespace Yals.Requests.Initialize.TextDocumentClientCapabilities
{
    public class HoverClientCapabilities
    {
        /// <summary>
        /// Whether hover supports dynamic registration.
        /// </summary>
        [JsonProperty("dynamicRegistration")]
        public bool? DynamicRegistration { get; set; }
    }
}