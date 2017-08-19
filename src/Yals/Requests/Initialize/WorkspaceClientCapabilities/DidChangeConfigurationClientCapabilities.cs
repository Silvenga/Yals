using Newtonsoft.Json;

namespace Yals.Requests.Initialize.WorkspaceClientCapabilities
{
    public class DidChangeConfigurationClientCapabilities
    {
        /// <summary>
        /// Did change configuration notification supports dynamic registration.
        /// </summary>
        [JsonProperty("dynamicRegistration")]
        public bool? DynamicRegistration { get; set; }
    }
}