using FluentAssertions;
using Mithril.Hr.Domain.Model.Positions;
using Xunit;

namespace Mithril.Hr.Domain.Tests.Model.Positions;

public sealed class PositionTests
{
    private const string _positionCode = "COO";
    private const string _name = "Chief Operating Officer";

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Throws_error_caused_by_an_null_or_empty_PositionCode(string? positionCode)
    {
        ((Func<Position>)(() => new Position(positionCode!, _name)))
            .Should().Throw<ArgumentException>();
    }
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Throws_error_caused_by_an_null_or_empty_Name(string? name)
    {
        ((Func<Position>)(() => new Position(_positionCode, name!)))
            .Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Returns_the_representation()
    {
        new Position(_positionCode, _name).ToString()
            .Should().Be(_name);
    }
}
