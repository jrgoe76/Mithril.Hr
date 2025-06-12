using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Mithril.Hr.Domain.Model.Employees;
using Mithril.Hr.Domain.Seeds.Employees;
using Mithril.Hr.Infrastructure.Persistence.Model;
using Mithril.Hr.Infrastructure.Persistence.Model.Demographics;
using Mithril.Hr.Infrastructure.Persistence.Model.Education;
using Mithril.Hr.Infrastructure.Persistence.Model.Employees;
using Mithril.Hr.Infrastructure.Persistence.Seeds.Employees;
using Mithril.Hr.Infrastructure.Tests.Helpers;
using Xunit;

namespace Mithril.Hr.Infrastructure.Tests.Persistence.Model.Employees;

public sealed class EmployeeRepositoryTests
{
    private readonly Employee _liamHill = EmployeeSeed.LiamHill();
    private readonly EmployeeEf _liamHillEf = EmployeeEfSeed.LiamHill();

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
        => new(
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