using Mithril.Hr.Domain.Employees;
using Mithril.Hr.Domain.Positions;

namespace Mithril.Hr.Application.Features.Employees;

public sealed class AssignContractToEmployeeFeature(
    IGetEmployeeByIdQuery getEmployeeByIdQuery,
    IGetPositionByCodeQuery getPositionByCodeQuery,
    IEmployeeRepository employeeRepository,
    EmployeeToEmployeeInfoMapper employeeToEmployeeInfoMapper)
{
    public async Task<EmployeeInfo> Assign(AssignContractInfo assignContractInfo)
    {
        var employee = await getEmployeeByIdQuery.Get(assignContractInfo.EmployeeId);
        var position = await getPositionByCodeQuery.Get(assignContractInfo.PositionCode);

        employee.AssignContract(position, assignContractInfo.SupervisorId, assignContractInfo.StartDate);

        await employeeRepository.Update(employee);

        return employeeToEmployeeInfoMapper.Map(employee);
    }
}
