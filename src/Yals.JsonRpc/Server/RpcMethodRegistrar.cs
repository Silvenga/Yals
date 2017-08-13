using System.Collections.Generic;

using Yals.JsonRpc.Server.Handlers;
using Yals.JsonRpc.Server.Registrations;

namespace Yals.JsonRpc.Server
{
    public class RpcMethodRegistrar
    {
        private readonly IList<IHandlerRegistration> _registrations = new List<IHandlerRegistration>();

        public void RegisterRequest<THandler, TRequest>(string method, THandler handler) where THandler : RpcRequestHandler<TRequest>
        {
            var registration = new NamedRequestHandlerRegistration<RpcRequestHandler<TRequest>, TRequest>(method, handler);
            _registrations.Add(registration);
        }

        public void RegisterNotification<THandler, TRequest>(string method, THandler handler) where THandler : RpcNotificationHandler<TRequest>
        {
            var registration = new NamedNotificationHandlerRegistration<RpcNotificationHandler<TRequest>, TRequest>(method, handler);
            _registrations.Add(registration);
        }
    }

    public interface IExecutionContext
    {
        string Method { get; }
    }

    public interface IExecutionResult
    {
        object Result { get; set; }
    }
}