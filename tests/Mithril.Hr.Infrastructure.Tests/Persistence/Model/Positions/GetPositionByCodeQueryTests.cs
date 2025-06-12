using FluentAssertions;
using Mithril.Hr.Domain.Seeds.Positions;
using Mithril.Hr.Infrastructure.Persistence.Model.Positions;
using Mithril.Hr.Infrastructure.Tests.Helpers;
using Mithril.Hr.Infrastructure.Tests.Seeds.Positions;
using Xunit;

namespace Mithril.Hr.Infrastructure.Tests.Persistence.Model.Positions;

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