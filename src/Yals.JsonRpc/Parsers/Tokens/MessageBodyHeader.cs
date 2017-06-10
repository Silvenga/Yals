using System.Collections.Generic;
using System.Linq;

namespace Yals.JsonRpc.Parsers.Tokens
{
    public class MessageBodyHeader : ParsingToken
    {
        public Dictionary<string, string> Headers { get; } = new Dictionary<string, string>();

        public int ContentLength { get; private set; } = -1;

        public MessageBodyHeader(MessageBody parent) : base(parent)
        {
        }

        public override ParsingToken Process(BufferedSeeker input, ParsingToken lastToken)
        {
            switch (lastToken)
            {
                case HeaderField token:
                    Headers.Add(token.Name, token.Value);
                    ProcessHeaders(token.Name, token.Value);
                    break;
            }

            var peek = input.PeekUntil(x => x.Count == 2);
            input.BacktrackPeek(2);
            if (peek.First() == '\r' && peek.Last() == '\n')
            {
                return Parent;
            }
            return new HeaderField(this);
        }

        private void ProcessHeaders(string name, string value)
        {
            switch (name)
            {
                case "Content-Length":
                    ContentLength = int.Parse(value);
                    break;
            }
        }
    }
}