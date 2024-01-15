using Mithril.Hr.Application.Features.Employees;
using Mithril.Hr.Seeds.Employees;

namespace Mithril.Hr.Application.Seeds.Employees;

public static class EmployeeDetailSeed
{
    public static EmployeeDetail LiamHill = new (
        EmployeeSeed.LiamHill.EmployeeId,
        EmployeeSeed.LiamHill.Name.FirstName,
        EmployeeSeed.LiamHill.Name.MiddleInitial,
        EmployeeSeed.LiamHill.Name.LastName);
}
