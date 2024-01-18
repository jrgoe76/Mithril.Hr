using FluentAssertions;
using Mithril.Hr.Application.Tests.Seeds.Employees;
using Mithril.Hr.Persistence.Entities.Employees;
using Mithril.Hr.Persistence.Tests.Helpers;
using Mithril.Hr.Persistence.Tests.Seeds.Employees;
using Xunit;

namespace Mithril.Hr.Persistence.Tests.Entities.Employees;

public sealed class GetAllEmployeesDetailQueryTests
{
    [Fact]
    public async Task ReturnsAllEmployeesDetail()
    {
	    var liamHillEntity = EmployeeEntityTestSeed.LiamHill();

	    using var dbContextFactory = DbContextTestFactory.New();
        await using var dbContext = dbContextFactory.Create();

        await dbContext.Employees.AddAsync(liamHillEntity);
        await dbContext.SaveChangesAsync();

        (await new GetAllEmployeesDetailQuery(dbContext).Get())
            .Should().BeEquivalentTo(new[] { EmployeeDetailTestSeed.LiamHill });
    }
}
