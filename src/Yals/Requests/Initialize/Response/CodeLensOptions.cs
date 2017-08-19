using Newtonsoft.Json;

namespace Yals.Requests.Initialize.Response
{
    /// <summary>
    /// Code Lens options.
    /// </summary>
    public class CodeLensOptions
    {
        /// <summary>
        /// Code lens has a resolve provider as well.
        /// </summary>
        [JsonProperty("resolveProvider")]
        public bool? ResolveProvider { get; set; }
    }
}