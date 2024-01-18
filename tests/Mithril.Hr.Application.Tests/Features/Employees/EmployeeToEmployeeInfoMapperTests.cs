using FluentAssertions;
using Mithril.Hr.Application.Features.Employees;
using Mithril.Hr.Application.Tests.Seeds.Employees;
using Mithril.Hr.Seeds.Employees;
using Xunit;

namespace Mithril.Hr.Application.Tests.Features.Employees;

public sealed class EmployeeToEmployeeInfoMapperTests
{
    [Fact]
    public void MapsEmployeeToEmployeeInfo()
    {
        var liamHill = EmployeeSeed.LiamHill();
        var liamHillInfo = EmployeeInfoTestSeed.LiamHill;

        new EmployeeToEmployeeInfoMapper().Map(liamHill)
            .Should().Be(liamHillInfo);
    }
}
