using Newtonsoft.Json;

namespace Yals.Requests.Initialize.TextDocumentClientCapabilities
{
    public class CodeActionClientCapabilities
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("dynamicRegistration")]
        public bool? DynamicRegistration { get; set; }
    }
}