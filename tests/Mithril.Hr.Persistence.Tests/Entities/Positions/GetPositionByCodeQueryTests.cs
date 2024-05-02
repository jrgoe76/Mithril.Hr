using FluentAssertions;
using Mithril.Hr.Persistence.Entities.Positions;
using Mithril.Hr.Persistence.Tests.Helpers;
using Mithril.Hr.Persistence.Tests.Seeds.Positions;
using Mithril.Hr.Seeds.Positions;
using Xunit;

namespace Mithril.Hr.Persistence.Tests.Entities.Positions;

public sealed class GetPositionByCodeQueryTests
{
    [Fact]
    public async Task Returns_a_Position_by_its_Code()
    {
        using var dbContextFactory = DbContextTestFactory.New();
        await using var dbContext = dbContextFactory.Create();

        await dbContext.Positions.AddRangeAsync(
            PositionEfTestSeed.ChiefExecutiveOfficer(),
            PositionEfTestSeed.ChiefOperatingOfficer());
        await dbContext.SaveChangesAsync();

        (await new GetPositionByCodeQuery(
			    dbContext,
			    new PositionMapper())
            .Get(PositionSeed.ChiefExecutiveOfficer.PositionCode))
            .Should().Be(PositionSeed.ChiefExecutiveOfficer);
    }
}
