using FluentAssertions;
using Mithril.Hr.Domain.Demographics;
using Xunit;

namespace Mithril.Hr.Tests.Domain.Demographics;

public sealed class PersonNameTests
{
    [Fact]
    public void ThrowsArgumentExceptionCausedByFirstName()
    {
        ((Func<PersonName>)(() => new PersonName(null!, "Doe")))
            .Should().Throw<ArgumentException>();
        ((Func<PersonName>)(() => new PersonName(string.Empty, "Doe")))
            .Should().Throw<ArgumentException>();
    }

    [Fact]
    public void ThrowsArgumentExceptionCausedByLastName()
    {
        ((Func<PersonName>)(() => new PersonName("Joe", null!)))
            .Should().Throw<ArgumentException>();
        ((Func<PersonName>)(() => new PersonName("Joe", string.Empty)))
            .Should().Throw<ArgumentException>();
    }

    [Fact]
    public void ReturnsRepresentationWithoutMiddleInitial()
    {
        new PersonName("Joe", "Doe").ToString()
            .Should().Be("Joe Doe");
    }

    [Fact]
    public void ReturnsRepresentation()
    {
        new PersonName("Joe", "A", "Doe").ToString()
            .Should().Be("Joe A. Doe");
    }
}
