using JetBrains.Annotations;

using Newtonsoft.Json;

using Yals.JsonRpc.Models;

namespace Yals.JsonRpc
{
    public interface IRpcMessage
    {
        [JsonProperty("jsonrpc")]
        string JsonRpc { get; set; }
    }

    public interface IRpcNotification<T> : IRpcMessage
    {
        [JsonProperty("method")]
        string Method { get; set; }

        [JsonProperty("params")]
        T Parameters { get; set; }
    }

    public interface IRpcRequest<T> : IRpcNotification<T>
    {
        [JsonProperty("id"), CanBeNull]
        RpcId Id { get; set; }
    }

    public interface IRpcResponse<T> : IRpcMessage
    {
        [JsonProperty("result")]
        T Result { get; set; }

        [JsonProperty("id"), CanBeNull]
        RpcId Id { get; set; }
    }

    public interface IRpcErrorResponse : IRpcMessage
    {
        [JsonProperty("error")]
        Error Error { get; set; }

        [JsonProperty("id"), CanBeNull]
        RpcId Id { get; set; }
    }

    public class Error
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public object Data { get; set; }
    }

    public class ErrorCode
    {
        public const int ParseError = -32700;
        public const int InvalidRequest = -32600;
        public const int MethodNotFound = -32601;
        public const int InternalError = -32602;
        public const int ServerError = -32000;
    }
}