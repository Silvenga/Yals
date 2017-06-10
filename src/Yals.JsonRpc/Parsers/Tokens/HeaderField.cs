namespace Yals.JsonRpc.Parsers.Tokens
{
    public class HeaderField : ParsingToken
    {
        public string Name { get; private set; }

        public string Value { get; private set; }

        public HeaderField(MessageBodyHeader parent) : base(parent)
        {
        }

        public override ParsingToken Process(BufferedSeeker input, ParsingToken lastToken)
        {
            switch (lastToken)
            {
                case MessageBodyHeader _:
                    return new HeaderFieldName(this);
                case HeaderFieldName token:
                    Name = token.Name;
                    return new HeaderFieldSeparator(this);
                case HeaderFieldSeparator token:
                    return new HeaderFieldValue(this);
                case HeaderFieldValue token:
                    Value = token.Value;
                    break;
            }

            return Parent;
        }
    }
}