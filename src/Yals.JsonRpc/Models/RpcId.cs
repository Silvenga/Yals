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

        protected bool Equals(RpcId other)
        {
            return string.Equals(Value, other.Value) && Kind == other.Kind;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((RpcId) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Value != null ? Value.GetHashCode() : 0) * 397) ^ (int) Kind;
            }
        }

        public static bool operator ==(RpcId left, RpcId right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(RpcId left, RpcId right)
        {
            return !Equals(left, right);
        }
    }

    public enum RpcIdKind
    {
        String,
        Number
    }
}