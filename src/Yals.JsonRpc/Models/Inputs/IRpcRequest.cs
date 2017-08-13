using JetBrains.Annotations;

using Newtonsoft.Json;

namespace Yals.JsonRpc.Models.Inputs
{
    public interface IRpcRequest<T> : IRpcInputMessage
    {
        [JsonProperty("id"), CanBeNull]
        RpcId Id { get; set; }

        [JsonProperty("method")]
        string Method { get; set; }

        [JsonProperty("params")]
        T Parameters { get; set; }
    }

    public class RpcRequest<T> : IRpcRequest<T>
    {
        public string JsonRpc { get; set; }
        public RpcId Id { get; set; }
        public string Method { get; set; }
        public T Parameters { get; set; }
    }
}