using Mithril.Hr.Domain.Demographics;
using Mithril.Hr.Domain.Education;

namespace Mithril.Hr.Domain.Employees;

public interface IEmployeeCtr
{
    Employee New(
        Guid employeeId,
        PersonName name,
        Gender gender,
        Email email,
        Address address,
        AcademicDegree degree);
}
