using FluentAssertions;

using Newtonsoft.Json;

using Ploeh.AutoFixture;

using Xunit;

using Yals.JsonRpc.Models;

namespace Yals.Tests.JsonRpc
{
    public class RpcIdFacts
    {
        private static readonly Fixture Autofixture = new Fixture();

        [Fact]
        public void When_reading_id_and_is_a_number_then_correctly_parse()
        {
            var numberId = Autofixture.Create<int>();
            var json = $"{numberId}";

            // Act
            var result = JsonConvert.DeserializeObject<RpcId>(json);

            // Assert
            result.Kind.Should().Be(RpcIdKind.Number);
            result.Value.Should().Be(numberId.ToString());
        }

        [Fact]
        public void When_reading_id_and_is_a_string_then_correctly_parse()
        {
            var numberId = Autofixture.Create<int>();
            var json = $"\"{numberId}\"";

            // Act
            var result = JsonConvert.DeserializeObject<RpcId>(json);

            // Assert
            result.Kind.Should().Be(RpcIdKind.String);
            result.Value.Should().Be(numberId.ToString());
        }

        [Fact]
        public void When_writing_id_and_is_a_number_then_write_correctly()
        {
            var id = Autofixture.Create<int>();
            var rpcId = new RpcId(id.ToString(), RpcIdKind.Number);

            // Act
            var result = JsonConvert.SerializeObject(rpcId);

            // Assert
            result.Should().Be($"{id}");
        }

        [Fact]
        public void When_writing_id_and_is_a_string_then_write_correctly()
        {
            var id = Autofixture.Create<int>();
            var rpcId = new RpcId(id.ToString(), RpcIdKind.String);

            // Act
            var result = JsonConvert.SerializeObject(rpcId);

            // Assert
            result.Should().Be($"\"{id}\"");
        }
    }
}