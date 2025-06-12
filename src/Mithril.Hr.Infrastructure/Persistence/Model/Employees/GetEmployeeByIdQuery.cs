using Microsoft.EntityFrameworkCore;
using Mithril.Hr.Domain.Model.Employees;

namespace Mithril.Hr.Infrastructure.Persistence.Model.Employees;

internal sealed class GetEmployeeByIdQuery(
    DataContext dbContext,
    EmployeeMapper employeeMapper) : IGetEmployeeByIdQuery
{
    public async Task<Employee> Get(Guid employeeId)
        => employeeMapper.Map(
            await dbContext.Employees
                .SingleAsync(employee => employee.EmployeeId == employeeId));
}