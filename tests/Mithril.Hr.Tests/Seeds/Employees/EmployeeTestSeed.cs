using Mithril.Hr.Domain.Demographics;
using Mithril.Hr.Domain.Education;
using Mithril.Hr.Domain.Employees;
using Mithril.Hr.Seeds.Demographics;
using Mithril.Hr.Seeds.Employees;
using Mithril.Hr.Seeds.Positions;

namespace Mithril.Hr.Tests.Seeds.Employees;

public static class EmployeeTestSeed
{
	private static readonly Employee _liamHill = EmployeeSeed.LiamHill();
    private static readonly Employee _dianaKing = EmployeeSeed.DianaKing();

    public static Employee UpdatedDianaKing() => new (
	    _dianaKing.EmployeeId,
        new PersonName(
            $"updated {_dianaKing.Name.FirstName}",
            "X",
            $"updated {_dianaKing.Name.LastName}"),
        Gender.Male,
        new Email($"updated{EmailSeed.DianaKingAtAol}"),
        AddressSeed.BeachSt,
        AcademicDegree.Master);

    public static Employee DianaKingWithContract(DateOnly startDate) 
	    => new (_dianaKing.EmployeeId, _dianaKing.Name, _dianaKing.Gender,
		    _dianaKing.Email, _dianaKing.Address, _dianaKing.Degree)
	        {
	            Contract = new Contract(PositionSeed.ChiefFinancialOfficer, 
		            _liamHill.EmployeeId, startDate)
	        };
}
