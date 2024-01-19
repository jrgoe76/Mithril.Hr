using FluentAssertions;
using Mithril.Hr.Persistence.Entities.Positions;
using Mithril.Hr.Persistence.Tests.Seeds.Positions;
using Mithril.Hr.Seeds.Positions;
using Xunit;

namespace Mithril.Hr.Persistence.Tests.Entities.Positions;

public sealed class PositionEfTests
{
	[Fact]
	public void UpdatesPosition()
	{
		var ceo = PositionSeed.ChiefExecutiveOfficer;
		var ceoEf = PositionEfTestSeed.ChiefExecutiveOfficer();

		var latestVersion = ceoEf.Version;
		var version = Guid.NewGuid();
		ceoEf.Version = version;

        new PositionEf { PositionCode = ceo.PositionCode }
			.Update(ceo, version)
			.Should().Be(ceoEf);
        latestVersion
	        .Should().NotBe(version);
	}
}
