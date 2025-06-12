using FluentAssertions;
using Mithril.Hr.Domain.Model.Positions;
using Mithril.Hr.Domain.Seeds.Positions;
using Mithril.Hr.Infrastructure.Persistence.Model.Positions;
using Mithril.Hr.Infrastructure.Persistence.Seeds.Positions;
using Mithril.Hr.Infrastructure.Tests.Helpers;
using Xunit;

namespace Mithril.Hr.Infrastructure.Tests.Persistence.Model.Positions;

public sealed class GetPositionByCodeQueryTests
{
    private readonly Position _ceo = PositionSeed.ChiefExecutiveOfficer();

    [Fact]
    public async Task Returns_a_Position_by_its_Code()
    {
        using var dbContextFactory = DbContextTestFactory.New();
        await using var dbContext = dbContextFactory.Create();

        await dbContext.Positions.AddRangeAsync(
            PositionEfSeed.ChiefExecutiveOfficer(),
            PositionEfSeed.ChiefOperatingOfficer());
        await dbContext.SaveChangesAsync();

        (await new GetPositionByCodeQuery(
                    dbContext,
                    new PositionMapper())
                .Get(_ceo.PositionCode))
            .Should().Be(_ceo);
    }
}