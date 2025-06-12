using FluentAssertions;
using Mithril.Hr.Application.Tests.Seeds.Employees;
using Mithril.Hr.Infrastructure.Persistence.Model.Employees;
using Mithril.Hr.Infrastructure.Persistence.Seeds.Employees;
using Mithril.Hr.Infrastructure.Tests.Helpers;
using Xunit;

namespace Mithril.Hr.Infrastructure.Tests.Persistence.Model.Employees;

public sealed class GetAllEmployeesDetailQueryTests
{
    [Fact]
    public async Task Returns_all_EmployeesDetail()
    {
        var liamHillEf = EmployeeEfSeed.LiamHill();

        using var dbContextFactory = DbContextTestFactory.New();
        await using var dbContext = dbContextFactory.Create();

        await dbContext.Employees.AddAsync(liamHillEf);
        await dbContext.SaveChangesAsync();

        (await new GetAllEmployeesDetailQuery(dbContext).Get())
            .Should().BeEquivalentTo(new[] { EmployeeDetailTestSeed.LiamHill });
    }
}