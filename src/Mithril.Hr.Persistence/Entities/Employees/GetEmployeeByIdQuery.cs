using Microsoft.EntityFrameworkCore;
using Mithril.Hr.Domain.Employees;
using Mithril.Hr.Persistence.Data;

namespace Mithril.Hr.Persistence.Entities.Employees;

internal sealed class GetEmployeeByIdQuery(
    DataContext dbContext) : IGetEmployeeByIdQuery
{
    public async Task<Employee> Get(Guid employeeId)
        => await dbContext.Employees
            .Include(employee => employee.Position)
            .SingleAsync(employee => employee.EmployeeId == employeeId);
}
