using Mithril.Hr.Domain.Model.Positions;

namespace Mithril.Hr.Application.Features.Positions;

public sealed class AddPositionFeature(
    IPositionRepository positionRepository)
{
    public async Task<PositionInfo> Add(PositionInfo addPositionInfo)
    {
        Position position = new(addPositionInfo.PositionCode, addPositionInfo.Name);

        await positionRepository.Add(position);

        return new PositionInfo(position.PositionCode, position.Name);
    }
}