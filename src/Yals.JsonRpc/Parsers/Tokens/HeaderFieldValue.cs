using System.Linq;

namespace Yals.JsonRpc.Parsers.Tokens
{
    public class HeaderFieldValue : ParsingToken
    {
        public string Value { get; set; }

        public HeaderFieldValue(HeaderField parent) : base(parent)
        {
        }

        public override ParsingToken Process(BufferedSeeker input, ParsingToken lastToken)
        {
            var peek = input.PeekUntil(x => x.Last() == '\n').ToArray();
            Value = new string(peek);
            return Parent;
        }
    }
}