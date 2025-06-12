using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Mithril.Hr.Infrastructure.Persistence.Model.Employees;
using Mithril.Hr.Infrastructure.Persistence.Model.Positions;

namespace Mithril.Hr.Infrastructure.Persistence.Model;

[ExcludeFromCodeCoverage]
public class DataContext(
    DbContextOptions<DataContext> options)
    : DbContext(options)
{
    public DbSet<PositionEf> Positions { get; set; } = null!;
    public DbSet<EmployeeEf> Employees { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
	        typeof(DataContext).Assembly);
    }
}
