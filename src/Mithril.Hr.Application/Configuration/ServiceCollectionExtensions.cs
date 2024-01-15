using Microsoft.Extensions.DependencyInjection;
using Mithril.Hr.Application.Features.Employees;

namespace Mithril.Hr.Application.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
        => services
            .AddSingleton<EmployeeToEmployeeInfoMapper>()
            .AddScoped<IGetAllEmployeesDetailFeature, GetAllEmployeesDetailFeature>()
            .AddScoped<IGetEmployeeByIdFeature, GetEmployeeByIdFeature>()
            .AddScoped<IAddEmployeeFeature, AddEmployeeFeature>()
            .AddScoped<IUpdateEmployeeFeature, UpdateEmployeeFeature>();
}
