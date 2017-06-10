using System;
using System.Collections.Generic;
using System.Linq;

namespace Yals.JsonRpc.Parsers
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
            return new MessageBodyToken(this);
        }
    }

    public class MessageBodyToken : ParsingToken
    {
        public HeaderPart HeaderPart { get; set; }
        public ContentPart ContentPart { get; set; }

        public MessageBodyToken(MessageStream parent) : base(parent)
        {
        }

        public override ParsingToken Process(BufferedSeeker input, ParsingToken lastToken)
        {
            switch (lastToken)
            {
                case MessageStream token:
                    return new HeaderPart(this);
                case HeaderPart token:
                    HeaderPart = token;
                    return new SeparatorPart(this);
                case SeparatorPart token:
                    return new ContentPart(this, HeaderPart.ContentLength);
                case ContentPart token:
                    ContentPart = token;
                    return new MessageBodyCompleteToken(this);
                case MessageBodyCompleteToken token:
                    break;
            }

            return Parent;
        }
    }

    public class MessageBodyCompleteToken : ParsingToken
    {
        public Dictionary<string, string> Headers { get; }
        public string ContentPart { get; }

        public MessageBodyCompleteToken(MessageBodyToken parent) : base(parent)
        {
            Headers = parent.HeaderPart.Headers;
            ContentPart = parent.ContentPart.Content;
        }

        public override ParsingToken Process(BufferedSeeker input, ParsingToken lastToken)
        {
            return Parent;
        }
    }

    public class HeaderPart : ParsingToken
    {
        public Dictionary<string, string> Headers { get; } = new Dictionary<string, string>();

        public int ContentLength { get; private set; } = -1;

        public HeaderPart(MessageBodyToken parent) : base(parent)
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

    public class HeaderField : ParsingToken
    {
        public string Name { get; private set; }

        public string Value { get; private set; }

        public HeaderField(HeaderPart parent) : base(parent)
        {
        }

        public override ParsingToken Process(BufferedSeeker input, ParsingToken lastToken)
        {
            switch (lastToken)
            {
                case HeaderPart _:
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

    public class SeparatorPart : ParsingToken
    {
        public SeparatorPart(ParsingToken parent) : base(parent)
        {
        }

        public override ParsingToken Process(BufferedSeeker input, ParsingToken lastToken)
        {
            input.PeekUntil(x => x.Count == 2);
            return Parent;
        }
    }

    public class ContentPart : ParsingToken
    {
        private readonly int _connectLength;

        public string Content { get; set; }

        public ContentPart(MessageBodyToken parent, int connectLength) : base(parent)
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