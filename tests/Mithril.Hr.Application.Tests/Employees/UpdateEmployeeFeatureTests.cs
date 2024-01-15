using FluentAssertions;
using Mithril.Hr.Application.Features.Employees;
using Mithril.Hr.Application.Seeds.Employees;
using Mithril.Hr.Domain.Employees;
using Mithril.Hr.Seeds.Employees;
using Moq;
using Xunit;

namespace Mithril.Hr.Application.Tests.Employees;

public sealed class UpdateEmployeeFeatureTests
{
    private readonly Mock<IEmployeeRepository> _employeeRepositoryMock = new ();

    private readonly UpdateEmployeeFeature _feature;

    public UpdateEmployeeFeatureTests()
    {
        var getEmployeeByIdQueryMock = new Mock<IGetEmployeeByIdQuery>();

        getEmployeeByIdQueryMock
            .Setup(query => query.Get(EmployeeSeed.DianaKing.EmployeeId))
            .ReturnsAsync(EmployeeSeed.DianaKing);

        _feature = new UpdateEmployeeFeature(getEmployeeByIdQueryMock.Object,
            _employeeRepositoryMock.Object, new EmployeeToEmployeeInfoMapper());
    }

    [Fact]
    public async Task ReturnsEmployeeInfo()
    {
        (await _feature.Update(UpdateEmployeeInfoSeed.DianaKing))
            .Should().Be(EmployeeInfoSeed.UpdatedDianaKing);
    }

    [Fact]
    public async Task UpdatesEmployeeInRepository()
    {
        await _feature.Update(UpdateEmployeeInfoSeed.DianaKing);

        _employeeRepositoryMock
            .Verify(repository => repository.Update(EmployeeSeed.UpdatedDianaKing), Times.Once);
    }
}
