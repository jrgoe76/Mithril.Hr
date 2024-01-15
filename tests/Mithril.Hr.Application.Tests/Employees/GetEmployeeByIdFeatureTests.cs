using FluentAssertions;
using Mithril.Hr.Application.Features.Employees;
using Mithril.Hr.Application.Seeds.Employees;
using Mithril.Hr.Domain.Employees;
using Mithril.Hr.Seeds.Employees;
using Moq;
using Xunit;

namespace Mithril.Hr.Application.Tests.Employees;

public sealed class GetEmployeeByIdFeatureTests
{
    [Fact]
    public async Task ReturnsEmployeeInfo()
    {
        var getEmployeeByIdQueryMock = new Mock<IGetEmployeeByIdQuery>();

        getEmployeeByIdQueryMock
            .Setup(query => query.Get(EmployeeSeed.LiamHill.EmployeeId))
            .ReturnsAsync(EmployeeSeed.LiamHill);

        (await new GetEmployeeByIdFeature(
                getEmployeeByIdQueryMock.Object, new EmployeeToEmployeeInfoMapper())
            .Get(EmployeeSeed.LiamHill.EmployeeId))
            .Should().Be(EmployeeInfoSeed.LiamHill);
    }
}
