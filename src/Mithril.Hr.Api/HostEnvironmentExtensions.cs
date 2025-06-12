namespace Mithril.Hr.Api;

public static class HostEnvironmentExtensions
{
    public static string Testing = "Testing";

    public static bool IsTesting(this IHostEnvironment environment)
        => environment.EnvironmentName == Testing;
}