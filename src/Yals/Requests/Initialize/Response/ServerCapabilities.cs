using Newtonsoft.Json;

namespace Yals.Requests.Initialize.Response
{
    public class ServerCapabilities
    {
        /// <summary>
        /// Defines how text documents are synced. Is either a detailed structure defining each notification or
        /// for backwards compatibility the TextDocumentSyncKind number.
        /// </summary>
        [JsonProperty("textDocumentSync")]
        public TextDocumentSyncOptions TextDocumentSync { get; set; }

        /// <summary>
        /// The server provides hover support.
        /// </summary>
        [JsonProperty("hoverProvider")]
        public bool? HoverProvider { get; set; }

        /// <summary>
        /// The server provides completion support.
        /// </summary>
        [JsonProperty("completionProvider")]
        public CompletionOptions CompletionProvider { get; set; }

        /// <summary>
        /// The server provides signature help support.
        /// </summary>
        [JsonProperty("signatureHelpProvider")]
        public SignatureHelpOptions SignatureHelpProvider { get; set; }

        /// <summary>
        /// The server provides goto definition support.
        /// </summary>
        [JsonProperty("definitionProvider")]
        public bool? DefinitionProvider { get; set; }

        /// <summary>
        /// The server provides find references support.
        /// </summary>
        [JsonProperty("referencesProvider")]
        public bool? ReferencesProvider { get; set; }

        /// <summary>
        /// The server provides document highlight support.
        /// </summary>
        [JsonProperty("documentHighlightProvider")]
        public bool? DocumentHighlightProvider { get; set; }

        /// <summary>
        /// The server provides document symbol support.
        /// </summary>
        [JsonProperty("documentSymbolProvider")]
        public bool? DocumentSymbolProvider { get; set; }

        /// <summary>
        /// The server provides workspace symbol support.
        /// </summary>
        [JsonProperty("workspaceSymbolProvider")]
        public bool? WorkspaceSymbolProvider { get; set; }

        /// <summary>
        /// The server provides code actions.
        /// </summary>
        [JsonProperty("codeActionProvider")]
        public bool? CodeActionProvider { get; set; }

        /// <summary>
        /// TThe server provides code lens.
        /// </summary>
        [JsonProperty("codeLensProvider")]
        public CodeLensOptions CodeLensProvider { get; set; }

        /// <summary>
        /// The server provides document formatting.
        /// </summary>
        [JsonProperty("documentFormattingProvider")]
        public bool? DocumentFormattingProvider { get; set; }

        /// <summary>
        ///  The server provides document range formatting.
        /// </summary>
        [JsonProperty("documentRangeFormattingProvider")]
        public bool? DocumentRangeFormattingProvider { get; set; }

        /// <summary>
        /// The server provides document formatting on typing.
        /// </summary>
        [JsonProperty("documentOnTypeFormattingProvider")]
        public DocumentOnTypeFormattingOptions DocumentOnTypeFormattingProvider { get; set; }

        /// <summary>
        /// The server provides rename support.
        /// </summary>
        [JsonProperty("renameProvider")]
        public bool? RenameProvider { get; set; }

        /// <summary>
        /// The server provides document link support.
        /// </summary>
        [JsonProperty("documentLinkProvider")]
        public DocumentLinkOptions DocumentLinkProvider { get; set; }

        /// <summary>
        /// The server provides execute command support.
        /// </summary>
        [JsonProperty("executeCommandProvider")]
        public ExecuteCommandOptions ExecuteCommandProvider { get; set; }

        /// <summary>
        /// Experimental server capabilities.
        /// </summary>
        [JsonProperty("experimental")]
        public object Experimental { get; set; }
    }
}