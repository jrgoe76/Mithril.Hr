using FluentAssertions;
using Mithril.Hr.Domain.Demographics;
using Mithril.Hr.Domain.Education;
using Mithril.Hr.Domain.Employees;
using Mithril.Hr.Seeds.Demographics;
using Mithril.Hr.Seeds.Employees;
using Mithril.Hr.Seeds.Positions;
using Xunit;

namespace Mithril.Hr.Tests.Domain.Employees;

public sealed class EmployeeTests
{
    private readonly PersonName _name = PersonNameSeed.DianaKing;
    private readonly Gender _gender = Gender.Female;
    private readonly Email _email = EmailSeed.DianaKingAtAol;
    private readonly Address _address = AddressSeed.MadisonAve;
    private readonly AcademicDegree _degree = AcademicDegree.PhD;

    [Fact]
    public void ThrowsArgumentException()
    {
        ((Func<Employee>)(() => new Employee(Guid.Empty, _name, _gender, _email, _address, _degree)))
            .Should().Throw<ArgumentException>();
        ((Func<Employee>)(() => new Employee(Guid.NewGuid(), null!, _gender, _email, _address, _degree)))
            .Should().Throw<ArgumentException>();
        ((Func<Employee>)(() => new Employee(Guid.NewGuid(), _name, null!, _email, _address, _degree)))
            .Should().Throw<ArgumentException>();
        ((Func<Employee>)(() => new Employee(Guid.NewGuid(), _name, _gender, null!, _address, _degree)))
            .Should().Throw<ArgumentException>();
        ((Func<Employee>)(() => new Employee(Guid.NewGuid(), _name, _gender, _email, null!, _degree)))
            .Should().Throw<ArgumentException>();
        ((Func<Employee>)(() => new Employee(Guid.NewGuid(), _name, _gender, _email, _address, null!)))
            .Should().Throw<ArgumentException>();
    }

    [Fact]
    public void UpdatesEmployee()
    {
        var employee = new Employee(Guid.NewGuid(), _name, _gender, _email, _address, _degree);

        var updatedName = _name with { FirstName = "updated" };
        var updatedGender = Gender.Female;
        var updatedEmail = new Email("updated@gmail.com");
        var updatedAddress = _address with { Zipcode = "98765" };
        var updatedDegree = AcademicDegree.Bachelor;

        employee.Update(updatedName, updatedGender, updatedEmail, updatedAddress, updatedDegree);

        employee.EmployeeId
            .Should().Be(employee.EmployeeId);
        employee.Name
            .Should().Be(updatedName);
        employee.Gender
            .Should().Be(updatedGender);
        employee.Email
            .Should().Be(updatedEmail);
        employee.Address
            .Should().Be(updatedAddress);
        employee.Degree
            .Should().Be(updatedDegree);
    }

    [Fact]
    public void AssignsPosition()
    {
        var employee = new Employee(Guid.NewGuid(), _name, _gender, _email, _address, _degree);

        employee.AssignPosition(PositionSeed.ChiefFinancialOfficer, EmployeeSeed.LiamHill);

        employee.Position
            .Should().Be(PositionSeed.ChiefFinancialOfficer);
        employee.SupervisorId
            .Should().Be(EmployeeSeed.LiamHill.SupervisorId);
    }
}
