using Newtonsoft.Json;

namespace Yals.Requests.Initialize.Response
{
    /// <summary>
    /// Format document on type options
    /// </summary>
    public class DocumentOnTypeFormattingOptions
    {
        /// <summary>
        /// A character on which formatting should be triggered, like `}`.
        /// </summary>
        [JsonProperty("firstTriggerCharacter")]
        public string FirstTriggerCharacter { get; set; }

        /// <summary>
        /// More trigger characters.
        /// </summary>
        [JsonProperty("moreTriggerCharacter")]
        public string[] MoreTriggerCharacter { get; set; }
    }
}