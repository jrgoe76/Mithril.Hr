namespace Mithril.Hr.Persistence.Entities.Employees;

public record ContractEf
{
	public Guid EmployeeId { get; set; }
	public string PositionCode { get; set; } = null!;
    public Guid? SupervisorId { get; set; }
	public DateOnly StartedOn { get; set; }
	public DateOnly? EndedOn { get; set; }

    public EmployeeEf Employee { get; set; } = null!;
}
