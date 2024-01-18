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
    private readonly Mock<IEmployeeRepository> _employeeRepositoryMock = new();
    private readonly EmployeeToEmployeeInfoMapper _employeeToEmployeeInfoMapper = new ();

    private readonly AddEmployeeFeature _feature;

    public AddEmployeeFeatureTests()
    {
        var employeeCtrMock = new Mock<IEmployeeCtr>();

        employeeCtrMock
            .Setup(ctr => ctr.New(_paulaCarr.EmployeeId, _paulaCarr.Name, _paulaCarr.Gender,
                _paulaCarr.Email, _paulaCarr.Address, _paulaCarr.Degree))
            .Returns(_paulaCarr);

        _feature = new AddEmployeeFeature(
            _idGeneratorMock.Object,
            employeeCtrMock.Object,
            _employeeRepositoryMock.Object,
            _employeeToEmployeeInfoMapper);
    }

    [Fact]
    public async Task ReturnsEmployeeInfo()
    {
        var paulaCarrInfo = _employeeToEmployeeInfoMapper.Map(_paulaCarr);

        _idGeneratorMock.Setup(_paulaCarr.EmployeeId);

        (await _feature.Add(_paulaCarrAddInfo))
            .Should().Be(paulaCarrInfo);
    }

    [Fact]
    public async Task AddsEmployeeToRepository()
    {
        _idGeneratorMock.Setup(_paulaCarr.EmployeeId);

        await _feature.Add(_paulaCarrAddInfo);

        _employeeRepositoryMock
            .Verify(repository => repository.Add(_paulaCarr), Times.Once);
    }
}