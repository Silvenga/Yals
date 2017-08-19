using Newtonsoft.Json;

namespace Yals.Requests.Initialize.TextDocumentClientCapabilities
{
    public class SynchronizationClientCapabilities
    {
        /// <summary>
        /// Whether text document synchronization supports dynamic registration.
        /// </summary>
        [JsonProperty("dynamicRegistration")]
        public bool? DynamicRegistration { get; set; }

        /// <summary>
        /// The client supports sending will save notifications.
        /// </summary>
        [JsonProperty("willSave")]
        public bool? WillSave { get; set; }

        /// <summary>
        /// The client supports sending a will save request and waits for a response 
        /// providing text edits which will be applied to the document before it is saved.
        /// </summary>
        [JsonProperty("willSaveWaitUntil")]
        public bool? WillSaveWaitUntil { get; set; }

        /// <summary>
        /// The client supports did save notifications.
        /// </summary>
        [JsonProperty("didSave")]
        public bool? DidSave { get; set; }
    }
}