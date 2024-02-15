using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MilesCarRent.Models
{
    public partial class MilesCarRentalContext : DbContext
    {
        public MilesCarRentalContext()
        {
        }

        public MilesCarRentalContext(DbContextOptions<MilesCarRentalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Lugar> Lugars { get; set; } = null!;
        public virtual DbSet<Vehiculo> Vehiculos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lugar>(entity =>
            {
                entity.HasKey(e => e.IdLugar)
                    .HasName("PK__Lugar__35F8CED0B0877848");

                entity.ToTable("Lugar");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.IdVehiculo)
                    .HasName("PK__Vehiculo__70861215DF8A69BD");

                entity.ToTable("Vehiculo");

                entity.Property(e => e.Marca)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.oUbicacionActual)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.UbicacionActual)
                    .HasConstraintName("FK_IDLUGAR");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
