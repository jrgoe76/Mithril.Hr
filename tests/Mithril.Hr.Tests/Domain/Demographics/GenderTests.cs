using FluentAssertions;
using Mithril.Hr.Domain.Demographics;
using Xunit;

namespace Mithril.Hr.Tests.Domain.Demographics;

public sealed class GenderTests
{
    [Fact]
    public void ThrowsArgumentException()
    {
        ((Func<Gender>)(() => new Gender("XXX")))
            .Should().Throw<ArgumentException>();
    }

    [Fact]
    public void ReturnsRepresentation()
    {
        new Gender(nameof(Gender.Values.Male)).ToString()
            .Should().Be(nameof(Gender.Values.Male));
        new Gender(nameof(Gender.Values.Female)).ToString()
            .Should().Be(nameof(Gender.Values.Female));
    }
}
