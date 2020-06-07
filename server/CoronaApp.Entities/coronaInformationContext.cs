using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoronaApp.Entities
{
    public partial class coronaInformationContext : DbContext
    {
        public coronaInformationContext()
        {
        }

        public coronaInformationContext(DbContextOptions<coronaInformationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<Paths> Paths { get; set; }
        public virtual DbSet<Patients> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=C1;Database=coronaInformation;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>(entity =>
            {
                entity.Property(e => e.Level).HasMaxLength(128);

                entity.Property(e => e.Properties).HasColumnType("xml");
            });

            modelBuilder.Entity<Paths>(entity =>
            {
                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Paths)
                    .HasForeignKey(d => d.PatientId);
            });

            modelBuilder.Entity<Patients>(entity =>
            {
                entity.HasKey(e => e.PatientId);

                entity.Property(e => e.PatientId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
