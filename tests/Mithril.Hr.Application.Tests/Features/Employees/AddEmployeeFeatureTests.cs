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
    private readonly Mock<IEmployeeRepository> _employeeRepositoryMock = new();

    private readonly AddEmployeeFeature _feature;

    public AddEmployeeFeatureTests()
    {
        var idGeneratorMock = new Mock<IIdGenerator>();
        var employeeCtrMock = new Mock<IEmployeeCtr>();

        var newEmployeeId = Guid.NewGuid();

        idGeneratorMock
            .Setup(generator => generator.New())
            .Returns(newEmployeeId);

        employeeCtrMock
            .Setup(ctr => ctr.New(newEmployeeId,
                EmployeeSeed.PaulaCarr.Name, EmployeeSeed.PaulaCarr.Gender,
                EmployeeSeed.PaulaCarr.Email, EmployeeSeed.PaulaCarr.Address,
                EmployeeSeed.PaulaCarr.Degree))
            .Returns(EmployeeSeed.PaulaCarr);

        _feature = new AddEmployeeFeature(idGeneratorMock.Object,
            employeeCtrMock.Object, _employeeRepositoryMock.Object, new EmployeeToEmployeeInfoMapper());
    }

    [Fact]
    public async Task ReturnsEmployeeInfo()
    {
        (await _feature.Add(AddEmployeeInfoSeed.PaulaCarr))
            .Should().Be(EmployeeInfoSeed.PaulaCarr);
    }

    [Fact]
    public async Task AddsEmployeeToRepository()
    {
        await _feature
            .Add(AddEmployeeInfoSeed.PaulaCarr);

        _employeeRepositoryMock
            .Verify(repository => repository.Add(EmployeeSeed.PaulaCarr), Times.Once);
    }
}