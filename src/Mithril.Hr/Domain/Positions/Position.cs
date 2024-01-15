namespace Mithril.Hr.Domain.Positions;

public record Position
{
    public string PositionCode { get; init; }
    public string Name { get; init; }
    public byte SubordinatesLimit { get; init; }

    public Position(
        string positionCode,
        string name,
        byte subordinatesLimit)
    {
        const string errorMessage = $"The {nameof(Position)} is invalid";

        if (string.IsNullOrEmpty(positionCode))
        {
            throw new ArgumentException(errorMessage, nameof(positionCode));
        }
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException(errorMessage, nameof(name));
        }

        PositionCode = positionCode;
        Name = name;
        SubordinatesLimit = subordinatesLimit;
    }

    public override string ToString()
        => Name;
}
