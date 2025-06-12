using Microsoft.EntityFrameworkCore;
using Mithril.Hr.Domain.Model.Employees;
using Mithril.Hr.Infrastructure.Persistence.Model.Demographics;
using Mithril.Hr.Infrastructure.Persistence.Model.Education;

namespace Mithril.Hr.Infrastructure.Persistence.Model.Employees;

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