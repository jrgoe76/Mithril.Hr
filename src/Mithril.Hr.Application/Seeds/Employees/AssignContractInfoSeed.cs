using Mithril.Hr.Application.Features.Employees;
using Mithril.Hr.Seeds.Employees;
using Mithril.Hr.Seeds.Positions;

namespace Mithril.Hr.Application.Seeds.Employees;

public static class AssignContractInfoSeed
{
    public static Func<DateOnly, AssignContractInfo> DianaKing = 
        startDate => new AssignContractInfo(
            EmployeeSeed.DianaKing.EmployeeId,
            PositionSeed.ChiefFinancialOfficer.PositionCode,
            EmployeeSeed.LiamHill.EmployeeId,
            startDate);
}
