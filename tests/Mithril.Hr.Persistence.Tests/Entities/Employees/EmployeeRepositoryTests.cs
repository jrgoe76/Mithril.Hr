using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Mithril.Hr.Persistence.Entities.Employees;
using Mithril.Hr.Persistence.Seeds.Employees;
using Mithril.Hr.Persistence.Tests.Helpers;
using Xunit;

namespace Mithril.Hr.Persistence.Tests.Entities.Employees;

public sealed class EmployeeRepositoryTests
{
    [Fact]
    public async Task AddsEmployeeIntoDbContext()
    {
        using var dbContextFactory = DbContextTestFactory.New();
        await using var dbContext = dbContextFactory.Create();

        await new EmployeeRepository(dbContext).Add(EmployeeEntitySeed.LiamHill);

        (await dbContext.Employees.FirstAsync()).Version
            .Should().NotBeEmpty();
        dbContext.ChangesAreSaved
            .Should().BeTrue();
    }

    [Fact]
    public async Task UpdatesEmployeeInDbContext()
    {
        var liamHill = EmployeeEntitySeed.LiamHill;
        var latestVersion = liamHill.Version;

        using var dbContextFactory = DbContextTestFactory.New();
        await using var dbContext = dbContextFactory.Create();

        await dbContext.Employees.AddAsync(liamHill);
        await dbContext.SaveChangesAsync();
        dbContext.ResetChangesAreSaved();

        await new EmployeeRepository(dbContext).Update(liamHill);

        (await dbContext.Employees.FirstAsync()).Version
            .Should().NotBe(latestVersion);
        dbContext.ChangesAreSaved
            .Should().BeTrue();
    }
}
