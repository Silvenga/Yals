using Newtonsoft.Json;

namespace Yals.Requests.Initialize.Response
{
    /// <summary>
    /// Save options.
    /// </summary>
    public class SaveOptions
    {
        /// <summary>
        /// The client is supposed to include the content on save.
        /// </summary>
        [JsonProperty("includeText")]
        public bool? IncludeText { get; set; }
    }
}