using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mithril.Hr.Infrastructure.Persistence.Model.Positions;

[ExcludeFromCodeCoverage]
internal sealed class PositionConfiguration : IEntityTypeConfiguration<PositionEf>
{
    public void Configure(EntityTypeBuilder<PositionEf> builder)
    {
        builder.ToTable("Positions")
            .HasKey(entity => entity.PositionCode);
        builder.Property(entity => entity.PositionCode)
            .IsRequired()
            .HasMaxLength(10)
            .ValueGeneratedNever();

        builder.Property(entity => entity.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(entity => entity.Version)
            .IsRequired()
            .IsConcurrencyToken();
    }
}