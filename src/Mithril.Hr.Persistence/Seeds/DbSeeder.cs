using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mithril.Hr.Application.Features.Employees;
using Mithril.Hr.Application.Features.Positions;
using Mithril.Hr.Application.Seeds.Employees;
using Mithril.Hr.Application.Seeds.Positions;
using Mithril.Hr.Persistence.Data;

namespace Mithril.Hr.Persistence.Seeds;

public sealed class DbSeeder(
    DataContext dbContext,
    AddPositionFeature addPositionFeature,
    AddEmployeeFeature addEmployeeFeature,
    ILogger<DbSeeder> logger)
{
	public static Task Run(
		IServiceProvider serviceProvider,
		string environment)
	{
		var scope = serviceProvider.CreateScope();
		var dbSeeder = scope.ServiceProvider.GetRequiredService<DbSeeder>();

		return dbSeeder.Run(environment);
	}

    private async Task Run(string environment)
    {
	    logger.LogInformation($"Seeding {environment} database...");

	    await dbContext.Database.EnsureCreatedAsync();

        await SeedPositions();
        await SeedEmployees();
    }

    private async Task SeedPositions()
    {
	    logger.LogInformation("[x] Adding Positions");

        await addPositionFeature.Add(PositionInfoSeed.ChiefExecutiveOfficer);
        await addPositionFeature.Add(PositionInfoSeed.ChiefOperatingOfficer);
        await addPositionFeature.Add(PositionInfoSeed.StoreManager);
        await addPositionFeature.Add(PositionInfoSeed.SectionLeader);
        await addPositionFeature.Add(PositionInfoSeed.StockAssistant);
        await addPositionFeature.Add(PositionInfoSeed.ChiefFinancialOfficer);
        await addPositionFeature.Add(PositionInfoSeed.AccountingManager);
        await addPositionFeature.Add(PositionInfoSeed.Accountant);

        await dbContext.SaveChangesAsync();
    }

    private async Task SeedEmployees()
    {
	    logger.LogInformation("[x] Adding Employees");

        await addEmployeeFeature.Add(AddEmployeeInfoSeed.LiamHill);
        await addEmployeeFeature.Add(AddEmployeeInfoSeed.PaulaCarr);
        await addEmployeeFeature.Add(AddEmployeeInfoSeed.DianaKing);
    }
}
