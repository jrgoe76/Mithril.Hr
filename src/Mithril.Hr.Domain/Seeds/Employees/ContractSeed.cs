using Mithril.Hr.Domain.Model.Employees;
using Mithril.Hr.Domain.Seeds.Positions;

namespace Mithril.Hr.Domain.Seeds.Employees;

public static class ContractSeed
{
    private static readonly Employee _liamHill = EmployeeSeed.LiamHill();

    public static Contract DianaKing(DateOnly startedOn)
        => new(PositionSeed.ChiefFinancialOfficer, _liamHill.EmployeeId, startedOn);
}