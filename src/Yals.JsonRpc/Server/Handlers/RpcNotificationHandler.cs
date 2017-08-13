using System.Threading.Tasks;

namespace Yals.JsonRpc.Server.Handlers
{
    public abstract class RpcNotificationHandler<T>: BaseRpcHandler
    {
        public abstract Task HandleRequestAsync(IExecutionContext context, T notification);
    }
}