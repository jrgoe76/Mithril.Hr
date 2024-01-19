using FluentAssertions;
using Mithril.Hr.Application.Features.Employees;
using Mithril.Hr.Application.Seeds.Employees;
using Mithril.Hr.Domain;
using Mithril.Hr.Domain.Employees;
using Mithril.Hr.Seeds.Employees;
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
    public async Task ReturnsEmployeeInfo()
    {
        var paulaCarrInfo = _employeeInfoMapper.Map(_paulaCarr);

        _idGeneratorMock.Setup(_paulaCarr.EmployeeId);

        (await GetFeature().Add(_paulaCarrAddInfo))
            .Should().Be(paulaCarrInfo);
    }

    [Fact]
    public async Task AddsEmployeeToRepository()
    {
        _idGeneratorMock.Setup(_paulaCarr.EmployeeId);

        await GetFeature().Add(_paulaCarrAddInfo);

        _employeeRepositoryMock
            .Verify(repository => repository.Add(_paulaCarr), Times.Once);
    }

    private AddEmployeeFeature GetFeature()
	    => new(
		    _idGeneratorMock.Object,
		    _employeeRepositoryMock.Object,
		    _employeeInfoMapper);

}