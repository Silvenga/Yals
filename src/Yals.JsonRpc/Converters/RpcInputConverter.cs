using System;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Yals.JsonRpc.Models.Inputs;

namespace Yals.JsonRpc.Converters
{
    public class RpcInputMessageConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override bool CanWrite { get; } = false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            var isRequest = jObject.Properties().Any(x => string.Equals(x.Name, "id", StringComparison.OrdinalIgnoreCase));

            var target = isRequest
                ? (object) new RpcRequest<JToken>()
                : new RpcNotification<JToken>();

            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }
    }
}