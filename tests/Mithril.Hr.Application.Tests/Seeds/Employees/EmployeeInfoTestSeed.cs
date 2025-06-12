using Mithril.Hr.Application.Features.Employees;
using Mithril.Hr.Domain.Model.Employees;
using Mithril.Hr.Domain.Seeds.Employees;
using Mithril.Hr.Domain.Tests.Seeds.Employees;

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

    public static EmployeeInfo DianaKingWithContract(DateOnly startedOn)
    {
	    var dianaKing = EmployeeTestSeed.DianaKingWithContract(startedOn);
	    var contract = dianaKing.Contract!;

	    return new EmployeeInfo(
		    dianaKing.EmployeeId,
		    dianaKing.Name.FirstName,
		    dianaKing.Name.MiddleInitial,
		    dianaKing.Name.LastName,
		    dianaKing.Gender.ToString(),
		    dianaKing.Email.Address,
		    dianaKing.Address.AddressLine1,
		    dianaKing.Address.AddressLine2,
		    dianaKing.Address.City,
		    dianaKing.Address.State,
		    dianaKing.Address.Zipcode,
		    dianaKing.Degree.ToString(),
		    new ContractInfo(
			    contract.Position.PositionCode,
			    contract.SupervisorId,
			    contract.StartedOn,
			    contract.EndedOn));
    }
}