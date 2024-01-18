using Microsoft.EntityFrameworkCore;
using Mithril.Hr.Domain.Employees;
using Mithril.Hr.Persistence.Data;

namespace Mithril.Hr.Persistence.Entities.Employees;

internal sealed class GetEmployeeByIdQuery(
    DataContext dbContext,
    EmployeeMapper employeeMapper) : IGetEmployeeByIdQuery
{
    public async Task<Employee> Get(Guid employeeId)
	    => employeeMapper.Map(
		    await dbContext.Employees
				.SingleAsync(employee => employee.EmployeeId == employeeId));
}
