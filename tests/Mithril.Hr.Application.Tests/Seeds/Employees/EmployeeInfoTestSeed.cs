using Mithril.Hr.Application.Features.Employees;
using Mithril.Hr.Domain.Employees;
using Mithril.Hr.Seeds.Employees;

namespace Mithril.Hr.Application.Tests.Seeds.Employees;

public static class EmployeeInfoTestSeed
{
	private static readonly Employee _liamHill = EmployeeSeed.LiamHill();

	public static EmployeeInfo LiamHill = new (
        _liamHill.EmployeeId,
        _liamHill.Name.FirstName,
        _liamHill.Name.MiddleInitial,
        _liamHill.Name.LastName,
        _liamHill.Gender.ToString(),
        _liamHill.Email.Address,
        _liamHill.Address.AddressLine1,
        _liamHill.Address.AddressLine2,
        _liamHill.Address.City,
        _liamHill.Address.State,
        _liamHill.Address.Zipcode,
        _liamHill.Degree.ToString());
}
