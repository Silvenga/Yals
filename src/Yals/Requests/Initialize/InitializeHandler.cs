using System.Threading.Tasks;

using Yals.JsonRpc.Server;
using Yals.JsonRpc.Server.Handlers;

namespace Yals.Requests.Initialize
{
    public class InitializeHandler : RpcRequestHandler<InitializeRequest>
    {
        public override Task<IEncounterResult> HandleRequestAsync(IEncounterContext context, InitializeRequest initializeRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}