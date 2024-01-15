namespace Mithril.Hr.Domain.Demographics;

public record Gender
{
    public static Gender Male { get; } = new(nameof(Values.Male));
    public static Gender Female { get; } = new(nameof(Values.Female));

    internal enum Values { Male, Female }
    internal Values Value { get; init; }

    public Gender(string gender)
    {
        if (IsNotValid(gender, out var value))
        {
            throw new ArgumentException($"The {nameof(Gender)} is invalid", nameof(gender));
        }

        Value = value;
    }

    public override string ToString()
        => Value.ToString();

    private static bool IsNotValid(string gender, out Values value)
        => !Enum.TryParse(gender, true, out value);
}
