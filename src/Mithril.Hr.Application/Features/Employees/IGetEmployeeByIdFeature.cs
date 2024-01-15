namespace Mithril.Hr.Application.Features.Employees;

internal interface IGetEmployeeByIdFeature
{
    public Task<EmployeeInfo> Get(Guid employeeId);
}
