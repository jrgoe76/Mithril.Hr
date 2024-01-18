using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Mithril.Hr.Domain;

namespace Mithril.Hr.Configuration;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(
        this IServiceCollection services)
        => services
            .AddSingleton<IIdGenerator, IdGenerator>();
}
