namespace Mithril.Hr.Application.Features.Employees;

public interface IGetAllEmployeesDetailQuery
{
    public Task<ICollection<EmployeeDetail>> Get();
}
