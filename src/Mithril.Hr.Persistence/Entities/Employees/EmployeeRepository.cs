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
        var employeeEntity = new EmployeeEntity();

        employeeEntity.Update(employee, genderMapper, academicDegreeMapper);
        employeeEntity.Version = Guid.NewGuid();

        await dbContext.Employees.AddAsync(employeeEntity);
        await dbContext.SaveChangesAsync();
    }

    public async Task Update(Employee employee)
    {
	    var employeeEntity = await dbContext.Employees
		    .SingleAsync(entity => entity.EmployeeId == employee.EmployeeId);

	    employeeEntity.Update(employee, genderMapper, academicDegreeMapper);
	    employeeEntity.Version = Guid.NewGuid();

        dbContext.Attach(employeeEntity);
        await dbContext.SaveChangesAsync();
    }
}
