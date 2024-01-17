using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mithril.Hr.Persistence.Configuration;
using Mithril.Hr.Persistence.Data;

namespace Mithril.Hr.Persistence.Tests.Helpers;

internal sealed class DbContextTestFactory : IDisposable
{
    private readonly SqliteConnection _dbConnection
        = GetInitializedDbConnection();

    public static DbContextTestFactory New()
        => new ();

    public DataContextSpy Create()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseSqlite(_dbConnection)
            .Options;
        var serviceProvider = new ServiceCollection()
            .AddPersistenceConfiguration()
            .BuildServiceProvider();

        var dbContext = new DataContextSpy(options, serviceProvider);

        dbContext.Database
            .EnsureCreated();

        return dbContext;
    }

    public void Dispose()
    {
        DisposeDbConnection(_dbConnection);
    }

    private static SqliteConnection GetInitializedDbConnection()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();

        return connection;
    }

    private static void DisposeDbConnection(SqliteConnection connection)
    {
        connection.Close();
        connection.Dispose();
    }
}
