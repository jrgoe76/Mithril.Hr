using System.Diagnostics.CodeAnalysis;

namespace Mithril.Hr.Application.Features.Employees;

[ExcludeFromCodeCoverage]
public sealed record UpdateEmployeeInfo(
    Guid EmployeeId,
    string FirstName,
    string? MiddleInitial,
    string LastName,
    string Gender,
    string EmailAddress,
    string AddressLine1,
    string? AddressLine2,
    string City,
    string State,
    string Zipcode,
    string Degree);