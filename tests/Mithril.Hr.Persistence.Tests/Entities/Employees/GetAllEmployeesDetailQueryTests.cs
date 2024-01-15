using FluentAssertions;
using Mithril.Hr.Application.Seeds.Employees;
using Mithril.Hr.Persistence.Entities.Employees;
using Mithril.Hr.Persistence.Seeds.Employees;
using Mithril.Hr.Persistence.Tests.Helpers;
using Xunit;

namespace Mithril.Hr.Persistence.Tests.Entities.Employees;

public sealed class GetAllEmployeesDetailQueryTests
{
    [Fact]
    public async Task ReturnsAllEmployeesDetail()
    {
        using var dbContextFactory = DbContextTestFactory.New();
        await using var dbContext = dbContextFactory.Create();

        await dbContext.Employees.AddAsync(EmployeeEntitySeed.LiamHill);
        await dbContext.SaveChangesAsync();

        (await new GetAllEmployeesDetailQuery(dbContext).Get())
            .Should().BeEquivalentTo(new[] { EmployeeDetailSeed.LiamHill });
    }
}
