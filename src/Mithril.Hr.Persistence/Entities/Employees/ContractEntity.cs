namespace Mithril.Hr.Persistence.Entities.Employees;

public record ContractEntity
{
	public Guid EmployeeId { get; set; }
	public string PositionCode { get; set; } = null!;
    public Guid SupervisorId { get; set; }
	public DateOnly StartDate { get; set; }

	public EmployeeEntity Employee { get; set; } = null!;
}
