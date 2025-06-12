using Mithril.Hr.Domain.Model.Positions;

namespace Mithril.Hr.Infrastructure.Persistence.Model.Positions;

public sealed class PositionMapper
{
	public Position Map(PositionEf positionEf)
		=> new (positionEf.PositionCode, positionEf.Name);
}
