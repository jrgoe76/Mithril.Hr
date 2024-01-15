namespace Mithril.Hr.Domain.Positions;

public interface IGetPositionByPositionCodeQuery
{
    public Task<Position> Get(string positionCode);
}
