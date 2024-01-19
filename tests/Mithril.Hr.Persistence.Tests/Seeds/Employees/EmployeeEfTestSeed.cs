using Mithril.Hr.Domain.Employees;
using Mithril.Hr.Persistence.Entities.Demographics;
using Mithril.Hr.Persistence.Entities.Education;
using Mithril.Hr.Persistence.Entities.Employees;
using Mithril.Hr.Seeds.Employees;

namespace Mithril.Hr.Persistence.Tests.Seeds.Employees;

public static class EmployeeEfTestSeed
{
    private static readonly Employee _liamHill = EmployeeSeed.LiamHill();
    private static readonly Employee _dianaKing = EmployeeSeed.DianaKing();

    private static readonly AcademicDegreeMapper _academicDegreeMapper = new ();
    private static readonly GenderMapper _genderMapper = new ();

    public static EmployeeEf LiamHill() => new ()
	    {
			EmployeeId = _liamHill.EmployeeId,
			FirstName = _liamHill.Name.FirstName,
			MiddleInitial = _liamHill.Name.MiddleInitial,
			LastName = _liamHill.Name.LastName,
			Gender = _genderMapper.MapCode(_liamHill.Gender),
			EmailAddress = _liamHill.Email.Address,
			AddressLine1 = _liamHill.Address.AddressLine1,
			AddressLine2 = _liamHill.Address.AddressLine2,
			City = _liamHill.Address.City,
			State = _liamHill.Address.State,
			Zipcode = _liamHill.Address.Zipcode,
			Degree = _academicDegreeMapper.MapCode(_liamHill.Degree)
	    };

    public static EmployeeEf DianaKing() => new ()
	    {
		    EmployeeId = _dianaKing.EmployeeId,
		    FirstName = _dianaKing.Name.FirstName,
		    MiddleInitial = _dianaKing.Name.MiddleInitial,
		    LastName = _dianaKing.Name.LastName,
		    Gender = _genderMapper.MapCode(_dianaKing.Gender),
		    EmailAddress = _dianaKing.Email.Address,
		    AddressLine1 = _dianaKing.Address.AddressLine1,
		    AddressLine2 = _dianaKing.Address.AddressLine2,
		    City = _dianaKing.Address.City,
		    State = _dianaKing.Address.State,
		    Zipcode = _dianaKing.Address.Zipcode,
		    Degree = _academicDegreeMapper.MapCode(_dianaKing.Degree)
	    };


    public static EmployeeEf DianaKingWithContract(DateOnly startedOn, DateOnly? endedOn = null)
    {
	    var contract = ContractSeed.DianaKing(startedOn);

	    return new EmployeeEf
	    {
		    EmployeeId = _dianaKing.EmployeeId,
		    FirstName = _dianaKing.Name.FirstName,
		    MiddleInitial = _dianaKing.Name.MiddleInitial,
		    LastName = _dianaKing.Name.LastName,
		    Gender = _genderMapper.MapCode(_dianaKing.Gender),
		    EmailAddress = _dianaKing.Email.Address,
		    AddressLine1 = _dianaKing.Address.AddressLine1,
		    AddressLine2 = _dianaKing.Address.AddressLine2,
		    City = _dianaKing.Address.City,
		    State = _dianaKing.Address.State,
		    Zipcode = _dianaKing.Address.Zipcode,
		    Degree = _academicDegreeMapper.MapCode(_dianaKing.Degree),
		    Contract = new ContractEf
		    {
			    PositionCode = contract.Position.PositionCode,
				SupervisorId = contract.SupervisorId,
				StartedOn = contract.StartedOn,
				EndedOn = endedOn
		    }
	    };
    }
}
