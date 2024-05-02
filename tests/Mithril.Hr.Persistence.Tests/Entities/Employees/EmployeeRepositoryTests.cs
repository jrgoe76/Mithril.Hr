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
    private readonly EmployeeEf _liamHillEf = EmployeeEfTestSeed.LiamHill();

    [Fact]
    public async Task Adds_an_Employee_into_the_DbContext()
    {
        using var dbContextFactory = DbContextTestFactory.New();
        await using var dbContext = dbContextFactory.Create();

        await GetRepository(dbContext).Add(_liamHill);

        await AssertEmployeeVersionIsNotEmpty(dbContext);
        VerifyChangesWereSaved(dbContext);
    }

    [Fact]
    public async Task Updates_an_Employee_in_DbContext()
    {
        var latestVersion = _liamHillEf.Version;

        using var dbContextFactory = DbContextTestFactory.New();
        await using var dbContext = dbContextFactory.Create();

        await dbContext.Employees.AddAsync(_liamHillEf);
        await dbContext.SaveChangesAsync();
        dbContext.ResetStates();

        await GetRepository(dbContext).Update(_liamHill);

        await AssertEmployeeVersionChanged(dbContext, latestVersion);
        VerifyChangesWereSaved(dbContext);
    }

    private static EmployeeRepository GetRepository(DataContext dbContext)
        => new (
            dbContext,
            new GenderMapper(),
            new AcademicDegreeMapper());

    private static async Task AssertEmployeeVersionIsNotEmpty(DataContext dbContext)
        => (await dbContext.Employees.FirstAsync()).Version
            .Should().NotBeEmpty();

    private static async Task AssertEmployeeVersionChanged(DataContext dbContext, Guid latestVersion)
        => (await dbContext.Employees.FirstAsync()).Version
            .Should().NotBe(latestVersion);

    private static void VerifyChangesWereSaved(DataContextSpy dbContext)
        => dbContext.ChangesAreSaved
            .Should().BeTrue();
}
