using Microsoft.EntityFrameworkCore;
using Mithril.Hr.Domain.Positions;
using Mithril.Hr.Persistence.Data;

namespace Mithril.Hr.Persistence.Entities.Positions;

internal sealed class GetPositionByCodeQuery(
    DataContext dbContext) : IGetPositionByCodeQuery
{
    public async Task<Position> Get(string positionCode)
        => await dbContext.Positions
            .SingleAsync(position => position.PositionCode == positionCode);
}
