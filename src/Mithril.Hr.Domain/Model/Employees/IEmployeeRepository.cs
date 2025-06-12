namespace Mithril.Hr.Domain.Model.Employees;

public interface IEmployeeRepository
{
    public Task Add(Employee employee);
    public Task Update(Employee employee);
}
