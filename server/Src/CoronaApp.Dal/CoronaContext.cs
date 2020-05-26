using CoronaApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.Dal
{
    public class CoronaContext:DbContext
    {
        public CoronaContext()
        {
        }

        public CoronaContext(DbContextOptions<CoronaContext> options)
            : base(options)
        {
        }
        public DbSet<Path> Paths  { get; set; }
        public DbSet<Patient> Patients { get; set; }
    }
}
