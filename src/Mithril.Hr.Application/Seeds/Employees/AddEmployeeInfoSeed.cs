using Mithril.Hr.Application.Features.Employees;
using Mithril.Hr.Seeds.Employees;

namespace Mithril.Hr.Application.Seeds.Employees;

public static class AddEmployeeInfoSeed
{
    public static AddEmployeeInfo LiamHill => new (
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
        EmployeeSeed.LiamHill.Degree.ToString());

    public static AddEmployeeInfo PaulaCarr => new (
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
        EmployeeSeed.PaulaCarr.Degree.ToString());

    public static AddEmployeeInfo DianaKing => new (
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
        EmployeeSeed.DianaKing.Degree.ToString());
}
