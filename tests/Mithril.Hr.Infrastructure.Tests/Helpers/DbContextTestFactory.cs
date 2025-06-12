using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Mithril.Hr.Infrastructure.Persistence.Model;

namespace Mithril.Hr.Infrastructure.Tests.Helpers;

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

        var dbContext = new DataContextSpy(options);

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
