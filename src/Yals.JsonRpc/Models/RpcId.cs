using Newtonsoft.Json;

using Yals.JsonRpc.Converters;

namespace Yals.JsonRpc.Models
{
    [JsonConverter(typeof(RpcIdJsonConverter))]
    public class RpcId
    {
        public string Value { get; }

        public RpcIdKind Kind { get; }

        public RpcId(string value, RpcIdKind kind)
        {
            Value = value;
            Kind = kind;
        }
    }

    public enum RpcIdKind
    {
        String,
        Number
    }
}