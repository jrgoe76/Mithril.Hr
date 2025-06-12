using Mithril.Hr.Domain.Model.Positions;

namespace Mithril.Hr.Infrastructure.Persistence.Model.Positions;

internal sealed class PositionRepository(
    DataContext dbContext
) : IPositionRepository
{
    public async Task Add(Position position)
    {
        var positionEf = new PositionEf();

        positionEf.Update(position, Guid.NewGuid());

        await dbContext.Positions.AddAsync(positionEf);
        await dbContext.SaveChangesAsync();
    }
}