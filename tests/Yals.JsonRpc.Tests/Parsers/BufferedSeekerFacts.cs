using System.Linq;

using FluentAssertions;

using Ploeh.AutoFixture;

using Xunit;

using Yals.JsonRpc.Parsers;

namespace Yals.JsonRpc.Tests.Parsers
{
    public class BufferedSeekerFacts
    {
        private static readonly Fixture Autofixture = new Fixture();

        [Fact]
        public void Peek_should_seek_buffer()
        {
            var chars = Autofixture.CreateMany<char>(10).ToList();
            var enumerator = chars.GetEnumerator();
            var seeker = new BufferedSeeker(enumerator);

            // Act
            seeker.Peek();
            var result = seeker.Peek();

            // Assert
            result.Should().Be(chars.Skip(1).First());
            seeker.PeakIndex.Should().Be(2);
        }

        [Fact]
        public void Backtrack_peek_should_move_peek_index_backwards()
        {
            var chars = Autofixture.CreateMany<char>(10).ToList();
            var enumerator = chars.GetEnumerator();
            var seeker = new BufferedSeeker(enumerator);

            // Act
            seeker.Peek();
            seeker.Peek();
            seeker.BacktrackPeek(2);
            var result = seeker.Peek();

            // Assert
            result.Should().Be(chars.First());
            seeker.PeakIndex.Should().Be(1);
        }

        [Fact]
        public void Seek_should_remove_from_buffer()
        {
            var chars = Autofixture.CreateMany<char>(10).ToList();
            var enumerator = chars.GetEnumerator();
            var seeker = new BufferedSeeker(enumerator);

            // Act
            seeker.Seek(2);
            var result = seeker.Peek();

            // Assert
            result.Should().Be(chars.Skip(2).First());
            seeker.PeakIndex.Should().Be(3);
        }
    }
}