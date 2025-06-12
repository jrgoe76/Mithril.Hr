using Microsoft.EntityFrameworkCore;
using Mithril.Hr.Domain.Model.Positions;

namespace Mithril.Hr.Infrastructure.Persistence.Model.Positions;

internal sealed class GetPositionByCodeQuery(
    DataContext dbContext,
    PositionMapper positionMapper) : IGetPositionByCodeQuery
{
    public async Task<Position> Get(string positionCode)
        => positionMapper.Map(await dbContext.Positions
            .SingleAsync(position => position.PositionCode == positionCode));
}