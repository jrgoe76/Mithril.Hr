namespace Mithril.Hr.Domain.Employees;

public interface IEmployeeRepository
{
    public Task Add(Employee employee);
    public Task Update(Employee employee);
}
