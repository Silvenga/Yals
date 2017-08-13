using Newtonsoft.Json;

namespace Yals.JsonRpc.Models.Inputs
{
    public interface IRpcNotification<T> : IRpcInputMessage
    {
        [JsonProperty("method")]
        string Method { get; set; }

        [JsonProperty("params")]
        T Parameters { get; set; }
    }

    public class RpcNotification<T> : IRpcNotification<T>
    {
        public string JsonRpc { get; set; }
        public string Method { get; set; }
        public T Parameters { get; set; }
    }
}