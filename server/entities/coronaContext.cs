using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace entitiestemp
{
    public partial class coronaContext : DbContext
    {
        public coronaContext()
        {
        }

        public coronaContext(DbContextOptions<coronaContext> options)
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
                optionsBuilder.UseSqlServer("Data Source = localhost; Initial Catalog = corona; Trusted_Connection = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paths>(entity =>
            {
                entity.HasIndex(e => e.PatientId);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Paths)
                    .HasForeignKey(d => d.PatientId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
