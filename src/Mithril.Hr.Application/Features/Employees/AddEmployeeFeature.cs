﻿using Mithril.Hr.Domain.Model;
using Mithril.Hr.Domain.Model.Demographics;
using Mithril.Hr.Domain.Model.Education;
using Mithril.Hr.Domain.Model.Employees;

namespace Mithril.Hr.Application.Features.Employees;

public sealed class AddEmployeeFeature(
    IIdGenerator idGenerator,
    IEmployeeRepository employeeRepository,
    EmployeeInfoMapper employeeInfoMapper)
{
    public async Task<EmployeeInfo> Add(AddEmployeeInfo addEmployeeInfo)
    {
        Guid employeeId = idGenerator.New();

        Employee employee = new(employeeId,
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