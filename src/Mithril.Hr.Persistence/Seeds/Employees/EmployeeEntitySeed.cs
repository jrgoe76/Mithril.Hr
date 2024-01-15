using Mithril.Hr.Persistence.Entities.Employees;
using Mithril.Hr.Seeds.Employees;

namespace Mithril.Hr.Persistence.Seeds.Employees;

public static class EmployeeEntitySeed
{
    public static EmployeeEntity LiamHill = new (
        EmployeeSeed.LiamHill.EmployeeId,
        EmployeeSeed.LiamHill.Name,
        EmployeeSeed.LiamHill.Gender,
        EmployeeSeed.LiamHill.Email,
        EmployeeSeed.LiamHill.Address,
        EmployeeSeed.LiamHill.Degree)
    {
        Position = EmployeeSeed.LiamHill.Position,
        PositionCode = EmployeeSeed.LiamHill.Position?.PositionCode,
        SupervisorId = EmployeeSeed.LiamHill.SupervisorId
    };
}
