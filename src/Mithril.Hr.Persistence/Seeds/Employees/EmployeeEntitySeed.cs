using Mithril.Hr.Persistence.Entities.Employees;
using Mithril.Hr.Seeds.Employees;

namespace Mithril.Hr.Persistence.Seeds.Employees;

public static class EmployeeEntitySeed
{
    public static EmployeeEntity LiamHill => new (
        EmployeeSeed.LiamHill.EmployeeId,
        EmployeeSeed.LiamHill.Name,
        EmployeeSeed.LiamHill.Gender,
        EmployeeSeed.LiamHill.Email,
        EmployeeSeed.LiamHill.Address,
        EmployeeSeed.LiamHill.Degree);

    public static EmployeeEntity DianaKing => new (
        EmployeeSeed.DianaKing.EmployeeId,
        EmployeeSeed.DianaKing.Name,
        EmployeeSeed.DianaKing.Gender,
        EmployeeSeed.DianaKing.Email,
        EmployeeSeed.DianaKing.Address,
        EmployeeSeed.DianaKing.Degree);
}
