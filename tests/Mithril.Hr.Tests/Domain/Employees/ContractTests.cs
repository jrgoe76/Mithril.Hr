using FluentAssertions;
using Mithril.Hr.Domain.Employees;
using Mithril.Hr.Seeds.Positions;
using Mithril.Hr.Tests.Seeds.Employees;
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

    [Fact]
    public void ReturnsEndedOnContract()
    {
		var today = DateOnly.FromDateTime(DateTime.Today);
		var tomorrow = today.AddDays(1);

        var dianaKing = EmployeeTestSeed.DianaKingWithContract(today);
		var contract = dianaKing.Contract!.GetEndedOn(tomorrow);

        contract.EndedOn
	        .Should().Be(tomorrow);
    }
}
