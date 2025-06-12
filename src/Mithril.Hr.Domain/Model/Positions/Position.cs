namespace Mithril.Hr.Domain.Model.Positions;

public sealed record Position
{
    public string PositionCode { get; init; }
    public string Name { get; init; }

    public Position(
        string positionCode,
        string name)
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
    }

    public override string ToString()
        => Name;
}