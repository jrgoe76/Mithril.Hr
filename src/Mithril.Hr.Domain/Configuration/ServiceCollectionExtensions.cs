using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Mithril.Hr.Domain.Model;

namespace Mithril.Hr.Domain.Configuration;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(
        this IServiceCollection services)
        => services
            .AddSingleton<IIdGenerator, IdGenerator>();
}