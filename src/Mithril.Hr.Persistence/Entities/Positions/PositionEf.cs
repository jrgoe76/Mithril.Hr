using Mithril.Hr.Domain.Positions;

namespace Mithril.Hr.Persistence.Entities.Positions;

public record PositionEf
{
	public string PositionCode { get; set; } = null!;
	public string Name { get; set; } = null!;

	public Guid Version { get; set; }

	public PositionEf Update(Position position, Guid version)
	{
		PositionCode = position.PositionCode;
		Name = position.Name;
		Version = version;

		return this;
	}
}