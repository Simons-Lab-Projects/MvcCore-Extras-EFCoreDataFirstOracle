using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCoreDataFirstOracle.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Regions> Regions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseOracle("User Id=OT;Password=yourpassword;Data Source=OracleOT;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:DefaultSchema", "OT");

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasKey(e => e.CountryId)
                    .HasName("SYS_C005775");

                entity.ToTable("COUNTRIES");

                entity.HasIndex(e => e.CountryId)
                    .HasName("SYS_C005775")
                    .IsUnique();

                entity.Property(e => e.CountryId)
                    .HasColumnName("COUNTRY_ID")
                    .HasColumnType("CHAR(2)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasColumnName("COUNTRY_NAME")
                    .HasColumnType("VARCHAR2(40)");

                entity.Property(e => e.RegionId)
                    .HasColumnName("REGION_ID")
                    .HasColumnType("NUMBER");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_COUNTRIES_REGIONS");
            });

            modelBuilder.Entity<Regions>(entity =>
            {
                entity.HasKey(e => e.RegionId)
                    .HasName("SYS_C005773");

                entity.ToTable("REGIONS");

                entity.HasIndex(e => e.RegionId)
                    .HasName("SYS_C005773")
                    .IsUnique();

                entity.Property(e => e.RegionId)
                    .HasColumnName("REGION_ID")
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RegionName)
                    .IsRequired()
                    .HasColumnName("REGION_NAME")
                    .HasColumnType("VARCHAR2(50)");
            });

            modelBuilder.HasSequence("ISEQ$$_22649");

            modelBuilder.HasSequence("ISEQ$$_22654");

            modelBuilder.HasSequence("ISEQ$$_22657");

            modelBuilder.HasSequence("ISEQ$$_22660");

            modelBuilder.HasSequence("ISEQ$$_22663");

            modelBuilder.HasSequence("ISEQ$$_22666");

            modelBuilder.HasSequence("ISEQ$$_22669");

            modelBuilder.HasSequence("ISEQ$$_22672");

            modelBuilder.HasSequence("ISEQ$$_22675");
        }
    }
}
