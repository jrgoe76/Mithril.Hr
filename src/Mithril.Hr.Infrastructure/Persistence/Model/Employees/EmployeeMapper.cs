using Mithril.Hr.Domain.Model.Demographics;
using Mithril.Hr.Domain.Model.Employees;
using Mithril.Hr.Infrastructure.Persistence.Model.Demographics;
using Mithril.Hr.Infrastructure.Persistence.Model.Education;

namespace Mithril.Hr.Infrastructure.Persistence.Model.Employees;

public sealed class EmployeeMapper(
    GenderMapper genderMapper,
    AcademicDegreeMapper academicDegreeMapper)
{
    public Employee Map(EmployeeEf employeeEf)
        => new(employeeEf.EmployeeId,
            new PersonName(employeeEf.FirstName, employeeEf.MiddleInitial, employeeEf.LastName),
            genderMapper.Map(employeeEf.Gender),
            new Email(employeeEf.EmailAddress),
            new Address(employeeEf.AddressLine1, employeeEf.AddressLine2,
                employeeEf.City, employeeEf.State, employeeEf.Zipcode),
            academicDegreeMapper.Map(employeeEf.Degree));
}