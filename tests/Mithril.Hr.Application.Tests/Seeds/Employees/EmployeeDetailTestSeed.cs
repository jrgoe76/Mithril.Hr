using Mithril.Hr.Application.Features.Employees;
using Mithril.Hr.Domain.Employees;
using Mithril.Hr.Seeds.Employees;

namespace Mithril.Hr.Application.Tests.Seeds.Employees;

public static class EmployeeDetailTestSeed
{
	private static readonly Employee _liamHill = EmployeeSeed.LiamHill();

	public static EmployeeDetail LiamHill = new (
        _liamHill.EmployeeId,
        _liamHill.Name.FirstName,
        _liamHill.Name.MiddleInitial,
        _liamHill.Name.LastName);
}
