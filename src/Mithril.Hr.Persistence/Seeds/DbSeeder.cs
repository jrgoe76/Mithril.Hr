using Mithril.Hr.Application.Features.Employees;
using Mithril.Hr.Application.Seeds.Employees;
using Mithril.Hr.Persistence.Data;
using Mithril.Hr.Seeds.Positions;

namespace Mithril.Hr.Persistence.Seeds;

public sealed class DbSeeder(
    DataContext dbContext,
    IAddEmployeeFeature addEmployeeFeature)
{
    public async Task Run()
    {
        await dbContext.Database.EnsureCreatedAsync();

        await SeedPositions();
        await RunAddEmployeeFeatures();
    }

    private async Task SeedPositions()
    {
        await dbContext.Positions.AddRangeAsync(
            PositionSeed.ChiefExecutiveOfficer,
            PositionSeed.ChiefFinancialOfficer,
            PositionSeed.AccountingManager,
            PositionSeed.Accountant,
            PositionSeed.ChiefOperatingOfficer,
            PositionSeed.StoreManager,
            PositionSeed.SectionLeader,
            PositionSeed.StockAssistant);

        await dbContext.SaveChangesAsync();
    }

    private async Task RunAddEmployeeFeatures()
    {
        await addEmployeeFeature.Add(AddEmployeeInfoSeed.LiamHill);
        await addEmployeeFeature.Add(AddEmployeeInfoSeed.PaulaCarr);
        await addEmployeeFeature.Add(AddEmployeeInfoSeed.DianaKing);
    }
}
