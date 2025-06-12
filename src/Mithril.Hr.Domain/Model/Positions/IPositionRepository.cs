namespace Mithril.Hr.Domain.Model.Positions;

public interface IPositionRepository
{
    public Task Add(Position position);
}