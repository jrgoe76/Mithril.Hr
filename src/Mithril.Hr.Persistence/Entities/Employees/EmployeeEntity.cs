using Mithril.Hr.Domain.Demographics;
using Mithril.Hr.Domain.Education;
using Mithril.Hr.Domain.Employees;

namespace Mithril.Hr.Persistence.Entities.Employees;

public record EmployeeEntity : Employee
{
    public EmployeeEntity(
        Guid employeeId,
        PersonName name,
        Gender gender,
        Email email,
        Address address,
        AcademicDegree degree)
        : base(employeeId, name, gender, email, address, degree)
    {
    }

    protected EmployeeEntity()
    {
    }

    public string? PositionCode { get; set; } = null!;

    public Guid Version { get; set; }
}
