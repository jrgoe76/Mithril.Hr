﻿using FluentAssertions;
using Mithril.Hr.Persistence.Entities.Positions;
using Mithril.Hr.Persistence.Tests.Seeds.Positions;
using Mithril.Hr.Seeds.Positions;
using Xunit;

namespace Mithril.Hr.Persistence.Tests.Entities.Positions;

public sealed class PositionMapperTests
{
	[Fact]
	public void Maps_Position()
	{
		new PositionMapper().Map(PositionEfTestSeed.ChiefExecutiveOfficer())
			.Should().Be(PositionSeed.ChiefExecutiveOfficer);
	}
}
