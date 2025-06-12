using Mithril.Hr.Domain.Model.Positions;

namespace Mithril.Hr.Application.Features.Positions;

public sealed class AddPositionFeature(
	IPositionRepository positionRepository)
{
	public async Task<PositionInfo> Add(PositionInfo addPositionInfo)
	{
		var position = new Position(addPositionInfo.PositionCode, addPositionInfo.Name);

		await positionRepository.Add(position);

		return new PositionInfo(position.PositionCode, position.Name);
	}
}
