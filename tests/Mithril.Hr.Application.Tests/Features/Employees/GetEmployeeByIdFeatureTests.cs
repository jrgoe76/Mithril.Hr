using FluentAssertions;
using Mithril.Hr.Application.Features.Employees;
using Mithril.Hr.Domain.Employees;
using Mithril.Hr.Seeds.Employees;
using Moq;
using Xunit;

namespace Mithril.Hr.Application.Tests.Features.Employees;

public sealed class GetEmployeeByIdFeatureTests
{
    [Fact]
    public async Task ReturnsEmployeeInfo()
    {
        var getEmployeeByIdQueryMock = new Mock<IGetEmployeeByIdQuery>();
        var employeeToEmployeeInfoMapper = new EmployeeToEmployeeInfoMapper();

        var liamHill = EmployeeSeed.LiamHill;
        var liamHillInfo = employeeToEmployeeInfoMapper.Map(liamHill);

        getEmployeeByIdQueryMock.Setup(liamHill);
        
        (await new GetEmployeeByIdFeature(
                getEmployeeByIdQueryMock.Object, 
                employeeToEmployeeInfoMapper)
            .Get(liamHill.EmployeeId))
            .Should().Be(liamHillInfo);
    }
}
