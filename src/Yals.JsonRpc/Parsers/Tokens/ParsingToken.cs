namespace Yals.JsonRpc.Parsers.Tokens
{
    public abstract class ParsingToken
    {
        protected ParsingToken Parent { get; }

        protected ParsingToken(ParsingToken parent)
        {
            Parent = parent;
        }

        public abstract ParsingToken Process(BufferedSeeker input, ParsingToken lastToken);
    }
}