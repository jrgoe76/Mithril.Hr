using FluentAssertions;
using Mithril.Hr.Domain.Seeds.Positions;
using Mithril.Hr.Infrastructure.Persistence.Model.Positions;
using Mithril.Hr.Infrastructure.Tests.Seeds.Positions;
using Xunit;

namespace Mithril.Hr.Infrastructure.Tests.Persistence.Model.Positions;

public sealed class PositionEfTests
{
	[Fact]
	public void Updates_Position()
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
