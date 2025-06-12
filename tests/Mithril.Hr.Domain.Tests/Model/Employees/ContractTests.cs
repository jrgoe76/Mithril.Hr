using FluentAssertions;
using Mithril.Hr.Domain.Model.Employees;
using Mithril.Hr.Domain.Seeds.Positions;
using Mithril.Hr.Domain.Tests.Seeds.Employees;
using Xunit;

namespace Mithril.Hr.Domain.Tests.Model.Employees;

public sealed class ContractTests
{
    [Fact]
    public void Throws_an_error_caused_by_a_null_Position()
    {
        ((Func<Contract>)(() => new Contract(null!, Guid.NewGuid(), DateOnly.MaxValue)))
            .Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Throws_an_error_caused_by_an_empty_SupervisorId()
    {
        ((Func<Contract>)(() => new Contract(PositionSeed.Accountant, Guid.Empty, DateOnly.MaxValue)))
            .Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Creates_a_new_Contract_from_this_with_EndedOn()
    {
        var today = DateOnly.FromDateTime(DateTime.Today);
        var tomorrow = today.AddDays(1);

        var dianaKing = EmployeeTestSeed.DianaKingWithContract(today);
        var contract = dianaKing.Contract!.GetEndedOn(tomorrow);

        contract.EndedOn
            .Should().Be(tomorrow);
    }
}