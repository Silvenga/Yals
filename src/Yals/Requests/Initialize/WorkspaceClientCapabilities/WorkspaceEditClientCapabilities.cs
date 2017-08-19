using Newtonsoft.Json;

namespace Yals.Requests.Initialize.WorkspaceClientCapabilities
{
    public class WorkspaceEditClientCapabilities
    {
        /// <summary>
        /// The client supports versioned document changes in `WorkspaceEdit`s
        /// </summary>
        [JsonProperty("documentChanges")]
        public bool? DocumentChanges { get; set; }
    }
}