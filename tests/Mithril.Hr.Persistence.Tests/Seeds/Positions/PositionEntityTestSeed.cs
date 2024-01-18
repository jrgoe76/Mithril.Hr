using Mithril.Hr.Persistence.Entities.Positions;
using Mithril.Hr.Seeds.Positions;

namespace Mithril.Hr.Persistence.Tests.Seeds.Positions;

public static class PositionEntityTestSeed
{
	public static PositionEntity ChiefExecutiveOfficer() => new()
		{
			PositionCode = PositionSeed.ChiefExecutiveOfficer.PositionCode,
			Name = PositionSeed.ChiefExecutiveOfficer.Name
		};
}
