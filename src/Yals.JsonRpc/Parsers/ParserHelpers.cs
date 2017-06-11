using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Yals.JsonRpc.Parsers.Tokens;

namespace Yals.JsonRpc.Parsers
{
    public static class ParserHelpers
    {
        public static IEnumerable<char[]> StreamToBlocks(this StreamReader reader)
        {
            // TODO Should we find encoding later?
            const int bufferSize = 1024;
            var buffer = new char[bufferSize];
            int blockLength;
            while ((blockLength = reader.ReadBlock(buffer, 0, buffer.Length)) > 0)
            {
                var workArea = new char[blockLength];
                Array.Copy(buffer, 0, workArea, 0, blockLength);
                yield return workArea;
            }
        }

        public static IEnumerable<ParsingToken> StreamToTokens(this IEnumerable<char[]> enumerable)
        {
            var enumerator = enumerable.SelectMany(x => x).GetEnumerator();
            using (var seeker = new BufferedSeeker(enumerator))
            {
                ParsingToken currentToken = new MessageStream();
                ParsingToken lastToken = null;
                ParsingToken tempToken;
                while ((tempToken = currentToken.Process(seeker, lastToken)) != null)
                {
                    seeker.SeekToPeek();
                    lastToken = currentToken;
                    yield return currentToken;
                    currentToken = tempToken;
                }
            }
        }
    }
}