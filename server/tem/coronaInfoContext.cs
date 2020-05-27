using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace tem
{
    public partial class coronaInfoContext : DbContext
    {
        public coronaInfoContext()
        {
        }

        public coronaInfoContext(DbContextOptions<coronaInfoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Paths> Paths { get; set; }
        public virtual DbSet<Patients> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source = localhost\\MSSQLSERVER01; Initial Catalog = coronaInfo; Trusted_Connection = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paths>(entity =>
            {
                entity.HasIndex(e => e.PatientId);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Paths)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Paths_Patients");
            });

            modelBuilder.Entity<Patients>(entity =>
            {
                entity.HasKey(e => e.PatientId);

                entity.Property(e => e.PatientId).ValueGeneratedNever();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
