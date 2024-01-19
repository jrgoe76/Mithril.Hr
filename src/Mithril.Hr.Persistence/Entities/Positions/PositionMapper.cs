using Mithril.Hr.Domain.Positions;

namespace Mithril.Hr.Persistence.Entities.Positions;

public sealed class PositionMapper
{
	public Position Map(PositionEf positionEf)
		=> new (positionEf.PositionCode, positionEf.Name);
}
