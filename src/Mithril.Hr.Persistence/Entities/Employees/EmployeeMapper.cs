using Mithril.Hr.Domain.Demographics;
using Mithril.Hr.Domain.Employees;
using Mithril.Hr.Persistence.Entities.Demographics;
using Mithril.Hr.Persistence.Entities.Education;

namespace Mithril.Hr.Persistence.Entities.Employees;

public sealed class EmployeeMapper(
	GenderMapper genderMapper,
	AcademicDegreeMapper academicDegreeMapper)
{
	public Employee Map(EmployeeEf employeeEf)
		=> new (employeeEf.EmployeeId,
			new PersonName(employeeEf.FirstName, employeeEf.MiddleInitial, employeeEf.LastName),
			genderMapper.Map(employeeEf.Gender),
			new Email(employeeEf.EmailAddress),
			new Address(employeeEf.AddressLine1, employeeEf.AddressLine2, 
				employeeEf.City, employeeEf.State, employeeEf.Zipcode),
			academicDegreeMapper.Map(employeeEf.Degree));
}
