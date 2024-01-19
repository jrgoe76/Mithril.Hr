using Mithril.Hr.Domain.Employees;
using Mithril.Hr.Seeds.Positions;

namespace Mithril.Hr.Seeds.Employees;

public static class ContractSeed
{
	private static readonly Employee _liamHill = EmployeeSeed.LiamHill();

	public static Contract DianaKing(DateOnly startedOn)
		=> new (PositionSeed.ChiefFinancialOfficer, _liamHill.EmployeeId, startedOn);
}
