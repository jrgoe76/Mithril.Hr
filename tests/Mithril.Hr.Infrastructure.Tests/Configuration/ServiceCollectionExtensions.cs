﻿using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mithril.Hr.Infrastructure.Persistence.Model;

namespace Mithril.Hr.Infrastructure.Tests.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistenceTestDbContext(
        this IServiceCollection services)
        => services
            .AddSingleton<DbConnection>(_ => CreateInitializedDbConnection())
            .AddDbContext<DataContext>(
                (provider, options) => options.UseSqlite(provider.GetRequiredService<DbConnection>()));

    private static SqliteConnection CreateInitializedDbConnection()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();

        return connection;
    }
}