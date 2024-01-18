using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mithril.Hr.Persistence.Entities.Employees;

[ExcludeFromCodeCoverage]
internal sealed class ContractConfiguration : IEntityTypeConfiguration<ContractEntity>
{
    public void Configure(EntityTypeBuilder<ContractEntity> builder)
    {
        builder.ToTable("Contracts")
            .HasKey(entity => entity.EmployeeId);
        builder.Property(entity => entity.EmployeeId)
            .IsRequired()
            .ValueGeneratedNever();
        builder.HasOne(entity => entity.Employee)
            .WithOne()
            .HasForeignKey<ContractEntity>(entity => entity.EmployeeId);
    }
}
