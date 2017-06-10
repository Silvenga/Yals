using System;

namespace Yals.JsonRpc.Parsers.Tokens
{
    public class MessageBodyContent : ParsingToken
    {
        private readonly int _connectLength;

        public string Content { get; private set; }

        public MessageBodyContent(MessageBody parent, int connectLength) : base(parent)
        {
            if (connectLength == -1)
            {
                throw new Exception("Content is being parsed, but no content length header was found.");
            }
            _connectLength = connectLength;
        }

        public override ParsingToken Process(BufferedSeeker input, ParsingToken lastToken)
        {
            var peek = input.PeekUntil(x => x.Count == _connectLength);
            Content = new string(peek.ToArray());
            return Parent;
        }
    }
}