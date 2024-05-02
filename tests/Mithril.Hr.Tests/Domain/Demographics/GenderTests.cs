using FluentAssertions;
using Mithril.Hr.Domain.Demographics;
using Xunit;

namespace Mithril.Hr.Tests.Domain.Demographics;

public sealed class GenderTests
{
	[Theory]
	[InlineData("XXX")]
    public void Throws_an_error_caused_by_an_invalid_Gender(string gender)
    {
        ((Func<Gender>)(() => new Gender(gender)))
            .Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData(nameof(Gender.Values.Male))]
    [InlineData(nameof(Gender.Values.Female))]
    public void Returns_the_representation(string gender)
    {
        new Gender(gender).ToString()
            .Should().Be(gender);
    }
}
