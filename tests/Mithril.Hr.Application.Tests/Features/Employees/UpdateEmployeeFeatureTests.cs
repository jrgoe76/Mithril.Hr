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
    private readonly Employee _dianaKing = EmployeeSeed.DianaKing();
    private readonly UpdateEmployeeInfo _dianaKingUpdateInfo = UpdateEmployeeInfoTestSeed.DianaKing;
    private readonly Employee _updatedDianaKing = EmployeeTestSeed.UpdatedDianaKing();

    private readonly Mock<IGetEmployeeByIdQuery> _getEmployeeByIdQueryMock = new ();
    private readonly Mock<IEmployeeRepository> _employeeRepositoryMock = new ();
    private readonly EmployeeInfoMapper _employeeInfoMapper = new ();

    [Fact]
    public async Task Returns_EmployeeInfo()
    {
        var updatedDianaKingInfo = _employeeInfoMapper.Map(_updatedDianaKing);

        ArrangeGetEmployeeById(_dianaKing);

        (await GetFeature().Update(_dianaKingUpdateInfo))
            .Should().Be(updatedDianaKingInfo);
    }

    [Fact]
    public async Task Updates_an_Employee()
    {
        ArrangeGetEmployeeById(_dianaKing);

        await GetFeature().Update(_dianaKingUpdateInfo);

        VerifyRepositoryWasCalled(_updatedDianaKing);
    }

    private void ArrangeGetEmployeeById(Employee employee)
        => _getEmployeeByIdQueryMock.ArrangeGetEmployeeById(employee);

    private UpdateEmployeeFeature GetFeature()
	    => new (
		    _getEmployeeByIdQueryMock.Object,
		    _employeeRepositoryMock.Object,
		    _employeeInfoMapper);

    private void VerifyRepositoryWasCalled(Employee employee)
        => _employeeRepositoryMock
            .Verify(repository => repository.Update(employee), Times.Once);
}
