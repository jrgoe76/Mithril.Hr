namespace Mithril.Hr.Domain.Positions;

public record Position
{
    public string PositionCode { get; init; }
    public string Name { get; private set; }
    public byte SubordinatesLimit { get; private set; }

    public Position(
        string code,
        string name,
        byte subordinatesLimit)
    {
        const string errorMessage = $"The {nameof(Position)} is invalid";

        if (string.IsNullOrEmpty(code))
        {
            throw new ArgumentException(errorMessage, nameof(code));
        }
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException(errorMessage, nameof(name));
        }

        PositionCode = code;
        Name = name;
        SubordinatesLimit = subordinatesLimit;
    }

    public override string ToString()
        => Name;
}
