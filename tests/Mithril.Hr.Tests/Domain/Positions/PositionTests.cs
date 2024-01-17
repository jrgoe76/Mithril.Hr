using FluentAssertions;
using Mithril.Hr.Domain.Positions;
using Xunit;

namespace Mithril.Hr.Tests.Domain.Positions;

public sealed class PositionTests
{
    private const string PositionCode = "COO";
    private const string Name = "Chief Operating Officer";

    [Fact]
    public void ThrowsArgumentException()
    {
        ((Func<Position>)(() => new Position(null!, Name)))
            .Should().Throw<ArgumentException>();
        ((Func<Position>)(() => new Position(string.Empty, Name)))
            .Should().Throw<ArgumentException>();

        ((Func<Position>)(() => new Position(PositionCode, null!)))
            .Should().Throw<ArgumentException>();
        ((Func<Position>)(() => new Position(PositionCode, string.Empty)))
            .Should().Throw<ArgumentException>();
    }

    [Fact]
    public void ReturnsRepresentation()
    {
        new Position(PositionCode, Name).ToString()
            .Should().Be(Name);
    }
}
