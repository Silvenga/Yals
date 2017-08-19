using Newtonsoft.Json;

namespace Yals.Requests.Initialize.Response
{
    /// <summary>
    /// Document link options
    /// </summary>
    public class DocumentLinkOptions
    {
        /// <summary>
        /// Document links have a resolve provider as well.
        /// </summary>
        [JsonProperty("resolveProvider")]
        public bool? ResolveProvider { get; set; }
    }
}