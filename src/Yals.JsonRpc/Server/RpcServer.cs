using System;
using System.Collections.Generic;

namespace Yals.JsonRpc.Server
{
    public class RpcServer
    {
        private Dictionary<string, Func<IExecutionContext, string, string>> Dictionary = new Dictionary<string, Func<IExecutionContext, string, string>>();

        public void RegisterRoute<TRoute, TRequest, TResponse>(string method) where TRoute : IRpcRoute<TRequest, TResponse>, new()
        {
            if (Dictionary.ContainsKey(method))
            {
                throw new NotSupportedException($"Method {method} has already been registered. Only one registration per method is allowed.");
            }

            var route = new TRoute();

            //Dictionary.Add(method, (context, s) =>
            //{
            //});
        }
    }

    public interface IRpcRoute<TRequest, TResponse>
    {
        TResponse Handle(IExecutionContext context, TRequest request);
    }

    public interface IExecutionContext
    {
        string Method { get; }
    }

    public class RpcMessageConverter
    {
        public void JsonToGenericMessage(string jsonMessage)
        {
            
        }
    }
}