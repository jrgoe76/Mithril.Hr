namespace Mithril.Hr.Application.Features.Employees;

public interface IAddEmployeeFeature
{
    public Task<EmployeeInfo> Add(AddEmployeeInfo addEmployeeInfo);
}
