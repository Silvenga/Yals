using Newtonsoft.Json;

namespace Yals.Requests.Initialize.WorkspaceClientCapabilities
{
    public class ExecuteCommandClientCapabilities
    {
        /// <summary>
        /// Execute command supports dynamic registration.
        /// </summary>
        [JsonProperty("dynamicRegistration")]
        public bool? DynamicRegistration { get; set; }
    }
}