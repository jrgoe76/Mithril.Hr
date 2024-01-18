using System.Data.Common;
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

	public static IServiceCollection AddPersistence(
        this IServiceCollection services)
        => services
	        .AddSingleton<GenderMapper>()
	        .AddSingleton<AcademicDegreeMapper>()

	        .AddScoped<PositionConfiguration>()
	        .AddSingleton<PositionMapper>()
	        .AddScoped<IGetPositionByCodeQuery, GetPositionByCodeQuery>()

            .AddScoped<EmployeeConfiguration>()
	        .AddSingleton<EmployeeMapper>()
            .AddScoped<IGetAllEmployeesDetailQuery, GetAllEmployeesDetailQuery>()
            .AddScoped<IGetEmployeeByIdQuery, GetEmployeeByIdQuery>()
            .AddScoped<IEmployeeRepository, EmployeeRepository>()

	        .AddScoped<ContractConfiguration>();

    private static SqliteConnection CreateInitializedDbConnection()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();

        return connection;
    }
}
