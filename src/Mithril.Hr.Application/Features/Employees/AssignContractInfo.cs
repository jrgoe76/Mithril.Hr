using System.Diagnostics.CodeAnalysis;

namespace Mithril.Hr.Application.Features.Employees;

[ExcludeFromCodeCoverage]
public sealed record AssignContractInfo(
    Guid EmployeeId,
    string PositionCode,
    Guid SupervisorId,
    DateOnly StartDate);