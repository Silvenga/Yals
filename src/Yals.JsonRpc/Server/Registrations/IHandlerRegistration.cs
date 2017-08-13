using System.Threading.Tasks;

using Newtonsoft.Json.Linq;

namespace Yals.JsonRpc.Server.Registrations
{
    public interface IHandlerRegistration
    {
        bool CanHandle(IEncounterContext context);
    }

    public interface IRequestHandlerRegistration : IHandlerRegistration
    {
        Task<object> HandleRequest(IEncounterContext context, JToken parameters);
    }

    public interface INotificationHandlerRegistration : IHandlerRegistration
    {
        Task HandleNotification(IEncounterContext context, JToken parameters);
    }
}