using System.Threading.Tasks;

namespace Yals.JsonRpc.Server.Handlers
{
    public abstract class RpcNotificationHandler<T>: BaseRpcHandler
    {
        public abstract Task HandleRequestAsync(IEncounterContext context, T notification);
    }
}