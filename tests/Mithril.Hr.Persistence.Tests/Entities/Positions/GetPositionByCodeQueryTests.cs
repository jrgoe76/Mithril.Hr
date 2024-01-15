using FluentAssertions;
using Mithril.Hr.Persistence.Entities.Positions;
using Mithril.Hr.Persistence.Tests.Helpers;
using Mithril.Hr.Seeds.Positions;
using Xunit;

namespace Mithril.Hr.Persistence.Tests.Entities.Positions;

public sealed class GetPositionByCodeQueryTests
{
    [Fact]
    public async Task ReturnsPosition()
    {
        using var dbContextFactory = DbContextTestFactory.New();
        await using var dbContext = dbContextFactory.Create()
            ;
        await dbContext.Positions.AddAsync(PositionSeed.ChiefOperatingOfficer);
        await dbContext.SaveChangesAsync();

        (await new GetPositionByCodeQuery(dbContext).Get(PositionSeed.ChiefOperatingOfficer.PositionCode))
            .Should().Be(PositionSeed.ChiefOperatingOfficer);
    }
}
