using Newtonsoft.Json;

namespace Yals.Requests.Initialize.WorkspaceClientCapabilities
{
    public class WorkspaceClientCapabilities
    {
        /// <summary>
        /// The client supports applying batch edits to the workspace by supporting the request 'workspace/applyEdit'
        /// </summary>
        [JsonProperty("applyEdit")]
        public bool? ApplyEdit { get; set; }

        /// <summary>
        /// Capabilities specific to `WorkspaceEdit`s
        /// </summary>
        [JsonProperty("workspaceEdit")]
        public WorkspaceEditClientCapabilities WorkspaceEdit { get; set; }

        /// <summary>
        /// Capabilities specific to the `workspace/didChangeConfiguration` notification.
        /// </summary>
        [JsonProperty("didChangeConfiguration")]
        public DidChangeConfigurationClientCapabilities DidChangeConfiguration { get; set; }

        /// <summary>
        /// Capabilities specific to the `workspace/didChangeWatchedFiles` notification.
        /// </summary>
        [JsonProperty("didChangeWatchedFiles")]
        public DidChangeWatchedFilesClientCapabilities DidChangeWatchedFiles { get; set; }

        /// <summary>
        /// Capabilities specific to the `workspace/symbol` request.
        /// </summary>
        [JsonProperty("symbol")]
        public SymbolClientCapabilities Symbol { get; set; }

        /// <summary>
        /// Capabilities specific to the `workspace/executeCommand` request.
        /// </summary>
        [JsonProperty("executeCommand")]
        public ExecuteCommandClientCapabilities ExecuteCommand { get; set; }

    }
}