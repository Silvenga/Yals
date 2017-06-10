namespace Yals.JsonRpc.Parsers.Tokens
{
    public class MessageBodySeparator : ParsingToken
    {
        public MessageBodySeparator(ParsingToken parent) : base(parent)
        {
        }

        public override ParsingToken Process(BufferedSeeker input, ParsingToken lastToken)
        {
            input.PeekUntil(x => x.Count == 2);
            return Parent;
        }
    }
}