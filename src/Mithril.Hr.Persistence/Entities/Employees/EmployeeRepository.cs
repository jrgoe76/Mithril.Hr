using Mithril.Hr.Domain.Employees;
using Mithril.Hr.Persistence.Data;

namespace Mithril.Hr.Persistence.Entities.Employees;

internal sealed class EmployeeRepository(
    DataContext dbContext) : IEmployeeRepository
{
    public async Task Add(Employee employee)
    {
        var entity = (EmployeeEntity)employee;
        entity.Version = Guid.NewGuid();

        await dbContext.Employees.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task Update(Employee employee)
    {
        var entity = (EmployeeEntity)employee;
        entity.Version = Guid.NewGuid();

        await dbContext.SaveChangesAsync();
    }
}
