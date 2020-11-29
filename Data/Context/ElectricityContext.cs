using System;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace Data.Context
{
    public partial class ElectricityContext : DbContext
    {

        public ElectricityContext()
        {
        }

        public ElectricityContext(DbContextOptions<ElectricityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ElectricityUsage> ElectricityUsages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ElectricityUsage>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ElectricityUsage");

                entity.Property(e => e.Area).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
