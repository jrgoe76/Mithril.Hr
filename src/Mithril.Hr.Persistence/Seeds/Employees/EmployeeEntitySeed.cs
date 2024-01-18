using Mithril.Hr.Domain.Employees;
using Mithril.Hr.Persistence.Entities.Employees;
using Mithril.Hr.Seeds.Employees;

namespace Mithril.Hr.Persistence.Seeds.Employees;

public static class EmployeeEntitySeed
{
	private static readonly Employee _liamHill = EmployeeSeed.LiamHill();
	private static readonly Employee _dianaKing = EmployeeSeed.DianaKing();

	public static EmployeeEntity LiamHill => new (
        _liamHill.EmployeeId,
        _liamHill.Name,
        _liamHill.Gender,
        _liamHill.Email,
        _liamHill.Address,
        _liamHill.Degree);

    public static EmployeeEntity DianaKing => new (
        _dianaKing.EmployeeId,
        _dianaKing.Name,
        _dianaKing.Gender,
        _dianaKing.Email,
        _dianaKing.Address,
        _dianaKing.Degree);
}
