using System;

using Newtonsoft.Json;

namespace Yals.JsonRpc.Models
{
    [JsonConverter(typeof(RpcIdJsonConverter))]
    public class RpcId
    {
        public string Value { get; set; }

        public RpcIdKind Kind { get; set; }
    }

    public enum RpcIdKind
    {
        String,
        Number
    }

    public class RpcIdJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var id = (RpcId)value;

            switch (id.Kind)
            {
                case RpcIdKind.String:
                    writer.WriteValue(id.Value);
                    break;
                case RpcIdKind.Number:
                    writer.WriteValue(int.Parse(id.Value));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Integer)
            {
                return new RpcId
                {
                    Value = reader.Value.ToString(),
                    Kind = RpcIdKind.Number
                };
            }
            if (reader.TokenType == JsonToken.String)
            {
                return new RpcId
                {
                    Value = reader.Value.ToString(),
                    Kind = RpcIdKind.String
                };
            }

            throw new NotImplementedException("Unknown RPC Id Kind.");
        }
    }
}