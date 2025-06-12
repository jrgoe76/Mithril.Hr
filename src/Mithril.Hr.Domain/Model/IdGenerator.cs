using System.Diagnostics.CodeAnalysis;

namespace Mithril.Hr.Domain.Model;

[ExcludeFromCodeCoverage]
internal sealed class IdGenerator : IIdGenerator
{
    public Guid New()
        => Guid.NewGuid();
}