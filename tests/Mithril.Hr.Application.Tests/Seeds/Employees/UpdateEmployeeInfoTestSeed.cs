using Mithril.Hr.Application.Features.Employees;
using Mithril.Hr.Tests.Seeds.Employees;

namespace Mithril.Hr.Application.Tests.Seeds.Employees;

public static class UpdateEmployeeInfoTestSeed
{
    public static UpdateEmployeeInfo DianaKing => new (
        EmployeeTestSeed.UpdatedDianaKing.EmployeeId,
        EmployeeTestSeed.UpdatedDianaKing.Name.FirstName,
        EmployeeTestSeed.UpdatedDianaKing.Name.MiddleInitial,
        EmployeeTestSeed.UpdatedDianaKing.Name.LastName,
        EmployeeTestSeed.UpdatedDianaKing.Gender.ToString(),
        EmployeeTestSeed.UpdatedDianaKing.Email.Address,
        EmployeeTestSeed.UpdatedDianaKing.Address.AddressLine1,
        EmployeeTestSeed.UpdatedDianaKing.Address.AddressLine2,
        EmployeeTestSeed.UpdatedDianaKing.Address.City,
        EmployeeTestSeed.UpdatedDianaKing.Address.State,
        EmployeeTestSeed.UpdatedDianaKing.Address.Zipcode,
        EmployeeTestSeed.UpdatedDianaKing.Degree.ToString());
}
