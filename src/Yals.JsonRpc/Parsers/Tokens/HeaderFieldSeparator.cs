using System.Linq;

namespace Yals.JsonRpc.Parsers.Tokens
{
    public class HeaderFieldSeparator : ParsingToken
    {
        public string Value { get; set; }

        public HeaderFieldSeparator(HeaderField parent) : base(parent)
        {
        }

        public override ParsingToken Process(BufferedSeeker input, ParsingToken lastToken)
        {
            var peek = input.PeekUntil(x => x.Last() != ':' && x.Last() != ' ');
            Value = new string(peek.Take(peek.Count - 1).ToArray());
            input.BacktrackPeek(1);
            return Parent;
        }
    }
}