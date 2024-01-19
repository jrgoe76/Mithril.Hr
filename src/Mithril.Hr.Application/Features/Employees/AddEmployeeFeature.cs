using Mithril.Hr.Domain;
using Mithril.Hr.Domain.Demographics;
using Mithril.Hr.Domain.Education;
using Mithril.Hr.Domain.Employees;

namespace Mithril.Hr.Application.Features.Employees;

public sealed class AddEmployeeFeature(
    IIdGenerator idGenerator,
    IEmployeeRepository employeeRepository,
    EmployeeInfoMapper employeeInfoMapper)
{
    public async Task<EmployeeInfo> Add(AddEmployeeInfo addEmployeeInfo)
    {
        var employeeId = idGenerator.New();

        var employee = new Employee(employeeId,
			new PersonName(addEmployeeInfo.FirstName, addEmployeeInfo.MiddleInitial, addEmployeeInfo.LastName),
			new Gender(addEmployeeInfo.Gender),
			new Email(addEmployeeInfo.EmailAddress),
			new Address(addEmployeeInfo.AddressLine1, addEmployeeInfo.AddressLine2,
			    addEmployeeInfo.City, addEmployeeInfo.State, addEmployeeInfo.Zipcode),
			new AcademicDegree(addEmployeeInfo.Degree));

        await employeeRepository.Add(employee);

        return employeeInfoMapper.Map(employee);
    }
}
