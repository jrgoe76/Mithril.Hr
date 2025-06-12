namespace Mithril.Hr.Domain.Model.Demographics;

public sealed record Address
{
    public string AddressLine1 { get; init; }
    public string? AddressLine2 { get; init; }
    public string City { get; init; }
    public string State { get; init; }
    public string Zipcode { get; init; }

    public Address(
        string addressLine1,
        string? addressLine2,
        string city,
        string state,
        string zipcode)
    {
        const string errorMessage = $"The {nameof(Address)} is invalid";

        if (string.IsNullOrEmpty(addressLine1))
        {
            throw new ArgumentException(errorMessage, nameof(addressLine1));
        }

        if (string.IsNullOrEmpty(city))
        {
            throw new ArgumentException(errorMessage, nameof(city));
        }

        if (string.IsNullOrEmpty(state))
        {
            throw new ArgumentException(errorMessage, nameof(state));
        }

        if (string.IsNullOrEmpty(zipcode))
        {
            throw new ArgumentException(errorMessage, nameof(zipcode));
        }

        AddressLine1 = addressLine1;
        AddressLine2 = addressLine2;
        City = city;
        State = state;
        Zipcode = zipcode;
    }

    public Address(
        string addressLine1,
        string city,
        string state,
        string zipcode)
        : this(addressLine1, null, city, state, zipcode)
    {
    }

    public override string ToString()
    {
        var addressLine2 = !string.IsNullOrEmpty(AddressLine2)
            ? " " + AddressLine2
            : string.Empty;

        return $"{AddressLine1}{addressLine2}, {City}, {State} {Zipcode}";
    }
}