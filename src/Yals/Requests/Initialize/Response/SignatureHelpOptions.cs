using Newtonsoft.Json;

namespace Yals.Requests.Initialize.Response
{
    /// <summary>
    /// Signature help options.
    /// </summary>
    public class SignatureHelpOptions
    {
        /// <summary>
        /// The characters that trigger signature help automatically.
        /// </summary>
        [JsonProperty("triggerCharacters")]
        public string[] TriggerCharacters { get; set; }
    }
}