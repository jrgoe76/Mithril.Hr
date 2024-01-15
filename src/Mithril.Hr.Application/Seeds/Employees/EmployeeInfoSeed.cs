using Mithril.Hr.Application.Features.Employees;
using Mithril.Hr.Seeds.Employees;

namespace Mithril.Hr.Application.Seeds.Employees;

public static class EmployeeInfoSeed
{
    public static EmployeeInfo LiamHill = new (
        EmployeeSeed.LiamHill.EmployeeId,
        EmployeeSeed.LiamHill.Name.FirstName,
        EmployeeSeed.LiamHill.Name.MiddleInitial,
        EmployeeSeed.LiamHill.Name.LastName,
        EmployeeSeed.LiamHill.Gender.ToString(),
        EmployeeSeed.LiamHill.Email.Address,
        EmployeeSeed.LiamHill.Address.AddressLine1,
        EmployeeSeed.LiamHill.Address.AddressLine2,
        EmployeeSeed.LiamHill.Address.City,
        EmployeeSeed.LiamHill.Address.State,
        EmployeeSeed.LiamHill.Address.Zipcode,
        EmployeeSeed.LiamHill.Degree.ToString(),
        EmployeeSeed.LiamHill.Position?.PositionCode,
        EmployeeSeed.LiamHill.SupervisorId);

    public static EmployeeInfo PaulaCarr = new (
        EmployeeSeed.PaulaCarr.EmployeeId,
        EmployeeSeed.PaulaCarr.Name.FirstName,
        EmployeeSeed.PaulaCarr.Name.MiddleInitial,
        EmployeeSeed.PaulaCarr.Name.LastName,
        EmployeeSeed.PaulaCarr.Gender.ToString(),
        EmployeeSeed.PaulaCarr.Email.Address,
        EmployeeSeed.PaulaCarr.Address.AddressLine1,
        EmployeeSeed.PaulaCarr.Address.AddressLine2,
        EmployeeSeed.PaulaCarr.Address.City,
        EmployeeSeed.PaulaCarr.Address.State,
        EmployeeSeed.PaulaCarr.Address.Zipcode,
        EmployeeSeed.PaulaCarr.Degree.ToString(),
        EmployeeSeed.PaulaCarr.Position?.PositionCode,
        EmployeeSeed.PaulaCarr.SupervisorId);

    public static EmployeeInfo DianaKing = new (
        EmployeeSeed.DianaKing.EmployeeId,
        EmployeeSeed.DianaKing.Name.FirstName,
        EmployeeSeed.DianaKing.Name.MiddleInitial,
        EmployeeSeed.DianaKing.Name.LastName,
        EmployeeSeed.DianaKing.Gender.ToString(),
        EmployeeSeed.DianaKing.Email.Address,
        EmployeeSeed.DianaKing.Address.AddressLine1,
        EmployeeSeed.DianaKing.Address.AddressLine2,
        EmployeeSeed.DianaKing.Address.City,
        EmployeeSeed.DianaKing.Address.State,
        EmployeeSeed.DianaKing.Address.Zipcode,
        EmployeeSeed.DianaKing.Degree.ToString(),
        EmployeeSeed.DianaKing.Position?.PositionCode,
        EmployeeSeed.DianaKing.SupervisorId);
    
    public static EmployeeInfo UpdatedDianaKing = new(
        EmployeeSeed.UpdatedDianaKing.EmployeeId,
        EmployeeSeed.UpdatedDianaKing.Name.FirstName,
        EmployeeSeed.UpdatedDianaKing.Name.MiddleInitial,
        EmployeeSeed.UpdatedDianaKing.Name.LastName,
        EmployeeSeed.UpdatedDianaKing.Gender.ToString(),
        EmployeeSeed.UpdatedDianaKing.Email.Address,
        EmployeeSeed.UpdatedDianaKing.Address.AddressLine1,
        EmployeeSeed.UpdatedDianaKing.Address.AddressLine2,
        EmployeeSeed.UpdatedDianaKing.Address.City,
        EmployeeSeed.UpdatedDianaKing.Address.State,
        EmployeeSeed.UpdatedDianaKing.Address.Zipcode,
        EmployeeSeed.UpdatedDianaKing.Degree.ToString(),
        EmployeeSeed.UpdatedDianaKing.Position?.PositionCode,
        EmployeeSeed.UpdatedDianaKing.SupervisorId);
}
