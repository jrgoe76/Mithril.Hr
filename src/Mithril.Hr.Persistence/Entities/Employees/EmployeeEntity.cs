using Mithril.Hr.Domain.Employees;
using Mithril.Hr.Persistence.Entities.Demographics;
using Mithril.Hr.Persistence.Entities.Education;

namespace Mithril.Hr.Persistence.Entities.Employees;

public record EmployeeEntity
{
    public Guid EmployeeId { get; set; }
    public string FirstName { get; set; } = null!;
    public string? MiddleInitial { get; set; }
    public string LastName { get; set; } = null!;
    public char Gender { get; set; }
    public string EmailAddress { get; set; } = null!;
    public string AddressLine1 { get; set; } = null!;
    public string? AddressLine2 { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string Zipcode { get; set; } = null!;
    public string Degree { get; set; } = null!;

    public Guid Version { get; set; }

    public ContractEntity Contract { get; set; } = null!;

    public EmployeeEntity Update(
	    Employee employee,
	    GenderMapper genderMapper,
	    AcademicDegreeMapper academicDegreeMapper)
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

	    return this;
    }
}
