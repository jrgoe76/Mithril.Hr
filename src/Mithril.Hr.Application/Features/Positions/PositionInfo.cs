using System.Diagnostics.CodeAnalysis;

namespace Mithril.Hr.Application.Features.Positions;

[ExcludeFromCodeCoverage]
public record PositionInfo(
    string PositionCode,
    string Name);