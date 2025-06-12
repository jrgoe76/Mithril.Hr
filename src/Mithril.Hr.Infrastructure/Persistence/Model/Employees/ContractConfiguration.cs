using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mithril.Hr.Infrastructure.Persistence.Model.Employees;

[ExcludeFromCodeCoverage]
internal sealed class ContractConfiguration : IEntityTypeConfiguration<ContractEf>
{
    public void Configure(EntityTypeBuilder<ContractEf> builder)
    {
        builder.ToTable("Contracts")
            .HasKey(entity => entity.EmployeeId);
        builder.Property(entity => entity.EmployeeId)
            .IsRequired()
            .ValueGeneratedNever();
        builder.HasOne(entity => entity.Employee)
            .WithOne(entity => entity.Contract)
            .HasForeignKey<ContractEf>(entity => entity.EmployeeId);
    }
}
