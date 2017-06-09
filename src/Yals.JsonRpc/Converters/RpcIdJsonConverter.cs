using System;

using Newtonsoft.Json;

using Yals.JsonRpc.Models;

namespace Yals.JsonRpc.Converters
{
    public class RpcIdJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var id = (RpcId) value;

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
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                    return new RpcId(reader.Value.ToString(), RpcIdKind.Number);
                case JsonToken.String:
                    return new RpcId(reader.Value.ToString(), RpcIdKind.String);
                default:
                    throw new NotImplementedException("Unknown RPC Id Kind.");
            }
        }
    }
}