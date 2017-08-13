using Newtonsoft.Json;

using Yals.JsonRpc.Converters;

namespace Yals.JsonRpc.Models.Inputs
{
    [JsonConverter(typeof(RpcInputMessageConverter))]
    public interface IRpcInputMessage : IRpcMessage
    {
        [JsonProperty("method")]
        string Method { get; set; }
    }
}