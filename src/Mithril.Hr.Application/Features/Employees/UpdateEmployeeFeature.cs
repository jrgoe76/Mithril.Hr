using Mithril.Hr.Domain.Model.Demographics;
using Mithril.Hr.Domain.Model.Education;
using Mithril.Hr.Domain.Model.Employees;

namespace Mithril.Hr.Application.Features.Employees;

public sealed class UpdateEmployeeFeature(
    IGetEmployeeByIdQuery getEmployeeByIdQuery,
    IEmployeeRepository employeeRepository,
    EmployeeInfoMapper employeeInfoMapper)
{
    public async Task<EmployeeInfo> Update(UpdateEmployeeInfo updateEmployeeInfo)
    {
        Employee employee = await getEmployeeByIdQuery.Get(updateEmployeeInfo.EmployeeId);

        employee.Update(
            new PersonName(updateEmployeeInfo.FirstName,
                updateEmployeeInfo.MiddleInitial, updateEmployeeInfo.LastName),
            new Gender(updateEmployeeInfo.Gender),
            new Email(updateEmployeeInfo.EmailAddress),
            new Address(updateEmployeeInfo.AddressLine1, updateEmployeeInfo.AddressLine2,
                updateEmployeeInfo.City, updateEmployeeInfo.State, updateEmployeeInfo.Zipcode),
            new AcademicDegree(updateEmployeeInfo.Degree));

        await employeeRepository.Update(employee);

        return employeeInfoMapper.Map(employee);
    }
}