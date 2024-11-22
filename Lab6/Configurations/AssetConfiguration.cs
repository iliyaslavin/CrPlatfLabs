using Lab6.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab6.Configurations
{
    public class AssetConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.HasKey(a => a.AssetId); // Primary Key

            builder.Property(a => a.AssetName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(a => a.AssetMake).HasMaxLength(50);
            builder.Property(a => a.AssetModel).HasMaxLength(50);
            builder.Property(a => a.OtherAssetDetails).HasMaxLength(500);

            builder.HasOne(a => a.SupplierCompany)
                   .WithMany(c => c.Assets)
                   .HasForeignKey(a => a.SupplierCompanyId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.ParentAsset)
                   .WithMany()
                   .HasForeignKey(a => a.ParentAssetId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(a => a.AssetParts)
                   .WithOne(ap => ap.Asset)
                   .HasForeignKey(ap => ap.AssetId);
        }
    }
}
