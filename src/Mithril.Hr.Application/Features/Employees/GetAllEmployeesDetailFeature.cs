using System.Diagnostics.CodeAnalysis;

namespace Mithril.Hr.Application.Features.Employees;

[ExcludeFromCodeCoverage]
public sealed class GetAllEmployeesDetailFeature(
    IGetAllEmployeesDetailQuery getAllEmployeesDetailQuery)
{
    public Task<ICollection<EmployeeDetail>> Get()
        => getAllEmployeesDetailQuery.Get();
}