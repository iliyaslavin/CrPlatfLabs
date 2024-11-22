using Lab6.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab6.Configurations
{
    public class EngineerConfiguration : IEntityTypeConfiguration<MaintenanceEngineer>
    {
        public void Configure(EntityTypeBuilder<MaintenanceEngineer> builder)
        {
            builder.HasKey(e => e.EngineerId);

            builder.Property(e => e.FirstName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(e => e.LastName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(e => e.OtherDetails).HasMaxLength(500);

            builder.HasOne(e => e.Company)
                   .WithMany(c => c.MaintenanceEngineers)
                   .HasForeignKey(e => e.CompanyId)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(e => e.EngineerSkills)
                   .WithOne(es => es.Engineer)
                   .HasForeignKey(es => es.EngineerId);
        }
    }
}
