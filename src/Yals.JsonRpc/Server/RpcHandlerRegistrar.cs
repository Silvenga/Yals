using System.Collections.Generic;
using System.Linq;

using Yals.JsonRpc.Server.Handlers;
using Yals.JsonRpc.Server.Registrations;

namespace Yals.JsonRpc.Server
{
    public interface IRpcHandlerRegistrar
    {
        IList<IHandlerRegistration> GetRegistrations(IEncounterContext context);
    }

    public class RpcHandlerRegistrar : IRpcHandlerRegistrar
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

        public IList<IHandlerRegistration> GetRegistrations(IEncounterContext context)
        {
            return _registrations.Where(x => x.CanHandle(context)).ToList();
        }
    }

    public interface IEncounterContext
    {
        string Method { get; }
    }

    public interface IEncounterResult
    {
        object Result { get; set; }
    }
}