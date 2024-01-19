namespace Mithril.Hr.Persistence.Entities.Employees;

public record ContractEf
{
	public Guid EmployeeId { get; set; }
	public string PositionCode { get; set; } = null!;
    public Guid SupervisorId { get; set; }
	public DateOnly StartDate { get; set; }

	public EmployeeEf Employee { get; set; } = null!;
}
