namespace Mithril.Hr.Domain.Employees;

public interface IGetEmployeeByIdQuery
{
    public Task<Employee> Get(Guid employeeId);
}
