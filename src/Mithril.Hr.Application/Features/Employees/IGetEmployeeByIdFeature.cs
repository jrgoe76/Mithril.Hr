namespace Mithril.Hr.Application.Features.Employees;

public interface IGetEmployeeByIdFeature
{
    public Task<EmployeeInfo> Get(Guid employeeId);
}
