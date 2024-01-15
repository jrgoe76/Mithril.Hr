namespace Mithril.Hr.Application.Features.Employees;

public interface IUpdateEmployeeFeature
{
    public Task<EmployeeInfo> Update(UpdateEmployeeInfo updateEmployeeInfo);
}
