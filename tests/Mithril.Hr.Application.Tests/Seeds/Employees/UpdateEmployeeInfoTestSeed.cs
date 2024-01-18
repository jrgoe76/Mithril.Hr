using Mithril.Hr.Application.Features.Employees;
using Mithril.Hr.Domain.Employees;
using Mithril.Hr.Tests.Seeds.Employees;

namespace Mithril.Hr.Application.Tests.Seeds.Employees;

public static class UpdateEmployeeInfoTestSeed
{
	private static readonly Employee _updatedDianaKing = EmployeeTestSeed.UpdatedDianaKing();

	public static UpdateEmployeeInfo DianaKing = new (
        _updatedDianaKing.EmployeeId,
        _updatedDianaKing.Name.FirstName,
        _updatedDianaKing.Name.MiddleInitial,
        _updatedDianaKing.Name.LastName,
        _updatedDianaKing.Gender.ToString(),
        _updatedDianaKing.Email.Address,
        _updatedDianaKing.Address.AddressLine1,
        _updatedDianaKing.Address.AddressLine2,
        _updatedDianaKing.Address.City,
        _updatedDianaKing.Address.State,
        _updatedDianaKing.Address.Zipcode,
        _updatedDianaKing.Degree.ToString());
}
