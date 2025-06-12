using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mithril.Hr.Application.Features.Employees;
using Mithril.Hr.Application.Features.Positions;
using Mithril.Hr.Application.Seeds.Employees;
using Mithril.Hr.Application.Seeds.Positions;
using Mithril.Hr.Infrastructure.Persistence.Model;

namespace Mithril.Hr.Infrastructure.Persistence.Seeds;

public sealed class DbSeeder(
    DataContext dbContext,
    AddPositionFeature addPositionFeature,
    AddEmployeeFeature addEmployeeFeature,
    AssignContractToEmployeeFeature assignContractFeature,
    ILogger<DbSeeder> logger)
{
	public static Task Run(
		IServiceProvider serviceProvider,
		string environment)
	{
		IServiceScope scope = serviceProvider.CreateScope();
		DbSeeder dbSeeder = scope.ServiceProvider.GetRequiredService<DbSeeder>();

		return dbSeeder.Run(environment);
	}

    private async Task Run(string environment)
    {
	    logger.LogInformation("Seeding {Environment} database...", environment);

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
        DateOnly today = DateOnly.FromDateTime(DateTime.Today);

	    logger.LogInformation("[x] Adding Employees");

        var liamHillInfo = await addEmployeeFeature.Add(AddEmployeeInfoSeed.LiamHill);

        await addEmployeeFeature.Add(AddEmployeeInfoSeed.PaulaCarr);

        var dianaKingInfo = await addEmployeeFeature.Add(AddEmployeeInfoSeed.DianaKing);

        // Save changes to ensure employees are persisted before assigning contracts
        await dbContext.SaveChangesAsync();

        // Use the actual employee IDs returned from the add operations
        var assignContractInfo = new AssignContractInfo(
            dianaKingInfo.EmployeeId,
            PositionInfoSeed.ChiefFinancialOfficer.PositionCode,
            liamHillInfo.EmployeeId,
            today);

        await assignContractFeature.Assign(assignContractInfo);
    }
}
