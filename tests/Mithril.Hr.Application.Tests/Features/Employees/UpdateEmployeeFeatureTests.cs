using FluentAssertions;
using Mithril.Hr.Application.Features.Employees;
using Mithril.Hr.Application.Tests.Seeds.Employees;
using Mithril.Hr.Domain.Employees;
using Mithril.Hr.Seeds.Employees;
using Mithril.Hr.Tests.Seeds.Employees;
using Moq;
using Xunit;

namespace Mithril.Hr.Application.Tests.Features.Employees;

public sealed class UpdateEmployeeFeatureTests
{
    private readonly Mock<IGetEmployeeByIdQuery> _getEmployeeByIdQueryMock = new ();
    private readonly Mock<IEmployeeRepository> _employeeRepositoryMock = new ();
    private readonly EmployeeInfoMapper _employeeInfoMapper = new ();

    [Fact]
    public async Task ReturnsEmployeeInfo()
    {
        var dianaKing = EmployeeSeed.DianaKing();
        var dianaKingUpdateInfo = UpdateEmployeeInfoTestSeed.DianaKing;
        var updatedDianaKing = EmployeeTestSeed.UpdatedDianaKing();
        var updatedDianaKingInfo = _employeeInfoMapper.Map(updatedDianaKing);

        _getEmployeeByIdQueryMock.Setup(dianaKing);

        (await GetFeature().Update(dianaKingUpdateInfo))
            .Should().Be(updatedDianaKingInfo);
    }

    [Fact]
    public async Task UpdatesEmployeeInRepository()
    {
        var dianaKing = EmployeeSeed.DianaKing();
        var dianaKingUpdateInfo = UpdateEmployeeInfoTestSeed.DianaKing;
        var updatedDianaKing = EmployeeTestSeed.UpdatedDianaKing();

        _getEmployeeByIdQueryMock.Setup(dianaKing);

        await GetFeature().Update(dianaKingUpdateInfo);

        _employeeRepositoryMock
            .Verify(repository => repository.Update(updatedDianaKing), Times.Once);
    }

    private UpdateEmployeeFeature GetFeature()
	    => new (
		    _getEmployeeByIdQueryMock.Object,
		    _employeeRepositoryMock.Object,
		    _employeeInfoMapper);
}
