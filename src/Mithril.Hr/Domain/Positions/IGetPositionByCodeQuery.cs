namespace Mithril.Hr.Domain.Positions;

public interface IGetPositionByCodeQuery
{
    public Task<Position> Get(string positionCode);
}
