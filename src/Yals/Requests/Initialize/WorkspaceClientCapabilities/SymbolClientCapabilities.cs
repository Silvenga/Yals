using Newtonsoft.Json;

namespace Yals.Requests.Initialize.WorkspaceClientCapabilities
{
    public class SymbolClientCapabilities
    {
        /// <summary>
        /// Symbol request supports dynamic registration.
        /// </summary>
        [JsonProperty("dynamicRegistration")]
        public bool? DynamicRegistration { get; set; }
    }
}