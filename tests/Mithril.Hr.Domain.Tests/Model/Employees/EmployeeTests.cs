using FluentAssertions;
using Mithril.Hr.Domain.Model.Demographics;
using Mithril.Hr.Domain.Model.Education;
using Mithril.Hr.Domain.Model.Employees;
using Mithril.Hr.Domain.Seeds.Demographics;
using Mithril.Hr.Domain.Seeds.Employees;
using Xunit;

namespace Mithril.Hr.Domain.Tests.Model.Employees;

public sealed class EmployeeTests
{
    private readonly PersonName _name = PersonNameSeed.DianaKing;
    private readonly Gender _gender = Gender.Female;
    private readonly Email _email = EmailSeed.DianaKingAtAol;
    private readonly Address _address = AddressSeed.MadisonAve;
    private readonly AcademicDegree _degree = AcademicDegree.PhD;

    [Fact]
    public void Throws_an_error_caused_by_an_invalid_Employee()
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
    public void Updates_an_Employee()
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
    public void Assigns_a_Contract_to_an_Employee()
    {
        var liamHill = EmployeeSeed.LiamHill();
        var dianaKingContract = ContractSeed.DianaKing(DateOnly.FromDateTime(DateTime.Today));

        var employee = new Employee(Guid.NewGuid(), _name, _gender, _email, _address, _degree);

        employee.AssignContract(dianaKingContract.Position, liamHill.EmployeeId, dianaKingContract.StartedOn);

        employee.Contract
            .Should().Be(dianaKingContract);
    }
}
