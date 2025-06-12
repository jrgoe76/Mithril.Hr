namespace Mithril.Hr.Domain.Model.Demographics;

public record PersonName
{
    public string FirstName { get; init; }
    public string? MiddleInitial { get; init; }
    public string LastName { get; init; }

    public PersonName(
        string firstName,
        string? middleInitial,
        string lastName)
    {
        const string errorMessage = "The Person Name is invalid";

        if (string.IsNullOrEmpty(firstName))
        {
            throw new ArgumentException(errorMessage, nameof(firstName));
        }
        if (string.IsNullOrEmpty(lastName))
        {
            throw new ArgumentException(errorMessage, nameof(lastName));
        }

        FirstName = firstName;
        MiddleInitial = middleInitial;
        LastName = lastName;
    }

    public PersonName(
        string firstName,
        string lastName)
        : this(firstName, null, lastName)
    {
    }

    public override string ToString()
    {
        var middleInitial = !string.IsNullOrEmpty(MiddleInitial)
            ? $" {MiddleInitial}."
            : string.Empty;

        return $"{FirstName}{middleInitial} {LastName}";
    }
}
