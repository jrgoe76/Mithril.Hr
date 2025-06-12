using Mithril.Hr.Domain.Model.Employees;
using Mithril.Hr.Infrastructure.Persistence.Model.Demographics;
using Mithril.Hr.Infrastructure.Persistence.Model.Education;

namespace Mithril.Hr.Infrastructure.Persistence.Model.Employees;

public record EmployeeEf
{
    public Guid EmployeeId { get; set; }
    public string FirstName { get; set; } = null!;
    public string? MiddleInitial { get; set; }
    public string LastName { get; set; } = null!;
    public char Gender { get; set; }
    public string EmailAddress { get; set; } = null!;
    public string AddressLine1 { get; set; } = null!;
    public string? AddressLine2 { get; set; }
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string Zipcode { get; set; } = null!;
    public string Degree { get; set; } = null!;

    public Guid Version { get; set; }

    public ContractEf? Contract { get; set; }

    internal EmployeeEf() { }

    public EmployeeEf(
        Employee employee,
        GenderMapper genderMapper,
        AcademicDegreeMapper academicDegreeMapper,
        Guid version)
    {
        EmployeeId = employee.EmployeeId;
        SetFields(employee, genderMapper, academicDegreeMapper, version);
    }

    public EmployeeEf Update(
        Employee employee,
        GenderMapper genderMapper,
        AcademicDegreeMapper academicDegreeMapper,
        Guid version)
    {
        SetFields(employee, genderMapper, academicDegreeMapper, version);

        ContractEf? contract = employee.Contract != null
            ? new ContractEf
            {
                PositionCode = employee.Contract.Position.PositionCode,
                SupervisorId = employee.Contract.SupervisorId,
                StartedOn = employee.Contract.StartedOn,
                EndedOn = employee.Contract.EndedOn
            }
            : null;
        Contract = contract;

        return this;
    }

    private void SetFields(
        Employee employee,
        GenderMapper genderMapper,
        AcademicDegreeMapper academicDegreeMapper,
        Guid version)
    {
        FirstName = employee.Name.FirstName;
        MiddleInitial = employee.Name.MiddleInitial;
        LastName = employee.Name.LastName;
        Gender = genderMapper.MapCode(employee.Gender);
        EmailAddress = employee.Email.Address;
        AddressLine1 = employee.Address.AddressLine1;
        AddressLine2 = employee.Address.AddressLine2;
        City = employee.Address.City;
        State = employee.Address.State;
        Zipcode = employee.Address.Zipcode;
        Degree = academicDegreeMapper.MapCode(employee.Degree);
        Version = version;
    }
}