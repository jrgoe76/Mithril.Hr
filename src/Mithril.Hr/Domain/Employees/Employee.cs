using Mithril.Hr.Domain.Demographics;
using Mithril.Hr.Domain.Education;
using Mithril.Hr.Domain.Positions;

namespace Mithril.Hr.Domain.Employees;

public record Employee
{
    public Guid EmployeeId { get; init; }
    public PersonName Name { get; private set; }
    public Gender Gender { get; private set; }
    public Email Email { get; private set; }
    public Address Address { get; private set; }
    public AcademicDegree Degree { get; private set; }
    public Contract? Contract { get; internal set; }

    public Employee(
        Guid employeeId,
        PersonName name,
        Gender gender,
        Email email,
        Address address,
        AcademicDegree degree)
    {
        const string errorMessage = $"The {nameof(Employee)} is invalid";

        if (employeeId == Guid.Empty)
        {
            throw new ArgumentException(errorMessage, nameof(employeeId));
        }

        EmployeeId = employeeId;
        Name = name ?? throw new ArgumentException(errorMessage, nameof(name));
        Gender = gender ?? throw new ArgumentException(errorMessage, nameof(gender));
        Email = email ?? throw new ArgumentException(errorMessage, nameof(email));
        Address = address ?? throw new ArgumentException(errorMessage, nameof(email));
        Degree = degree ?? throw new ArgumentException(errorMessage, nameof(email));
    }

    // Only for EF Core use.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected Employee()
#pragma warning restore CS8618
    {
    }

    public void Update(
        PersonName name,
        Gender gender,
        Email email,
        Address address,
        AcademicDegree degree)
    {
        Name = name;
        Gender = gender;
        Email = email;
        Address = address;
        Degree = degree;
    }

    public void AssignContract(Position position, Guid supervisorId, DateOnly startDate)
    {
        Contract = new Contract(position, supervisorId, startDate);
    }
}
