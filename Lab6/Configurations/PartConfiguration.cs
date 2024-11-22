using Lab6.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab6.Configurations
{
    public class PartConfiguration : IEntityTypeConfiguration<Part>
    {
        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder.HasKey(p => p.PartId);

            builder.Property(p => p.PartName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.OtherPartDetails).HasMaxLength(500);

            builder.HasMany(p => p.AssetParts)
                   .WithOne(ap => ap.Part)
                   .HasForeignKey(ap => ap.PartId);

            builder.HasMany(p => p.FaultLogParts)
                   .WithOne(fp => fp.Part)
                   .HasForeignKey(fp => fp.PartId);
        }
    }
}
