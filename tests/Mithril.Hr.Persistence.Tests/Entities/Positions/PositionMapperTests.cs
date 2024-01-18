using FluentAssertions;
using Mithril.Hr.Persistence.Entities.Positions;
using Mithril.Hr.Persistence.Tests.Seeds.Positions;
using Mithril.Hr.Seeds.Positions;
using Xunit;

namespace Mithril.Hr.Persistence.Tests.Entities.Positions;

public sealed class PositionMapperTests
{
	[Fact]
	public void MapsPosition()
	{
		new PositionMapper().Map(PositionEntityTestSeed.ChiefExecutiveOfficer())
			.Should().Be(PositionSeed.ChiefExecutiveOfficer);
	}
}
