using Microsoft.EntityFrameworkCore;
using Mithril.Hr.Domain.Employees;
using Mithril.Hr.Persistence.Data;
using Mithril.Hr.Persistence.Entities.Demographics;
using Mithril.Hr.Persistence.Entities.Education;

namespace Mithril.Hr.Persistence.Entities.Employees;

internal sealed class EmployeeRepository(
    DataContext dbContext,
    GenderMapper genderMapper,
    AcademicDegreeMapper academicDegreeMapper) : IEmployeeRepository
{
    public async Task Add(Employee employee)
    {
        var employeeEf = new EmployeeEf();

        employeeEf.Update(employee, genderMapper, academicDegreeMapper, Guid.NewGuid());

        await dbContext.Employees.AddAsync(employeeEf);
        await dbContext.SaveChangesAsync();
    }

    public async Task Update(Employee employee)
    {
	    var employeeEf = await dbContext.Employees
		    .SingleAsync(entity => entity.EmployeeId == employee.EmployeeId);

	    employeeEf.Update(employee, genderMapper, academicDegreeMapper, Guid.NewGuid());

        dbContext.Attach(employeeEf);
        await dbContext.SaveChangesAsync();
    }
}
