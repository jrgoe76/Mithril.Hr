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
        ((Func<Position>)(() => new Position(null!, Name, default)))
            .Should().Throw<ArgumentException>();
        ((Func<Position>)(() => new Position(string.Empty, Name, default)))
            .Should().Throw<ArgumentException>();

        ((Func<Position>)(() => new Position(PositionCode, null!, default)))
            .Should().Throw<ArgumentException>();
        ((Func<Position>)(() => new Position(PositionCode, string.Empty, default)))
            .Should().Throw<ArgumentException>();
    }

    [Fact]
    public void ReturnsRepresentation()
    {
        new Position(PositionCode, Name, default).ToString()
            .Should().Be(Name);
    }
}
