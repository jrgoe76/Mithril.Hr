using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Mithril.Hr.Persistence.Data;
using Mithril.Hr.Persistence.Entities.Demographics;
using Mithril.Hr.Persistence.Entities.Education;
using Moq;

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
        var serviceProvider = GetServiceProvider();

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

    private static IServiceProvider GetServiceProvider()
    {
        var serviceProvider = new Mock<IServiceProvider>();

        serviceProvider
            .Setup(provider => provider.GetService(typeof(GenderMapper)))
            .Returns(new GenderMapper());
        serviceProvider
            .Setup(provider => provider.GetService(typeof(AcademicDegreeMapper)))
            .Returns(new AcademicDegreeMapper());

        return serviceProvider.Object;
    }
}
