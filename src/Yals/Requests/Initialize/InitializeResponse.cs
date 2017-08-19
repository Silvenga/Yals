using Yals.Requests.Initialize.Response;

namespace Yals.Requests.Initialize
{
    public class InitializeResponse
    {
        /// <summary>
        /// The capabilities the language server provides.
        /// </summary>
        public ServerCapabilities Capabilities { get; set; }
    }
}