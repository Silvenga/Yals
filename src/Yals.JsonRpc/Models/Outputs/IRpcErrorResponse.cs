using JetBrains.Annotations;

using Newtonsoft.Json;

namespace Yals.JsonRpc.Models.Outputs
{
    public interface IRpcErrorResponse : IRpcOutputMessage
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
        public const int InvalidParams = -32602;
        public const int InternalError = -32603;
        public const int ServerErrorStart = -32099;
        public const int ServerErrorEnd = -32000;
        public const int ServerNotInitialized = -32002;
        public const int UnknownErrorCode = -32001;

        public const int RequestCancelled = -32800;
    }
}