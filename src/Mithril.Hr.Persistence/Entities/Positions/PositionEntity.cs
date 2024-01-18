namespace Mithril.Hr.Persistence.Entities.Positions;

public record PositionEntity
{
	public string PositionCode { get; set; } = null!;
	public string Name { get; set; } = null!;
}