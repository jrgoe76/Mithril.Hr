using Mithril.Hr.Domain.Employees;

namespace Mithril.Hr.Application.Features.Employees;

public sealed class GetEmployeeByIdFeature(
    IGetEmployeeByIdQuery getEmployeeByIdQuery,
    EmployeeInfoMapper employeeInfoMapper)
{
    public async Task<EmployeeInfo> Get(Guid employeeId)
        => employeeInfoMapper
            .Map(await getEmployeeByIdQuery.Get(employeeId));
}
