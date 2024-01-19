using System.Diagnostics.CodeAnalysis;

namespace Mithril.Hr.Application.Features.Employees;

[ExcludeFromCodeCoverage]
public sealed record ContractInfo(
    string PositionCode,
    Guid? SupervisorId,
    DateOnly StartedOn,
    DateOnly? EndedOn);