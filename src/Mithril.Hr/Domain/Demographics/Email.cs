using System.Text.RegularExpressions;

namespace Mithril.Hr.Domain.Demographics;

public record Email
{
    public string Address { get; init; }

    public Email(string address)
    {
        if (IsNotValid(address))
        {
            throw new ArgumentException($"The {nameof(Email)} is invalid", nameof(address));
        }

        Address = address;
    }

    public override string ToString()
        => Address;

    private static bool IsNotValid(string address)
    {
        var match = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
            .Match(address);

        return !match.Success;
    }
}
