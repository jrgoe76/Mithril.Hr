using FluentAssertions;
using Mithril.Hr.Domain.Model.Demographics;
using Xunit;

namespace Mithril.Hr.Domain.Tests.Model.Demographics;

public sealed class PersonNameTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Throws_an_error_caused_by_a_null_or_empty_FirstName(string? firstName)
    {
        ((Func<PersonName>)(() => new PersonName(firstName!, "Hill")))
            .Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Throws_an_error_caused_by_a_null_or_empty_LastName(string? lastName)
    {
        ((Func<PersonName>)(() => new PersonName("Liam", lastName!)))
            .Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData("Liam", "Hill", "Liam Hill")]
    [InlineData("Paula", "Carr", "Paula Carr")]
    [InlineData("Diana", "King", "Diana King")]
    public void Returns_the_representation_without_MiddleInitial(
        string firstName, string lastName, string representation)
    {
        new PersonName(firstName, lastName).ToString()
            .Should().Be(representation);
    }

    [Theory]
    [InlineData("Liam", "P", "Hill", "Liam P. Hill")]
    [InlineData("Paula", "D", "Carr", "Paula D. Carr")]
    [InlineData("Diana", "J", "King", "Diana J. King")]
    public void Returns_the_representation(
        string firstName, string middleInitial, string lastName, string representation)
    {
        new PersonName(firstName, middleInitial, lastName).ToString()
            .Should().Be(representation);
    }
}
