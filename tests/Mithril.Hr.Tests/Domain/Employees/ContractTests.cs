using FluentAssertions;
using Mithril.Hr.Domain.Employees;
using Mithril.Hr.Seeds.Positions;
using Xunit;

namespace Mithril.Hr.Tests.Domain.Employees;

public sealed class ContractTests
{
    [Fact]
    public void ThrowsArgumentException()
    {
        ((Func<Contract>)(() => new Contract(null!, Guid.NewGuid(), DateOnly.MaxValue)))
            .Should().Throw<ArgumentException>();
        ((Func<Contract>)(() => new Contract(PositionSeed.Accountant, Guid.Empty, DateOnly.MaxValue)))
            .Should().Throw<ArgumentException>();
    }
}
