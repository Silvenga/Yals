using System;

using Newtonsoft.Json;

namespace Yals.Requests.Initialize
{
    public class InitializeRequest
    {
        /// <summary>
        /// The process Id of the parent process that started the server. 
        /// Is null if the process has not been started by another process. 
        /// If the parent process is not alive then the server should exit (see exit notification) its process.
        /// </summary>
        [JsonProperty("processId")]
        public int? ProcessId { get; set; }

        /// <summary>
        /// The rootPath of the workspace. Is null if no folder is open.
        /// </summary>
        [JsonProperty("rootPath"), Obsolete("Deprecated in favor of rootUri.")]
        public string RootPath { get; set; }

        /// <summary>
        /// The rootUri of the workspace. Is null if no folder is open. 
        /// If both `rootPath` and `rootUri` are set `rootUri` wins.
        /// </summary>
        [JsonProperty("rootUri")]
        public Uri RootUri { get; set; }

        /// <summary>
        /// User provided initialization options.
        /// </summary>
        [JsonProperty("initializationOptions")]
        public object InitializationOptions { get; set; }

        /// <summary>
        /// The capabilities provided by the client (editor or tool)
        /// </summary>
        [JsonProperty("capabilities")]
        public ClientCapabilities Capabilities { get; set; }

        /// <summary>
        /// The initial trace setting. If omitted trace is disabled ('off').
        /// </summary>
        [JsonProperty("trace")]
        public string Trace { get; set; }
    }
}