using FluentAssertions;
using Mithril.Hr.Application.Features.Employees;
using Mithril.Hr.Application.Seeds.Employees;
using Mithril.Hr.Domain.Model;
using Mithril.Hr.Domain.Model.Employees;
using Mithril.Hr.Domain.Seeds.Employees;
using Moq;
using Xunit;

namespace Mithril.Hr.Application.Tests.Features.Employees;

public sealed class AddEmployeeFeatureTests
{
    private readonly Employee _paulaCarr = EmployeeSeed.PaulaCarr();
    private readonly AddEmployeeInfo _paulaCarrAddInfo = AddEmployeeInfoSeed.PaulaCarr;

    private readonly Mock<IIdGenerator> _idGeneratorMock = new ();
    private readonly Mock<IEmployeeRepository> _employeeRepositoryMock = new ();
    private readonly EmployeeInfoMapper _employeeInfoMapper = new ();

    [Fact]
    public async Task Returns_an_EmployeeInfo()
    {
        var paulaCarrInfo = _employeeInfoMapper.Map(_paulaCarr);

        ArrangeGenerateEmployeeId(_paulaCarr.EmployeeId);

        (await GetFeature().Add(_paulaCarrAddInfo))
            .Should().Be(paulaCarrInfo);
    }

    [Fact]
    public async Task Adds_an_Employee()
    {
        ArrangeGenerateEmployeeId(_paulaCarr.EmployeeId);

        await GetFeature().Add(_paulaCarrAddInfo);

        VerifyRepositoryWasCalled(_paulaCarr);
    }

    private void ArrangeGenerateEmployeeId(Guid id) 
	    => _idGeneratorMock.ArrangeGenerateId(id);

    private AddEmployeeFeature GetFeature()
	    => new (
		    _idGeneratorMock.Object,
		    _employeeRepositoryMock.Object,
		    _employeeInfoMapper);

    private void VerifyRepositoryWasCalled(Employee employee)
	    => _employeeRepositoryMock
		    .Verify(repository => repository.Add(employee), Times.Once);
}