using Mithril.Hr.Application.Features.Employees;
using Mithril.Hr.Domain.Employees;
using Mithril.Hr.Seeds.Employees;
using Mithril.Hr.Seeds.Positions;

namespace Mithril.Hr.Application.Seeds.Employees;

public static class AssignContractInfoSeed
{
    private static readonly Employee _liamHill = EmployeeSeed.LiamHill();
    private static readonly Employee _dianaKing = EmployeeSeed.DianaKing();

    public static AssignContractInfo DianaKing(DateOnly startDate) 
	    => new (
			_dianaKing.EmployeeId,
			PositionSeed.ChiefFinancialOfficer.PositionCode,
			_liamHill.EmployeeId,
			startDate);
}
