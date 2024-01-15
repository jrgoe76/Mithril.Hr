using FluentAssertions;
using Mithril.Hr.Domain.Demographics;
using Xunit;

namespace Mithril.Hr.Tests.Domain.Demographics;

public sealed class EmailTests
{
    [Fact]
    public void ThrowsArgumentException()
    {
        ((Func<Email>)(() => new Email("x")))
            .Should().Throw<ArgumentException>();
        ((Func<Email>)(() => new Email("x@")))
            .Should().Throw<ArgumentException>();
        ((Func<Email>)(() => new Email("x@x")))
            .Should().Throw<ArgumentException>();
        ((Func<Email>)(() => new Email("x@x.x")))
            .Should().Throw<ArgumentException>();
    }

    [Fact]
    public void ReturnsRepresentation()
    {
        const string emailAddress = "joedoe@gmail.com";

        new Email(emailAddress).ToString()
            .Should().Be(emailAddress);
    }
}
