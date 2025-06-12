using Mithril.Hr.Domain.Model.Positions;

namespace Mithril.Hr.Infrastructure.Persistence.Model.Positions;

public record PositionEf
{
    public string PositionCode { get; set; } = null!;
    public string Name { get; set; } = null!;

    public Guid Version { get; set; }

    internal PositionEf() { }

    public PositionEf(
        Position position,
        Guid version)
    {
        PositionCode = position.PositionCode;
        SetFields(position, version);
    }

    public PositionEf Update(
        Position position,
        Guid version)
    {
        SetFields(position, version);

        return this;
    }

    private void SetFields(
        Position position,
        Guid version)
    {
        Name = position.Name;
        Version = version;
    }
}