using Mithril.Hr.Domain.Positions;

namespace Mithril.Hr.Domain.Employees;

public record Contract
{
    public Position Position { get; init; }
    public Guid SupervisorId { get; init; }
    public DateOnly StartDate { get; init; }

    public Contract(
        Position position,
        Guid supervisorId, 
        DateOnly startDate)
    {
        const string errorMessage = $"The {nameof(Employee)} is invalid";

        if (supervisorId == Guid.Empty)
        {
            throw new ArgumentException(errorMessage, nameof(supervisorId));
        }

        Position = position ?? throw new ArgumentException(errorMessage, nameof(position));
        SupervisorId = supervisorId;
        StartDate = startDate;
    }
}
