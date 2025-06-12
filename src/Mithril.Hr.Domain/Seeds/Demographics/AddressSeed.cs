using Mithril.Hr.Domain.Model.Demographics;

namespace Mithril.Hr.Domain.Seeds.Demographics;

public static class AddressSeed
{
    public static Address MainSt = new("123 Main St", "Miami", "FL", "12345");
    public static Address MadisonAve = new("374 Madison Ave", "Apt 32", "York", "PA", "43848");
    public static Address BeachSt = new("645 Beach St", "Apt 2003", "St Petersburg", "FL", "37475");
    public static Address BeckPl = new("67 Beck Pl", "Jacksonville", "FL", "24367");
}