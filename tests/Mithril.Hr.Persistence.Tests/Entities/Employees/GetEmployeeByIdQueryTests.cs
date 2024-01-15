using FluentAssertions;
using Mithril.Hr.Persistence.Entities.Employees;
using Mithril.Hr.Persistence.Seeds.Employees;
using Mithril.Hr.Persistence.Tests.Helpers;
using Xunit;

namespace Mithril.Hr.Persistence.Tests.Entities.Employees;

public sealed class GetEmployeeByIdQueryTests
{
    [Fact]
    public async Task ReturnsEmployee()
    {
        using var dbContextFactory = DbContextTestFactory.New();
        await using var dbContext = dbContextFactory.Create();

        await dbContext.Employees.AddAsync(EmployeeEntitySeed.LiamHill);
        await dbContext.SaveChangesAsync();

        (await new GetEmployeeByIdQuery(dbContext).Get(EmployeeEntitySeed.LiamHill.EmployeeId))
            .Should().Be(EmployeeEntitySeed.LiamHill);
    }
}
