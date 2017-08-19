using Newtonsoft.Json;

namespace Yals.Requests.Initialize.Response
{
    public class TextDocumentSyncOptions
    {
        /// <summary>
        /// Experimental server capabilities.
        /// </summary>
        [JsonProperty("openClose")]
        public bool? OpenClose { get; set; }

        /// <summary>
        /// Change notificatins are sent to the server. See TextDocumentSyncKind.None, TextDocumentSyncKind.Full and TextDocumentSyncKind.Incremental.
        /// </summary>
        [JsonProperty("change")]
        public TextDocumentSyncKind Change { get; set; }

        /// <summary>
        /// Will save notifications are sent to the server.
        /// </summary>
        [JsonProperty("willSave")]
        public bool? WillSave { get; set; }

        /// <summary>
        /// Will save wait until requests are sent to the server.
        /// </summary>
        [JsonProperty("willSaveWaitUntil")]
        public bool? WillSaveWaitUntil { get; set; }

        /// <summary>
        /// Save notifications are sent to the server.
        /// </summary>
        [JsonProperty("save")]
        public SaveOptions Save { get; set; }
    }
}