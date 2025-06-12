using Mithril.Hr.Domain.Seeds.Positions;
using Mithril.Hr.Infrastructure.Persistence.Model.Positions;

namespace Mithril.Hr.Infrastructure.Tests.Seeds.Positions;

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
