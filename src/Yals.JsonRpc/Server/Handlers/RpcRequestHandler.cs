using System.Threading.Tasks;

namespace Yals.JsonRpc.Server.Handlers
{
    public abstract class RpcRequestHandler<T> : BaseRpcHandler
    {
        public abstract Task<IEncounterResult> HandleRequestAsync(IEncounterContext context, T request);

        public virtual IEncounterResult Success<TResponse>(TResponse response)
        {
            return new SuccessfulEncounter<TResponse>(response);
        }
    }

    public class SuccessfulEncounter<T> : IEncounterResult
    {
        public object Result { get; set; }

        public SuccessfulEncounter(T response)
        {
            Result = response;
        }
    }
}