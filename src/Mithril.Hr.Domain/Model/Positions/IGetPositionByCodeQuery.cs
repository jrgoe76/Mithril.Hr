namespace Mithril.Hr.Domain.Model.Positions;

public interface IGetPositionByCodeQuery
{
    public Task<Position> Get(string positionCode);
}
