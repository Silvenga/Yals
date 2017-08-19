using Newtonsoft.Json;

namespace Yals.Requests.Initialize.Response
{
    /// <summary>
    /// Completion options.
    /// </summary>
    public class CompletionOptions
    {
        /// <summary>
        /// The server provides support to resolve additional information for a completion item.
        /// </summary>
        [JsonProperty("resolveProvider")]
        public bool? ResolveProvider { get; set; }

        /// <summary>
        /// The characters that trigger completion automatically.
        /// </summary>
        [JsonProperty("triggerCharacters")]
        public string[] TriggerCharacters { get; set; }
    }
}