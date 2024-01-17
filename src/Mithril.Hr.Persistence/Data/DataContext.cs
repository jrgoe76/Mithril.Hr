using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mithril.Hr.Domain.Positions;
using Mithril.Hr.Persistence.Entities.Employees;
using Mithril.Hr.Persistence.Entities.Positions;
using System.Diagnostics.CodeAnalysis;

namespace Mithril.Hr.Persistence.Data;

[ExcludeFromCodeCoverage]
public class DataContext(
    DbContextOptions<DataContext> options,
    IServiceProvider serviceProvider) : DbContext(options)
{
    public DbSet<Position> Positions { get; set; } = null!;
    public DbSet<EmployeeEntity> Employees { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(GetService<PositionConfiguration>());
        modelBuilder.ApplyConfiguration(GetService<EmployeeConfiguration>());
        modelBuilder.ApplyConfiguration(GetService<ContractConfiguration>());
    }

    private T GetService<T>()
        where T : class
        => serviceProvider.GetRequiredService<T>();
}
