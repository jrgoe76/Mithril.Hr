using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mithril.Hr.Persistence.Entities.Employees;

[ExcludeFromCodeCoverage]
internal sealed class EmployeeConfiguration : IEntityTypeConfiguration<EmployeeEf>
{
    public void Configure(EntityTypeBuilder<EmployeeEf> builder)
    {
        builder.ToTable("Employees")
            .HasKey(entity => entity.EmployeeId);
        builder.Property(entity => entity.EmployeeId)
            .IsRequired()
            .ValueGeneratedNever();

        builder.Property(entity => entity.FirstName)
	        .IsRequired()
	        .HasMaxLength(50);
        builder.Property(value => value.MiddleInitial)
			.HasMaxLength(1);
        builder.Property(value => value.LastName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(entity => entity.Gender)
            .IsRequired();

        builder.Property(value => value.EmailAddress)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(value => value.AddressLine1)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(value => value.AddressLine2)
			.HasMaxLength(50);
        builder.Property(value => value.City)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(value => value.State)
            .IsRequired()
            .HasMaxLength(2);
        builder.Property(value => value.Zipcode)
            .IsRequired()
            .HasMaxLength(5);

        builder.Property(entity => entity.Degree)
            .IsRequired()
            .HasMaxLength(2);

        builder.Property(entity => entity.Version)
            .IsRequired()
            .IsConcurrencyToken();
    }
}
