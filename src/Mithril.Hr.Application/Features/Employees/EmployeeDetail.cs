using System.Diagnostics.CodeAnalysis;

namespace Mithril.Hr.Application.Features.Employees;

[ExcludeFromCodeCoverage]
public sealed record EmployeeDetail(
    Guid EmployeeId,
    string FirstName,
    string? MiddleInitial,
    string LastName);