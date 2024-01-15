using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mithril.Hr.Domain.Positions;
using Mithril.Hr.Persistence.Entities.Demographics;
using Mithril.Hr.Persistence.Entities.Education;
using Mithril.Hr.Persistence.Entities.Employees;
using Mithril.Hr.Persistence.Entities.Positions;
using System.Diagnostics.CodeAnalysis;

namespace Mithril.Hr.Persistence.Data;

[ExcludeFromCodeCoverage]
public class DataContext(
    DbContextOptions<DataContext> options,
    IServiceProvider serviceProvider) : DbContext(options)
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public DbSet<EmployeeEntity> Employees { get; set; }
    public DbSet<Position> Positions { get; set; }
#pragma warning restore CS8618

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new EmployeeConfiguration(
            GetService<GenderMapper>(),
            GetService<AcademicDegreeMapper>()));
        modelBuilder.ApplyConfiguration(new PositionConfiguration());
    }

    private T GetService<T>()
        where T : class
        => serviceProvider.GetRequiredService<T>();
}
