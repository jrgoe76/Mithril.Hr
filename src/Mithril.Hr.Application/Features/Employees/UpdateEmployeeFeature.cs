using Mithril.Hr.Domain.Demographics;
using Mithril.Hr.Domain.Education;
using Mithril.Hr.Domain.Employees;

namespace Mithril.Hr.Application.Features.Employees;

public sealed class UpdateEmployeeFeature(
    IGetEmployeeByIdQuery getEmployeeByIdQuery,
    IEmployeeRepository employeeRepository,
    EmployeeToEmployeeInfoMapper employeeToEmployeeInfoMapper)
{
    public async Task<EmployeeInfo> Update(UpdateEmployeeInfo updateEmployeeInfo)
    {
        var employee = await getEmployeeByIdQuery.Get(updateEmployeeInfo.EmployeeId);

        employee.Update(
            new PersonName(updateEmployeeInfo.FirstName,
                updateEmployeeInfo.MiddleInitial, updateEmployeeInfo.LastName),
            new Gender(updateEmployeeInfo.Gender),
            new Email(updateEmployeeInfo.EmailAddress),
            new Address(updateEmployeeInfo.AddressLine1, updateEmployeeInfo.AddressLine2,
                updateEmployeeInfo.City, updateEmployeeInfo.State, updateEmployeeInfo.Zipcode),
            new AcademicDegree(updateEmployeeInfo.Degree));

        await employeeRepository.Update(employee);

        return employeeToEmployeeInfoMapper.Map(employee);
    }
}
