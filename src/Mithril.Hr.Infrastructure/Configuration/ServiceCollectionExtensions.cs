using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mithril.Hr.Application.Features.Employees;
using Mithril.Hr.Domain.Model.Employees;
using Mithril.Hr.Domain.Model.Positions;
using Mithril.Hr.Infrastructure.Persistence.Model;
using Mithril.Hr.Infrastructure.Persistence.Model.Demographics;
using Mithril.Hr.Infrastructure.Persistence.Model.Education;
using Mithril.Hr.Infrastructure.Persistence.Model.Employees;
using Mithril.Hr.Infrastructure.Persistence.Model.Positions;
using Mithril.Hr.Infrastructure.Persistence.Seeds;

namespace Mithril.Hr.Infrastructure.Configuration;

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
	        .AddScoped<IPositionRepository, PositionRepository>()

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
