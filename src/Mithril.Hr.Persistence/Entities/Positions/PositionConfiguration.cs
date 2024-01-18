using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mithril.Hr.Domain.Positions;

namespace Mithril.Hr.Persistence.Entities.Positions;

[ExcludeFromCodeCoverage]
internal sealed class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
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
    }
}
