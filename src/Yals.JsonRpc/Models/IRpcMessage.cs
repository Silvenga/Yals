using Newtonsoft.Json;

namespace Yals.JsonRpc.Models
{
    public interface IRpcMessage
    {
        [JsonProperty("jsonrpc")]
        string JsonRpc { get; set; }
    }
}