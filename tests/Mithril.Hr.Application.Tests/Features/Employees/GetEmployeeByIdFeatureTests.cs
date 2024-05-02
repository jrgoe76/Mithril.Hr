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
    public async Task Returns_EmployeeInfo()
    {
        var getEmployeeByIdQueryMock = new Mock<IGetEmployeeByIdQuery>();
        var employeeInfoMapper = new EmployeeInfoMapper();

        var liamHill = EmployeeSeed.LiamHill();
        var liamHillInfo = employeeInfoMapper.Map(liamHill);

        getEmployeeByIdQueryMock
            .ArrangeGetEmployeeById(liamHill);
        
        (await new GetEmployeeByIdFeature(
                getEmployeeByIdQueryMock.Object, 
                employeeInfoMapper)
            .Get(liamHill.EmployeeId))
            .Should().Be(liamHillInfo);
    }
}
