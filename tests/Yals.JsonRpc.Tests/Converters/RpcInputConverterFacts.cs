using FluentAssertions;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Ploeh.AutoFixture;

using Xunit;

using Yals.JsonRpc.Models.Inputs;

namespace Yals.JsonRpc.Tests.Converters
{
    public class RpcInputConverterFacts
    {
        private static readonly Fixture Autofixture = new Fixture();

        [Fact]
        public void Can_convert_to_RpcRequest()
        {
            var fakeRequest = Autofixture.Create<RpcRequest<ComplexObject>>();
            var json = JsonConvert.SerializeObject(fakeRequest);

            // Act
            var result = JsonConvert.DeserializeObject<IRpcInputMessage>(json);

            // Assert
            var subject = result.Should().BeOfType<RpcRequest<JToken>>().Subject;
            subject.Id.Should().Be(fakeRequest.Id);
            subject.JsonRpc.Should().Be(fakeRequest.JsonRpc);
            subject.Method.Should().Be(fakeRequest.Method);
            subject.Parameters.ToObject<ComplexObject>().Should().Be(fakeRequest.Parameters);
        }

        [Fact]
        public void Can_convert_to_RpcNotification()
        {
            var fakeNotification = Autofixture.Create<RpcNotification<ComplexObject>>();
            var json = JsonConvert.SerializeObject(fakeNotification);

            // Act
            var result = JsonConvert.DeserializeObject<IRpcInputMessage>(json);

            // Assert
            var subject = result.Should().BeOfType<RpcNotification<JToken>>().Subject;
            subject.JsonRpc.Should().Be(fakeNotification.JsonRpc);
            subject.Method.Should().Be(fakeNotification.Method);
            subject.Parameters.ToObject<ComplexObject>().Should().Be(fakeNotification.Parameters);
        }

        public class ComplexObject
        {
            public string Test { get; set; }

            protected bool Equals(ComplexObject other)
            {
                return string.Equals(Test, other.Test);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj))
                    return false;
                if (ReferenceEquals(this, obj))
                    return true;
                if (obj.GetType() != this.GetType())
                    return false;
                return Equals((ComplexObject) obj);
            }

            public override int GetHashCode()
            {
                return (Test != null ? Test.GetHashCode() : 0);
            }

            public static bool operator ==(ComplexObject left, ComplexObject right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(ComplexObject left, ComplexObject right)
            {
                return !Equals(left, right);
            }
        }
    }
}