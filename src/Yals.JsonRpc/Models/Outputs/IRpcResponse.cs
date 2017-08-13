using JetBrains.Annotations;

using Newtonsoft.Json;

namespace Yals.JsonRpc.Models.Outputs
{
    public interface IRpcResponse<T> : IRpcOutputMessage
    {
        [JsonProperty("result")]
        T Result { get; set; }

        [JsonProperty("id"), CanBeNull]
        RpcId Id { get; set; }
    }
}