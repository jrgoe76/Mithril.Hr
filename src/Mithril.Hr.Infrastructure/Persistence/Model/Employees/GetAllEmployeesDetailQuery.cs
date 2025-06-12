using Microsoft.EntityFrameworkCore;
using Mithril.Hr.Application.Features.Employees;

namespace Mithril.Hr.Infrastructure.Persistence.Model.Employees;

internal sealed class GetAllEmployeesDetailQuery(
    DataContext dbContext) : IGetAllEmployeesDetailQuery
{
    public async Task<ICollection<EmployeeDetail>> Get()
	    => await dbContext.Employees
			.Select(employee => new EmployeeDetail(
				employee.EmployeeId,
				employee.FirstName,
				employee.MiddleInitial,
				employee.LastName))
			.ToListAsync();
}
