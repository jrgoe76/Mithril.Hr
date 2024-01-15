using Mithril.Hr.Domain.Employees;

namespace Mithril.Hr.Application.Features.Employees;

internal class GetEmployeeByIdFeature(
    IGetEmployeeByIdQuery getEmployeeByIdQuery,
    EmployeeToEmployeeInfoMapper employeeToEmployeeInfoMapper) : IGetEmployeeByIdFeature
{
    public async Task<EmployeeInfo> Get(Guid employeeId)
        => employeeToEmployeeInfoMapper
            .Map(await getEmployeeByIdQuery.Get(employeeId));
}
