using System.Diagnostics.CodeAnalysis;

namespace Mithril.Hr.Domain;

[ExcludeFromCodeCoverage]
internal sealed class IdGenerator : IIdGenerator
{
    public Guid New()
        => Guid.NewGuid();
}
