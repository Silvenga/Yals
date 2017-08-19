using Newtonsoft.Json;

namespace Yals.Requests.Initialize.TextDocumentClientCapabilities
{
    public class FormattingClientCapabilities
    {
        /// <summary>
        /// Whether formatting supports dynamic registration.
        /// </summary>
        [JsonProperty("dynamicRegistration")]
        public bool? DynamicRegistration { get; set; }
    }
}