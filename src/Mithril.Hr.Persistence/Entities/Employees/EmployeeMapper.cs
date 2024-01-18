using Mithril.Hr.Domain.Demographics;
using Mithril.Hr.Domain.Employees;
using Mithril.Hr.Persistence.Entities.Demographics;
using Mithril.Hr.Persistence.Entities.Education;

namespace Mithril.Hr.Persistence.Entities.Employees;

public sealed class EmployeeMapper(
	GenderMapper genderMapper,
	AcademicDegreeMapper academicDegreeMapper)
{
	public Employee Map(EmployeeEntity employee)
		=> new (employee.EmployeeId,
			new PersonName(employee.FirstName, employee.MiddleInitial, employee.LastName),
			genderMapper.Map(employee.Gender),
			new Email(employee.EmailAddress),
			new Address(employee.AddressLine1, employee.AddressLine2, 
				employee.City, employee.State, employee.Zipcode),
			academicDegreeMapper.Map(employee.Degree));
}
