using Microsoft.AspNetCore.Mvc;
using Mithril.Hr.Application.Features.Employees;

namespace Mithril.Hr.Api.Controllers;

[ApiController]
[Route("employees")]
public sealed class EmployeesController(
    GetAllEmployeesDetailFeature getAllEmployeesDetailFeature,
    GetEmployeeByIdFeature getEmployeeByIdFeature,
    AddEmployeeFeature addEmployeeFeature,
    UpdateEmployeeFeature updateEmployeeFeature) : ControllerBase
{
    [HttpGet]
    public Task<ICollection<EmployeeDetail>> GetAll()
        => getAllEmployeesDetailFeature.Get();

    [HttpGet("{employeeId}")]
    public Task<EmployeeInfo> GetById(Guid employeeId)
        => getEmployeeByIdFeature.Get(employeeId);

    [HttpPost]
    public Task<EmployeeInfo> Add(AddEmployeeInfo addEmployeeInfo)
        => addEmployeeFeature.Add(addEmployeeInfo);

    [HttpPut]
    public Task<EmployeeInfo> Update(UpdateEmployeeInfo updateEmployeeInfo)
        => updateEmployeeFeature.Update(updateEmployeeInfo);
}
