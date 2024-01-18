using Microsoft.EntityFrameworkCore;
using Mithril.Hr.Persistence.Data;

namespace Mithril.Hr.Persistence.Tests.Helpers;

internal sealed class DataContextSpy(
    DbContextOptions<DataContext> options) : DataContext(options)
{
    public bool ChangesAreSaved { get; private set; }

    public override Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = new())
    {
        ChangesAreSaved = true;

        return base.SaveChangesAsync(cancellationToken);
    }

    public void ResetStates()
    {
        ChangesAreSaved = false;
    }
}
