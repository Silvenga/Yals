using System.Threading.Tasks;

using Newtonsoft.Json.Linq;

namespace Yals.JsonRpc.Server.Registrations
{
    public interface IHandlerRegistration
    {
        bool CanHandle(IExecutionContext context);
    }

    public interface IRequestHandlerRegistration : IHandlerRegistration
    {
        Task<object> HandleRequest(IExecutionContext context, JToken parameters);
    }

    public interface INotificationHandlerRegistration : IHandlerRegistration
    {
        Task HandleNotification(IExecutionContext context, JToken parameters);
    }
}