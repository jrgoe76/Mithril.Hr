using Mithril.Hr.Persistence.Entities.Positions;
using Mithril.Hr.Seeds.Positions;

namespace Mithril.Hr.Persistence.Tests.Seeds.Positions;

public static class PositionEfTestSeed
{
	public static PositionEf ChiefExecutiveOfficer() 
        => new ()
		{
			PositionCode = PositionSeed.ChiefExecutiveOfficer.PositionCode,
			Name = PositionSeed.ChiefExecutiveOfficer.Name
		};
    
    public static PositionEf ChiefOperatingOfficer() 
        => new ()
        {
            PositionCode = PositionSeed.ChiefOperatingOfficer.PositionCode,
            Name = PositionSeed.ChiefOperatingOfficer.Name
        };
}
