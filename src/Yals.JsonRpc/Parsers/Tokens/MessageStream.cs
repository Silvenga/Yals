namespace Yals.JsonRpc.Parsers.Tokens
{
    public class MessageStream : ParsingToken
    {
        public MessageStream() : base(null)
        {
        }

        public override ParsingToken Process(BufferedSeeker input, ParsingToken lastToken)
        {
            if (!input.Peekable())
            {
                return null;
            }
            return new MessageBody(this);
        }
    }
}