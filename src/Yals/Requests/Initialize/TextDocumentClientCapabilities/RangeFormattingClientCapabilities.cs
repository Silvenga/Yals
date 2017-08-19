using Newtonsoft.Json;

namespace Yals.Requests.Initialize.TextDocumentClientCapabilities
{
    public class RangeFormattingClientCapabilities
    {
        /// <summary>
        /// Whether range formatting supports dynamic registration.
        /// </summary>
        [JsonProperty("dynamicRegistration")]
        public bool? DynamicRegistration { get; set; }
    }
}