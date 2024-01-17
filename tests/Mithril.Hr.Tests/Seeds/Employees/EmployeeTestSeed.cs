using Mithril.Hr.Domain.Demographics;
using Mithril.Hr.Domain.Education;
using Mithril.Hr.Domain.Employees;
using Mithril.Hr.Seeds.Demographics;
using Mithril.Hr.Seeds.Employees;
using Mithril.Hr.Seeds.Positions;

namespace Mithril.Hr.Tests.Seeds.Employees;

public static class EmployeeTestSeed
{
    private static readonly Employee DianaKing = EmployeeSeed.DianaKing;

    public static Employee UpdatedDianaKing => new (
        DianaKing.EmployeeId,
        new PersonName(
            $"updated {DianaKing.Name.FirstName}",
            "X",
            $"updated {DianaKing.Name.LastName}"),
        Gender.Male,
        new Email($"updated{EmailSeed.DianaKingAtAol}"),
        AddressSeed.BeachSt,
        AcademicDegree.Master);

    public static Func<DateOnly, Employee> DianaKingWithContract = startDate => new Employee(
        DianaKing.EmployeeId,
        DianaKing.Name,
        DianaKing.Gender,
        DianaKing.Email,
        DianaKing.Address,
        DianaKing.Degree)
        {   
            Contract = new Contract(
                PositionSeed.ChiefFinancialOfficer,
                EmployeeSeed.LiamHill.EmployeeId,
                startDate)
        };
}
