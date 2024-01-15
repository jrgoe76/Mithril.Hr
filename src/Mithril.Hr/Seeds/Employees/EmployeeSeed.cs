using Mithril.Hr.Domain.Demographics;
using Mithril.Hr.Domain.Education;
using Mithril.Hr.Domain.Employees;
using Mithril.Hr.Seeds.Demographics;
using Mithril.Hr.Seeds.Positions;

namespace Mithril.Hr.Seeds.Employees;

public static class EmployeeSeed
{
    public static Employee LiamHill = new (
        Guid.Parse("f79e1408-844a-43c9-9375-37a664f67a2a"),
        PersonNameSeed.LiamHill,
        Gender.Male,
        EmailSeed.LiamHillAtGmail,
        AddressSeed.MainSt,
        AcademicDegree.Master)
    {
        Position = PositionSeed.ChiefExecutiveOfficer
    };

    public static Employee PaulaCarr = new (
        Guid.Parse("a3a89c86-64e0-46a3-a1a1-cd3241875f8f"),
        PersonNameSeed.PaulaCarr,
        Gender.Female,
        EmailSeed.PaulaCarrAtGmail,
        AddressSeed.BeachSt,
        AcademicDegree.Master)
    {
        Position = PositionSeed.ChiefOperatingOfficer,
        SupervisorId = LiamHill.SupervisorId
    };

    public static Employee DianaKing = new (
        Guid.Parse("cfef364d-e8a1-437e-8165-a47a4b6f9c9e"),
        PersonNameSeed.DianaKing,
        Gender.Female,
        EmailSeed.DianaKingAtAol,
        AddressSeed.MadisonAve,
        AcademicDegree.PhD)
    {
        Position = PositionSeed.ChiefFinancialOfficer,
        SupervisorId = LiamHill.SupervisorId
    };
}
