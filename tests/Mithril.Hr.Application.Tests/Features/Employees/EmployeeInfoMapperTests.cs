using FluentAssertions;
using Mithril.Hr.Application.Features.Employees;
using Mithril.Hr.Application.Tests.Seeds.Employees;
using Mithril.Hr.Tests.Seeds.Employees;
using Xunit;

namespace Mithril.Hr.Application.Tests.Features.Employees;

public sealed class EmployeeInfoMapperTests
{
    [Fact]
    public void Maps_Employee_to_EmployeeInfo()
    {
        var today = DateOnly.FromDateTime(DateTime.Today);

        var dianaKing = EmployeeTestSeed.DianaKingWithContract(today);
        var dianaKingInfo = EmployeeInfoTestSeed.DianaKingWithContract(today);

        new EmployeeInfoMapper().Map(dianaKing)
            .Should().Be(dianaKingInfo);
    }
}
