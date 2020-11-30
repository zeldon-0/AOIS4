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
        public virtual DbSet<Income> Incomes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ElectricityUsage>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ElectricityUsage");

                entity.Property(e => e.Area).HasMaxLength(255);
            });
            modelBuilder.Entity<Income>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Income");

                entity.Property(e => e.CommunityAreaName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("COMMUNITY AREA NAME");

                entity.Property(e => e.CommunityAreaNumber).HasColumnName("Community Area Number");

                entity.Property(e => e.PerCapitaIncome).HasColumnName("PER CAPITA INCOME ");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
