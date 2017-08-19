using Newtonsoft.Json;

namespace Yals.Requests.Initialize.TextDocumentClientCapabilities
{
    public class TextDocumentClientCapabilities
    {
        /// <summary>
        /// None?
        /// </summary>
        [JsonProperty("synchronization")]
        public SynchronizationClientCapabilities Synchronization { get; set; }

        /// <summary>
        /// Capabilities specific to the `textDocument/completion`
        /// </summary>
        [JsonProperty("completion")]
        public CompletionClientCapabilities Completion { get; set; }

        /// <summary>
        /// Capabilities specific to the `textDocument/hover`
        /// </summary>
        [JsonProperty("hover")]
        public HoverClientCapabilities Hover { get; set; }

        /// <summary>
        /// Capabilities specific to the `textDocument/signatureHelp`
        /// </summary>
        [JsonProperty("signatureHelp")]
        public SignatureHelpClientCapabilities SignatureHelp { get; set; }

        /// <summary>
        /// Capabilities specific to the `textDocument/references`
        /// </summary>
        [JsonProperty("references")]
        public ReferencesClientCapabilities References { get; set; }

        /// <summary>
        /// Capabilities specific to the `textDocument/documentHighlight`
        /// </summary>
        [JsonProperty("documentHighlight")]
        public DocumentHighlightClientCapabilities DocumentHighlight { get; set; }

        /// <summary>
        /// Capabilities specific to the `textDocument/documentSymbol`
        /// </summary>
        [JsonProperty("documentSymbol")]
        public DocumentSymbolClientCapabilities DocumentSymbol { get; set; }

        /// <summary>
        /// Capabilities specific to the `textDocument/formatting`
        /// </summary>
        [JsonProperty("formatting")]
        public FormattingClientCapabilities Formatting { get; set; }

        /// <summary>
        /// Capabilities specific to the `textDocument/rangeFormatting`
        /// </summary>
        [JsonProperty("rangeFormatting")]
        public RangeFormattingClientCapabilities RangeFormatting { get; set; }

        /// <summary>
        /// Capabilities specific to the `textDocument/onTypeFormatting`
        /// </summary>
        [JsonProperty("onTypeFormatting")]
        public OnTypeFormattingClientCapabilities OnTypeFormatting { get; set; }

        /// <summary>
        /// Capabilities specific to the `textDocument/definition`
        /// </summary>
        [JsonProperty("definition")]
        public DefinitionClientCapabilities Definition { get; set; }

        /// <summary>
        /// Capabilities specific to the `textDocument/codeAction`
        /// </summary>
        [JsonProperty("codeAction")]
        public CodeActionClientCapabilities CodeAction { get; set; }

        /// <summary>
        /// Capabilities specific to the `textDocument/codeLens`
        /// </summary>
        [JsonProperty("codeLens")]
        public CodeLensClientCapabilities CodeLens { get; set; }

        /// <summary>
        /// Capabilities specific to the `textDocument/documentLink`
        /// </summary>
        [JsonProperty("documentLink")]
        public DocumentLinkClientCapabilities DocumentLink { get; set; }

        /// <summary>
        /// Capabilities specific to the `textDocument/rename`
        /// </summary>
        [JsonProperty("rename")]
        public RenameClientCapabilities Rename { get; set; }
    }
}