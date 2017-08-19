using Newtonsoft.Json;

namespace Yals.Requests.Initialize.TextDocumentClientCapabilities
{
    public class CompletionClientCapabilities
    {
        /// <summary>
        /// Whether completion supports dynamic registration.
        /// </summary>
        [JsonProperty("dynamicRegistration")]
        public bool? DynamicRegistration { get; set; }

        /// <summary>
        /// The client supports the following `CompletionItem` specific capabilities.
        /// </summary>
        [JsonProperty("completionItem")]
        public CompletionItemClientCapabilities CompletionItem { get; set; }
    }
}