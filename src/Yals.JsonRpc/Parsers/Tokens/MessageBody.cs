namespace Yals.JsonRpc.Parsers.Tokens
{
    public class MessageBody : ParsingToken
    {
        public MessageBodyHeader MessageBodyHeader { get; set; }
        public MessageBodyContent ContentMessageBody { get; set; }

        public MessageBody(MessageStream parent) : base(parent)
        {
        }

        public override ParsingToken Process(BufferedSeeker input, ParsingToken lastToken)
        {
            switch (lastToken)
            {
                case MessageStream token:
                    return new MessageBodyHeader(this);
                case MessageBodyHeader token:
                    MessageBodyHeader = token;
                    return new MessageBodySeparator(this);
                case MessageBodySeparator token:
                    return new MessageBodyContent(this, MessageBodyHeader.ContentLength);
                case MessageBodyContent token:
                    ContentMessageBody = token;
                    return new MessageBodyCompleted(this);
                case MessageBodyCompleted token:
                    break;
            }

            return Parent;
        }
    }
}