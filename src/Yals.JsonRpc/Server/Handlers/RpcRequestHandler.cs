using System.Threading.Tasks;

namespace Yals.JsonRpc.Server.Handlers
{
    public abstract class RpcRequestHandler<T> : BaseRpcHandler
    {
        public abstract Task<IExecutionResult> HandleRequestAsync(IExecutionContext context, T request);

        public virtual IExecutionResult Success<TResponse>(TResponse response)
        {
            return new SuccessfulExecution<TResponse>(response);
        }
    }

    public class SuccessfulExecution<T> : IExecutionResult
    {
        public object Result { get; set; }

        public SuccessfulExecution(T response)
        {
            Result = response;
        }
    }
}