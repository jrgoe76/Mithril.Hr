using Mithril.Hr.Domain.Demographics;

namespace Mithril.Hr.Persistence.Entities.Demographics;

public sealed class GenderMapper
{
    internal enum Codes
    {
        Male = 'M',
        Female = 'F'
    }

    public Gender Map(char code)
	    => new(GetGender(code));

    public char MapCode(Gender gender)
        => GetCode(gender);

    private static char GetCode(Gender gender)
    {
        Enum.TryParse(gender.ToString(), true, out Codes code);

        return (char)code;
    }

    private static string GetGender(char code)
    {
        Enum.TryParse(((Codes)code).ToString(), true, out Gender.Values gender);

        return gender.ToString();
    }
}
