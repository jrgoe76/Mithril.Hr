using FluentAssertions;
using Mithril.Hr.Domain.Model.Demographics;
using Xunit;

namespace Mithril.Hr.Domain.Tests.Model.Demographics;

public sealed class EmailTests
{
    [Theory]
    [InlineData("x")]
    [InlineData("x@")]
    [InlineData("x@x")]
    [InlineData("x@x.x")]
    public void Throws_error_caused_by_an_invalid_Address(string address)
    {
        ((Func<Email>)(() => new Email(address)))
            .Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData("liamhill@gmail.com")]
    [InlineData("paulacarr@gmail.com")]
    [InlineData("dianaking@aol.com")]
    public void Returns_the_representation(string emailAddress)
    {
        new Email(emailAddress).ToString()
            .Should().Be(emailAddress);
    }
}