using CoronaApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.Dal
{
    public class CoronaContext : DbContext
    {
        public CoronaContext()

        {
        }
        public CoronaContext(DbContextOptions<CoronaContext> options)
          : base(options)
        {
        }

        public DbSet<Path> Paths { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    //////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //    optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectsV13;Database=coronaInfo;Trusted_Connection=True;");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Path>(entity =>
            {
               // entity.HasIndex(e => e.PatientId);

                //entity
                ////.HasOne(d => d.PatientId)
                ////.WithMany(p => p.Paths)
                ////.HasForeignKey(d => d.PatientId)
                ////.OnDelete(DeleteBehavior.Cascade)
                //.HasConstraintName("FK_Paths_Patients");
            });
        }

       // partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
