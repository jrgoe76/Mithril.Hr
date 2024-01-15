namespace Mithril.Hr.Application.Features.Employees;

public interface IGetAllEmployeesDetailFeature
{
    public Task<ICollection<EmployeeDetail>> Get();
}
