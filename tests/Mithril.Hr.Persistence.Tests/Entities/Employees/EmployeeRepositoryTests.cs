using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Mithril.Hr.Domain.Employees;
using Mithril.Hr.Persistence.Data;
using Mithril.Hr.Persistence.Entities.Demographics;
using Mithril.Hr.Persistence.Entities.Education;
using Mithril.Hr.Persistence.Entities.Employees;
using Mithril.Hr.Persistence.Tests.Helpers;
using Mithril.Hr.Persistence.Tests.Seeds.Employees;
using Mithril.Hr.Seeds.Employees;
using Xunit;

namespace Mithril.Hr.Persistence.Tests.Entities.Employees;

public sealed class EmployeeRepositoryTests
{
    private readonly Employee _liamHill = EmployeeSeed.LiamHill();
    private readonly EmployeeEntity _liamHillEntity = EmployeeEntityTestSeed.LiamHill();

    [Fact]
    public async Task AddsEmployeeIntoDbContext()
    {
        using var dbContextFactory = DbContextTestFactory.New();
        await using var dbContext = dbContextFactory.Create();

        await GetRepository(dbContext).Add(_liamHill);

        (await dbContext.Employees.FirstAsync()).Version
            .Should().NotBeEmpty();
        dbContext.ChangesAreSaved
            .Should().BeTrue();
    }

    [Fact]
    public async Task UpdatesEmployeeInDbContext()
    {
        var latestVersion = _liamHillEntity.Version;

        using var dbContextFactory = DbContextTestFactory.New();
        await using var dbContext = dbContextFactory.Create();

        await dbContext.Employees.AddAsync(_liamHillEntity);
        await dbContext.SaveChangesAsync();
        dbContext.ResetStates();

        await GetRepository(dbContext).Update(_liamHill);

        (await dbContext.Employees.FirstAsync()).Version
            .Should().NotBe(latestVersion);
        dbContext.ChangesAreSaved
            .Should().BeTrue();
    }

    private static EmployeeRepository GetRepository(DataContext dbContext)
        => new (
            dbContext,
            new GenderMapper(),
            new AcademicDegreeMapper());
}
