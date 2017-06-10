using System.Linq;

namespace Yals.JsonRpc.Parsers.Tokens
{
    public class HeaderFieldName : ParsingToken
    {
        public string Name { get; set; }

        public HeaderFieldName(HeaderField parent) : base(parent)
        {
        }

        public override ParsingToken Process(BufferedSeeker input, ParsingToken lastToken)
        {
            var peek = input.PeekUntil(x => x.Last() == ':');

            Name = new string(peek.Take(peek.Count - 1).ToArray());
            input.BacktrackPeek(1);
            return Parent;
        }
    }
}