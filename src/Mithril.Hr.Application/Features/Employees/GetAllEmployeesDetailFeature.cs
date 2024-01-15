using System.Diagnostics.CodeAnalysis;

namespace Mithril.Hr.Application.Features.Employees;

[ExcludeFromCodeCoverage]
internal sealed class GetAllEmployeesDetailFeature(
    IGetAllEmployeesDetailQuery getAllEmployeesDetailQuery) : IGetAllEmployeesDetailFeature
{
    public Task<ICollection<EmployeeDetail>> Get()
        => getAllEmployeesDetailQuery.Get();
}