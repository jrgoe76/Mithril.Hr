using FluentAssertions;
using Mithril.Hr.Domain.Positions;
using Xunit;

namespace Mithril.Hr.Tests.Domain.Positions;

public sealed class PositionTests
{
    private const string _positionCode = "COO";
    private const string _name = "Chief Operating Officer";

    [Fact]
    public void ThrowsArgumentException()
    {
        ((Func<Position>)(() => new Position(null!, _name)))
            .Should().Throw<ArgumentException>();
        ((Func<Position>)(() => new Position(string.Empty, _name)))
            .Should().Throw<ArgumentException>();

        ((Func<Position>)(() => new Position(_positionCode, null!)))
            .Should().Throw<ArgumentException>();
        ((Func<Position>)(() => new Position(_positionCode, string.Empty)))
            .Should().Throw<ArgumentException>();
    }

    [Fact]
    public void ReturnsRepresentation()
    {
        new Position(_positionCode, _name).ToString()
            .Should().Be(_name);
    }
}
