namespace Mithril.Hr.Domain.Model.Employees;

public interface IGetEmployeeByIdQuery
{
    public Task<Employee> Get(Guid employeeId);
}