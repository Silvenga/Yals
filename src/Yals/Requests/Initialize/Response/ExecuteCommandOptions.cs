using Newtonsoft.Json;

namespace Yals.Requests.Initialize.Response
{
    /// <summary>
    /// Execute command options.
    /// </summary>
    public class ExecuteCommandOptions
    {
        /// <summary>
        /// More trigger characters.
        /// </summary>
        [JsonProperty("commands")]
        public string[] Commands { get; set; }
    }
}