using System.IO;
using System.Linq;

using FluentAssertions;

using Xunit;

using Yals.JsonRpc.Parsers;
using Yals.JsonRpc.Parsers.Tokens;

namespace Yals.JsonRpc.Tests.Parsers
{
    public class ParserHelpersFacts
    {
        [Fact]
        public void Test()
        {
            var stream = File.OpenRead(@"Assets\initialize.rpc");
            var reader = new StreamReader(stream);

            // Act
            var tokens = reader.StreamToBlocks().StreamToTokens().OfType<MessageBodyCompleted>().ToList();

            // Assert
            tokens.Should().HaveCount(2);
        }
    }
}