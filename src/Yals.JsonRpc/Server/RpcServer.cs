using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Yals.JsonRpc.Models.Inputs;
using Yals.JsonRpc.Server.Registrations;

namespace Yals.JsonRpc.Server
{
    public class RpcServer
    {
        private readonly IRpcHandlerRegistrar _handlerRegistrar;

        public RpcServer(IRpcHandlerRegistrar handlerRegistrar)
        {
            _handlerRegistrar = handlerRegistrar;
        }

        public async Task ProcessEncounter(string rpcMessageJson)
        {
            var message = JsonConvert.DeserializeObject<IRpcInputMessage>(rpcMessageJson);

            var context = new EncounterContext(message.Method);
            var possibleHandlers = _handlerRegistrar.GetRegistrations(context);

            switch (message)
            {
                case IRpcRequest<JToken> request:
                    await ProcessRequest(context, possibleHandlers.OfType<IRequestHandlerRegistration>().ToList(), request);
                    break;
                case IRpcNotification<JToken> notification:
                    await ProcessNotification(context, possibleHandlers.OfType<INotificationHandlerRegistration>().ToList(), notification);
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Don't know how to handle message of type ${message.GetType()}");
            }

            throw new NotImplementedException();
        }

        private async Task ProcessRequest(EncounterContext context, IList<IRequestHandlerRegistration> possibleHandlers, IRpcRequest<JToken> message)
        {
            if (!possibleHandlers.Any())
            {
                throw new Exception($"No handlers registered to respond to encounter with method '${message}'."); // TODO Update this exception type.
            }
            if (possibleHandlers.Count > 1)
            {
                throw new Exception($"Multiple handlers registered to respond to encounter with method '${message}'."); // TODO Update this exception type.
            }

            var handler = possibleHandlers.Single();
            var result = await handler.HandleRequest(context, message.Parameters);
        }

        private async Task ProcessNotification(EncounterContext context, IList<INotificationHandlerRegistration> possibleHandlers,
                                               IRpcNotification<JToken> message)
        {
            foreach (var handler in possibleHandlers)
            {
                await handler.HandleNotification(context, message.Parameters);
            }
        }
    }

    public class EncounterContext : IEncounterContext
    {
        public string Method { get; }

        public EncounterContext(string method)
        {
            Method = method;
        }
    }
}