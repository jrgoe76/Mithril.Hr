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

    public static EmployeeEntity PaulaCarr = new (
        EmployeeSeed.PaulaCarr.EmployeeId,
        EmployeeSeed.PaulaCarr.Name,
        EmployeeSeed.PaulaCarr.Gender,
        EmployeeSeed.PaulaCarr.Email,
        EmployeeSeed.PaulaCarr.Address,
        EmployeeSeed.PaulaCarr.Degree)
    {
        Position = EmployeeSeed.PaulaCarr.Position,
        PositionCode = EmployeeSeed.PaulaCarr.Position?.PositionCode,
        SupervisorId = EmployeeSeed.PaulaCarr.SupervisorId
    };

    public static EmployeeEntity DianaKing = new (
        EmployeeSeed.DianaKing.EmployeeId,
        EmployeeSeed.DianaKing.Name,
        EmployeeSeed.DianaKing.Gender,
        EmployeeSeed.DianaKing.Email,
        EmployeeSeed.DianaKing.Address,
        EmployeeSeed.DianaKing.Degree)
    {
        Position = EmployeeSeed.DianaKing.Position,
        PositionCode = EmployeeSeed.DianaKing.Position?.PositionCode,
        SupervisorId = EmployeeSeed.DianaKing.SupervisorId
    };
}
