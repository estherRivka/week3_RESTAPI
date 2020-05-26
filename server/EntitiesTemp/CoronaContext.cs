using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntitiesTemp
{
    public partial class CoronaContext : DbContext
    {
        public CoronaContext()
        {
        }

        public CoronaContext(DbContextOptions<CoronaContext> options)
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
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectsV13;Initial Catalog=Corona");
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
