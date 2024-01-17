using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mithril.Hr.Application.Features.Employees;
using Mithril.Hr.Domain.Employees;
using Mithril.Hr.Domain.Positions;
using Mithril.Hr.Persistence.Data;
using Mithril.Hr.Persistence.Entities.Demographics;
using Mithril.Hr.Persistence.Entities.Education;
using Mithril.Hr.Persistence.Entities.Employees;
using Mithril.Hr.Persistence.Entities.Positions;
using Mithril.Hr.Persistence.Seeds;
using System.Data.Common;

namespace Mithril.Hr.Persistence.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistenceDbContext(
        this IServiceCollection services)
        => services
            .AddScoped<DbSeeder>()
            .AddSingleton<DbConnection>(_ => CreateInitializedDbConnection())
            .AddDbContext<DataContext>(
                (provider, options) => options.UseSqlite(provider.GetRequiredService<DbConnection>()));

    public static IServiceCollection AddPersistenceConfiguration(
        this IServiceCollection services)
        => services
            .AddSingleton<GenderMapper>()
            .AddScoped<GenderConverter>()
            .AddSingleton<AcademicDegreeMapper>()
            .AddScoped<AcademicDegreeConverter>()

            .AddScoped<EmployeeConfiguration>()
            .AddScoped<PositionConfiguration>();
    
    public static IServiceCollection AddPersistence(
        this IServiceCollection services)
        => services
            .AddPersistenceConfiguration()

            .AddScoped<IGetPositionByCodeQuery, GetPositionByCodeQuery>()

            .AddSingleton<IEmployeeCtr, EmployeeCtr>()
            .AddScoped<IGetAllEmployeesDetailQuery, GetAllEmployeesDetailQuery>()
            .AddScoped<IGetEmployeeByIdQuery, GetEmployeeByIdQuery>()
            .AddScoped<IEmployeeRepository, EmployeeRepository>();

    private static SqliteConnection CreateInitializedDbConnection()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();

        return connection;
    }
}
