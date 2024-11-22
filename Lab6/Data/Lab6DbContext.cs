using Lab6.Configurations;
using Lab6.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Data
{
    public class Lab6DbContext : DbContext
    {
        public Lab6DbContext(DbContextOptions<Lab6DbContext> options) : base(options) { }

        // Таблиці
        public DbSet<ThirdPartyCompany> ThirdPartyCompanies { get; set; }
        public DbSet<RefCompanyType> RefCompanyTypes { get; set; }
        public DbSet<MaintenanceContract> MaintenanceContracts { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<AssetPart> AssetParts { get; set; }
        public DbSet<FaultLog> FaultLogs { get; set; }
        public DbSet<FaultLogPart> FaultLogParts { get; set; }
        public DbSet<RefFaultStatus> RefFaultStatuses { get; set; }
        public DbSet<PartFault> PartFaults { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillRequiredToFix> SkillsRequiredToFix { get; set; }
        public DbSet<EngineerSkill> EngineerSkills { get; set; }
        public DbSet<MaintenanceEngineer> MaintenanceEngineers { get; set; }
        public DbSet<EngineerVisit> EngineerVisits { get; set; }
        public DbSet<Staff> Staff { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Налаштування таблиці ThirdPartyCompanies
            modelBuilder.Entity<ThirdPartyCompany>()
                .HasKey(c => c.CompanyId);

            modelBuilder.Entity<ThirdPartyCompany>()
                .HasOne(c => c.CompanyType)
                .WithMany(t => t.ThirdPartyCompanies)
                .HasForeignKey(c => c.CompanyTypeCode);

            // Налаштування таблиці RefCompanyTypes
            modelBuilder.Entity<RefCompanyType>()
                .HasKey(t => t.CompanyTypeCode);

            // Налаштування таблиці MaintenanceContracts
            modelBuilder.Entity<MaintenanceContract>()
                .HasKey(mc => mc.MaintenanceContractId);

            modelBuilder.Entity<MaintenanceContract>()
                .HasOne(mc => mc.MaintenanceContractCompany)
                .WithMany(c => c.MaintenanceContracts)
                .HasForeignKey(mc => mc.MaintenanceContractCompanyId);

            // Налаштування таблиці Assets
            modelBuilder.Entity<Asset>()
                .HasKey(a => a.AssetId);

            modelBuilder.Entity<Asset>()
                .HasOne(a => a.SupplierCompany)
                .WithMany(c => c.Assets)
                .HasForeignKey(a => a.SupplierCompanyId);

            modelBuilder.Entity<Asset>()
                .HasOne(a => a.ParentAsset)
                .WithMany()
                .HasForeignKey(a => a.ParentAssetId)
                .OnDelete(DeleteBehavior.Restrict);

            // Налаштування таблиці AssetParts
            modelBuilder.Entity<AssetPart>()
                .HasKey(ap => new { ap.AssetId, ap.PartId });

            modelBuilder.Entity<AssetPart>()
                .HasOne(ap => ap.Asset)
                .WithMany(a => a.AssetParts)
                .HasForeignKey(ap => ap.AssetId);

            modelBuilder.Entity<AssetPart>()
                .HasOne(ap => ap.Part)
                .WithMany(p => p.AssetParts)
                .HasForeignKey(ap => ap.PartId);

            // Налаштування таблиці Parts
            modelBuilder.Entity<Part>()
                .HasKey(p => p.PartId);

            // Налаштування таблиці PartFaults
            modelBuilder.Entity<PartFault>()
                .HasKey(pf => pf.PartFaultId);

            modelBuilder.Entity<PartFault>()
                .HasMany(pf => pf.SkillsRequiredToFix)
                .WithOne(s => s.PartFault)
                .HasForeignKey(s => s.PartFaultId);

            // Налаштування таблиці Skills
            modelBuilder.Entity<Skill>()
                .HasKey(s => s.SkillId);

            // Налаштування таблиці SkillsRequiredToFix
            modelBuilder.Entity<SkillRequiredToFix>()
                .HasKey(s => s.SkillRequiredToFixId);

            modelBuilder.Entity<SkillRequiredToFix>()
                .HasOne(s => s.PartFault)
                .WithMany(pf => pf.SkillsRequiredToFix)
                .HasForeignKey(s => s.PartFaultId);

            modelBuilder.Entity<SkillRequiredToFix>()
                .HasOne(s => s.Skill)
                .WithMany()
                .HasForeignKey(s => s.SkillId);

            // Налаштування таблиці Staff
            modelBuilder.Entity<Staff>()
                .HasKey(s => s.StaffId);

            // Налаштування таблиці EngineerSkills
            modelBuilder.Entity<EngineerSkill>()
                .HasKey(es => new { es.EngineerId, es.SkillId });

            modelBuilder.Entity<EngineerSkill>()
                .HasOne(es => es.Engineer)
                .WithMany(e => e.EngineerSkills)
                .HasForeignKey(es => es.EngineerId);

            modelBuilder.Entity<EngineerSkill>()
                .HasOne(es => es.Skill)
                .WithMany(s => s.EngineerSkills)
                .HasForeignKey(es => es.SkillId);

            // Налаштування таблиці EngineerVisits
            modelBuilder.Entity<EngineerVisit>()
                .HasKey(ev => ev.EngineerVisitId);

            modelBuilder.Entity<EngineerVisit>()
                .HasOne(ev => ev.ContactStaff)
                .WithMany()
                .HasForeignKey(ev => ev.ContactStaffId);

            modelBuilder.Entity<EngineerVisit>()
                .HasOne(ev => ev.Engineer)
                .WithMany()
                .HasForeignKey(ev => ev.EngineerId);

            // Налаштування таблиці FaultLogs
            modelBuilder.Entity<FaultLog>()
                .HasKey(fl => fl.FaultLogEntryId);

            modelBuilder.Entity<FaultLog>()
                .HasOne(fl => fl.Asset)
                .WithMany(a => a.FaultLogs)
                .HasForeignKey(fl => fl.AssetId);

            modelBuilder.Entity<FaultLog>()
                .HasOne(fl => fl.RecordedByStaff)
                .WithMany(s => s.FaultLogs)
                .HasForeignKey(fl => fl.RecordedByStaffId);

            // Налаштування таблиці FaultLogParts
            modelBuilder.Entity<FaultLogPart>()
                .HasKey(flp => new { flp.FaultLogEntryId, flp.PartId, flp.FaultStatusCode });

            modelBuilder.Entity<FaultLogPart>()
                .HasOne(flp => flp.FaultLog)
                .WithMany(fl => fl.FaultLogParts)
                .HasForeignKey(flp => flp.FaultLogEntryId);

            modelBuilder.Entity<FaultLogPart>()
                .HasOne(flp => flp.Part)
                .WithMany(p => p.FaultLogParts)
                .HasForeignKey(flp => flp.PartId);

            modelBuilder.Entity<FaultLogPart>()
                .HasOne(flp => flp.FaultStatus)
                .WithMany()
                .HasForeignKey(flp => flp.FaultStatusCode);

            // Налаштування таблиці RefFaultStatuses
            modelBuilder.Entity<RefFaultStatus>()
                .HasKey(rfs => rfs.FaultStatusCode);

            modelBuilder.ApplyConfiguration(new AssetConfiguration());
            modelBuilder.ApplyConfiguration(new PartConfiguration());
            modelBuilder.ApplyConfiguration(new EngineerConfiguration());

            base.OnModelCreating(modelBuilder);


        }
    }
}
