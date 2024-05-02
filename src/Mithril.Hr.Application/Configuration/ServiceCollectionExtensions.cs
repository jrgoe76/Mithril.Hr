using Microsoft.Extensions.DependencyInjection;
using Mithril.Hr.Application.Features.Employees;
using Mithril.Hr.Application.Features.Positions;

namespace Mithril.Hr.Application.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
        => services
	        .AddScoped<AddPositionFeature>()

            .AddSingleton<EmployeeInfoMapper>()
            .AddScoped<GetAllEmployeesDetailFeature>()
            .AddScoped<GetEmployeeByIdFeature>()
            .AddScoped<AddEmployeeFeature>()
            .AddScoped<UpdateEmployeeFeature>()
	        .AddScoped<AssignContractToEmployeeFeature>();
}
