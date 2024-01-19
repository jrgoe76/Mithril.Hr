using Mithril.Hr.Domain.Positions;

namespace Mithril.Hr.Domain.Employees;

public record Contract
{
    public Position Position { get; init; }
    public Guid? SupervisorId { get; init; }
    public DateOnly StartedOn { get; init; }
    public DateOnly? EndedOn { get; init; }

    public Contract(
        Position position,
        Guid? supervisorId, 
        DateOnly startedOn)
    {
        const string errorMessage = $"The {nameof(Employee)} is invalid";

        if (supervisorId == Guid.Empty)
        {
            throw new ArgumentException(errorMessage, nameof(supervisorId));
        }

        Position = position ?? throw new ArgumentException(errorMessage, nameof(position));
        SupervisorId = supervisorId;
        StartedOn = startedOn;
    }

    public Contract(Position position,
	    DateOnly startedOn) : this(position, null, startedOn)
    {
    }

    public Contract GetEndedOn(DateOnly endedOn)
	    => this with { EndedOn = endedOn };
}
