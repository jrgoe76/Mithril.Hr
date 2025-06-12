using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mithril.Hr.Infrastructure.Persistence.Model;
using Mithril.Hr.Infrastructure.Persistence.Seeds.Employees;
using Mithril.Hr.Infrastructure.Persistence.Seeds.Positions;

namespace Mithril.Hr.Infrastructure.Persistence.Seeds;

public sealed class DbSeeder(
    DataContext dbContext,
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

        await dbContext.Positions.AddRangeAsync(
            PositionEfSeed.ChiefExecutiveOfficer(),
            PositionEfSeed.ChiefOperatingOfficer(),
            PositionEfSeed.StoreManager(),
            PositionEfSeed.SectionLeader(),
            PositionEfSeed.StockAssistant(),
            PositionEfSeed.ChiefFinancialOfficer(),
            PositionEfSeed.AccountingManager(),
            PositionEfSeed.Accountant());

        await dbContext.SaveChangesAsync();
    }

    private async Task SeedEmployees()
    {
        logger.LogInformation("[x] Adding Employees");

        DateOnly today = DateOnly.FromDateTime(DateTime.Today);

        await dbContext.Employees.AddRangeAsync(
            EmployeeEfSeed.LiamHill(),
            EmployeeEfSeed.PaulaCarr(),
            EmployeeEfSeed.DianaKingAsChiefFinancialOfficer(today.AddMonths(-1)));

        await dbContext.SaveChangesAsync();
    }
}