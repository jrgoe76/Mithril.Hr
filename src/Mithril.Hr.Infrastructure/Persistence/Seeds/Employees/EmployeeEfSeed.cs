using Mithril.Hr.Domain.Model.Employees;
using Mithril.Hr.Domain.Seeds.Employees;
using Mithril.Hr.Infrastructure.Persistence.Model.Demographics;
using Mithril.Hr.Infrastructure.Persistence.Model.Education;
using Mithril.Hr.Infrastructure.Persistence.Model.Employees;

namespace Mithril.Hr.Infrastructure.Persistence.Seeds.Employees;

public static class EmployeeEfSeed
{
    public static EmployeeEf LiamHill() => Map(EmployeeSeed.LiamHill());
    public static EmployeeEf PaulaCarr() => Map(EmployeeSeed.PaulaCarr());
    public static EmployeeEf DianaKing() => Map(EmployeeSeed.DianaKing());

    public static EmployeeEf DianaKingAsChiefFinancialOfficer(
        DateOnly startedOn,
        DateOnly? endedOn = null)
    {
        var contract = ContractSeed.DianaKingAsChiefFinancialOfficer(startedOn);

        var dianaKing = DianaKing();
        dianaKing.Contract = new ContractEf
        {
            PositionCode = contract.Position.PositionCode,
            SupervisorId = contract.SupervisorId,
            StartedOn = contract.StartedOn,
            EndedOn = endedOn
        };

        return dianaKing;
    }

    private static EmployeeEf Map(Employee employee)
        => new(
            employee,
            new GenderMapper(),
            new AcademicDegreeMapper(),
            Guid.NewGuid());
}