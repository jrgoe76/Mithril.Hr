using Mithril.Hr.Domain.Positions;

namespace Mithril.Hr.Persistence.Entities.Positions;

public sealed class PositionMapper
{
	public Position Map(PositionEntity positionEntity)
		=> new (positionEntity.PositionCode, positionEntity.Name);
}
