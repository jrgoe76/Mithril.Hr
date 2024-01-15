using Microsoft.Extensions.DependencyInjection;
using Mithril.Hr.Domain;
using System.Diagnostics.CodeAnalysis;

namespace Mithril.Hr.Configuration;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(
        this IServiceCollection services)
        => services
            .AddSingleton<IIdGenerator, IdGenerator>();
}
