using FluentAssertions;
using Mithril.Hr.Domain.Seeds.Positions;
using Mithril.Hr.Infrastructure.Persistence.Model.Positions;
using Mithril.Hr.Infrastructure.Tests.Seeds.Positions;
using Xunit;

namespace Mithril.Hr.Infrastructure.Tests.Persistence.Model.Positions;

public sealed class PositionMapperTests
{
    [Fact]
    public void Maps_Position()
    {
        new PositionMapper().Map(PositionEfTestSeed.ChiefExecutiveOfficer())
            .Should().Be(PositionSeed.ChiefExecutiveOfficer);
    }
}