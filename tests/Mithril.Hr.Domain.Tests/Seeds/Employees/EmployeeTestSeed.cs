using Mithril.Hr.Domain.Model.Demographics;
using Mithril.Hr.Domain.Model.Education;
using Mithril.Hr.Domain.Model.Employees;
using Mithril.Hr.Domain.Seeds.Demographics;
using Mithril.Hr.Domain.Seeds.Employees;

namespace Mithril.Hr.Domain.Tests.Seeds.Employees;

public static class EmployeeTestSeed
{
    private static readonly Employee _dianaKing = EmployeeSeed.DianaKing();

    public static Employee UpdatedDianaKing() => new(
        _dianaKing.EmployeeId,
        new PersonName(
            $"updated {_dianaKing.Name.FirstName}",
            "X",
            $"updated {_dianaKing.Name.LastName}"),
        Gender.Male,
        new Email($"updated{EmailSeed.DianaKingAtAol}"),
        AddressSeed.BeachSt,
        AcademicDegree.Master);

    public static Employee DianaKingWithContract(DateOnly startedOn, DateOnly? endedOn = null)
        => new(_dianaKing.EmployeeId, _dianaKing.Name, _dianaKing.Gender,
            _dianaKing.Email, _dianaKing.Address, _dianaKing.Degree)
        {
            Contract = ContractSeed.DianaKing(startedOn) with { EndedOn = endedOn }
        };
}