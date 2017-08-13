using System;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;

using Yals.JsonRpc.Server.Handlers;

namespace Yals.JsonRpc.Server.Registrations
{
    public class NamedHandlerRegistration : IHandlerRegistration
    {
        public string Method { get; }

        public NamedHandlerRegistration(string method)
        {
            Method = method;
        }

        public bool CanHandle(IExecutionContext context)
        {
            return Method.Equals(context.Method, StringComparison.OrdinalIgnoreCase);
        }
    }

    public class NamedRequestHandlerRegistration<THandler, TRequest> : NamedHandlerRegistration, IRequestHandlerRegistration where THandler : RpcRequestHandler<TRequest>
    {
        public THandler Handler { get; }

        public NamedRequestHandlerRegistration(string method, THandler handler) : base(method)
        {
            Handler = handler;
        }

        public async Task<object> HandleRequest(IExecutionContext context, JToken parameters)
        {
            var response = await Handler.HandleRequestAsync(context, parameters.ToObject<TRequest>());
            return response;
        }
    }

    public class NamedNotificationHandlerRegistration<THandler, TRequest> : NamedHandlerRegistration, INotificationHandlerRegistration where THandler : RpcNotificationHandler<TRequest>
    {
        public THandler Handler { get; }

        public NamedNotificationHandlerRegistration(string method, THandler handler) : base(method)
        {
            Handler = handler;
        }

        public async Task HandleNotification(IExecutionContext context, JToken parameters)
        {
            await Handler.HandleRequestAsync(context, parameters.ToObject<TRequest>());
        }
    }
}