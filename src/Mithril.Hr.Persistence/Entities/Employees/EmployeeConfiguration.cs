using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithril.Hr.Persistence.Entities.Demographics;
using Mithril.Hr.Persistence.Entities.Education;
using System.Diagnostics.CodeAnalysis;

namespace Mithril.Hr.Persistence.Entities.Employees;

[ExcludeFromCodeCoverage]
internal sealed class EmployeeConfiguration(
    GenderConverter genderConverter,
    AcademicDegreeConverter academicDegreeConverter) : IEntityTypeConfiguration<EmployeeEntity>
{
    public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
    {
        builder.ToTable("Employees")
            .HasKey(entity => entity.EmployeeId);
        builder.Property(entity => entity.EmployeeId)
            .IsRequired()
            .ValueGeneratedNever();

        builder.ComplexProperty(entity => entity.Name)
            .IsRequired();
        builder.ComplexProperty(entity => entity.Name)
            .Property(value => value.FirstName)
                .IsRequired()
                .HasMaxLength(50);
        builder.ComplexProperty(entity => entity.Name)
            .Property(value => value.MiddleInitial)
                .HasMaxLength(1);
        builder.ComplexProperty(entity => entity.Name)
            .Property(value => value.LastName)
                .IsRequired()
                .HasMaxLength(50);

        builder.Property(entity => entity.Gender)
            .IsRequired()
            .HasConversion(genderConverter);

        builder.ComplexProperty(entity => entity.Email)
            .IsRequired();
        builder.ComplexProperty(entity => entity.Email)
            .Property(value => value.Address)
                .IsRequired()
                .HasMaxLength(100);

        builder.ComplexProperty(entity => entity.Address)
            .IsRequired();
        builder.ComplexProperty(entity => entity.Address)
            .Property(value => value.AddressLine1)
                .IsRequired()
                .HasMaxLength(100);
        builder.ComplexProperty(entity => entity.Address)
            .Property(value => value.AddressLine2)
                .HasMaxLength(50);
        builder.ComplexProperty(entity => entity.Address)
            .Property(value => value.City)
                .IsRequired()
                .HasMaxLength(50);
        builder.ComplexProperty(entity => entity.Address)
            .Property(value => value.State)
                .IsRequired()
                .HasMaxLength(2);
        builder.ComplexProperty(entity => entity.Address)
            .Property(value => value.Zipcode)
                .IsRequired()
                .HasMaxLength(5);

        builder.Property(entity => entity.Degree)
            .IsRequired()
            .HasMaxLength(2)
            .HasConversion(academicDegreeConverter);

        builder.Ignore(entity => entity.Contract);

        builder.Property(entity => entity.Version)
            .IsRequired()
            .IsConcurrencyToken();
    }
}
