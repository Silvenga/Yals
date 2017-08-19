using Newtonsoft.Json;

namespace Yals.Requests.Initialize
{
    public class ClientCapabilities
    {
        /// <summary>
        /// Workspace specific client capabilities.
        /// </summary>
        [JsonProperty("workspace")]
        public WorkspaceClientCapabilities.WorkspaceClientCapabilities Workspace { get; set; }

        /// <summary>
        /// Text document specific client capabilities.
        /// </summary>
        [JsonProperty("textDocument")]
        public TextDocumentClientCapabilities.TextDocumentClientCapabilities TextDocument { get; set; }

        /// <summary>
        /// Experimental client capabilities.
        /// </summary>
        [JsonProperty("experimental")]
        public object Experimental { get; set; }
    }
}