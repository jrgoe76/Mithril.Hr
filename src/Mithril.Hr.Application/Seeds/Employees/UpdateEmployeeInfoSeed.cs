using Mithril.Hr.Application.Features.Employees;
using Mithril.Hr.Seeds.Employees;

namespace Mithril.Hr.Application.Seeds.Employees;

public static class UpdateEmployeeInfoSeed
{
    public static UpdateEmployeeInfo DianaKing = new(
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
        EmployeeSeed.UpdatedDianaKing.Degree.ToString());
}
