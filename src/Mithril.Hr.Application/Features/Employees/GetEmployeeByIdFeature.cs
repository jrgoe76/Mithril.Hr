using Mithril.Hr.Domain.Employees;

namespace Mithril.Hr.Application.Features.Employees;

public sealed class GetEmployeeByIdFeature(
    IGetEmployeeByIdQuery getEmployeeByIdQuery,
    EmployeeToEmployeeInfoMapper employeeToEmployeeInfoMapper)
{
    public async Task<EmployeeInfo> Get(Guid employeeId)
        => employeeToEmployeeInfoMapper
            .Map(await getEmployeeByIdQuery.Get(employeeId));
}
