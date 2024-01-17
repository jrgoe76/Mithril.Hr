using Mithril.Hr.Application.Features.Employees;
using Mithril.Hr.Seeds.Employees;

namespace Mithril.Hr.Application.Seeds.Employees;

public static class EmployeeInfoSeed
{
    public static EmployeeInfo LiamHill => new (
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
        EmployeeSeed.LiamHill.Degree.ToString());
}
