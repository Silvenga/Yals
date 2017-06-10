using System.Collections.Generic;

namespace Yals.JsonRpc.Parsers.Tokens
{
    public class MessageBodyCompleted : ParsingToken
    {
        public Dictionary<string, string> Headers { get; }
        public string ContentPart { get; }

        public MessageBodyCompleted(MessageBody parent) : base(parent)
        {
            Headers = parent.MessageBodyHeader.Headers;
            ContentPart = parent.ContentMessageBody.Content;
        }

        public override ParsingToken Process(BufferedSeeker input, ParsingToken lastToken)
        {
            return Parent;
        }
    }
}