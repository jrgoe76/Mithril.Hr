using Mithril.Hr.Domain.Model.Employees;
using Mithril.Hr.Domain.Model.Positions;

namespace Mithril.Hr.Application.Features.Employees;

public sealed class AssignContractToEmployeeFeature(
    IGetEmployeeByIdQuery getEmployeeByIdQuery,
    IGetPositionByCodeQuery getPositionByCodeQuery,
    IEmployeeRepository employeeRepository,
    EmployeeInfoMapper employeeInfoMapper)
{
    public async Task<EmployeeInfo> Assign(AssignContractInfo assignContractInfo)
    {
        Employee employee = await getEmployeeByIdQuery.Get(assignContractInfo.EmployeeId);
        Position position = await getPositionByCodeQuery.Get(assignContractInfo.PositionCode);

        employee.AssignContract(position, assignContractInfo.SupervisorId, assignContractInfo.StartDate);

        await employeeRepository.Update(employee);

        return employeeInfoMapper.Map(employee);
    }
}