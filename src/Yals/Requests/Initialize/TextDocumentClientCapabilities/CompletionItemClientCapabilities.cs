using Newtonsoft.Json;

namespace Yals.Requests.Initialize.TextDocumentClientCapabilities
{
    public class CompletionItemClientCapabilities
    {
        /// <summary>
        /// Client supports snippets as insert text.
        /// 
        /// A snippet can define tab stops and placeholders with `$1`, `$2` and `${3:foo}`. 
        /// `$0` defines the final tab stop, it defaults to the end of the snippet. 
        /// Placeholders with equal identifiers are linked, 
        /// that is typing in one will update others too.
        /// </summary>
        [JsonProperty("snippetSupport")]
        public bool? SnippetSupport { get; set; }
    }
}