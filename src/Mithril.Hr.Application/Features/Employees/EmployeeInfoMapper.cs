﻿using Mithril.Hr.Domain.Model.Employees;

namespace Mithril.Hr.Application.Features.Employees;

public sealed class EmployeeInfoMapper
{
    public EmployeeInfo Map(Employee employee)
        => new(
            employee.EmployeeId,
            employee.Name.FirstName, employee.Name.MiddleInitial, employee.Name.LastName,
            employee.Gender.ToString(),
            employee.Email.Address, employee.Address.AddressLine1, employee.Address.AddressLine2,
            employee.Address.City, employee.Address.State,
            employee.Address.Zipcode,
            employee.Degree.ToString(),
            MapContract(employee.Contract));

    private ContractInfo? MapContract(Contract? contract)
        => contract != null
            ? new ContractInfo(
                contract.Position.PositionCode,
                contract.SupervisorId,
                contract.StartedOn,
                contract.EndedOn)
            : null;
}