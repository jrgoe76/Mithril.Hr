using Mithril.Hr.Domain.Positions;
using Mithril.Hr.Persistence.Data;

namespace Mithril.Hr.Persistence.Entities.Positions;

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
