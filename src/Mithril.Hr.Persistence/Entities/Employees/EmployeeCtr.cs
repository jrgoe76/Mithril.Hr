using Mithril.Hr.Domain.Demographics;
using Mithril.Hr.Domain.Education;
using Mithril.Hr.Domain.Employees;
using System.Diagnostics.CodeAnalysis;

namespace Mithril.Hr.Persistence.Entities.Employees;

[ExcludeFromCodeCoverage]
public sealed class EmployeeCtr : IEmployeeCtr
{
    public Employee New(
        Guid employeeId,
        PersonName name,
        Gender gender,
        Email email,
        Address address,
        AcademicDegree degree)
        => new EmployeeEntity(employeeId, name, gender, email, address, degree);
}
