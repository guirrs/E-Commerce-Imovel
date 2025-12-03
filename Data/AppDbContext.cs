using System;
using System.Collections.Generic;
using E_Commerce_Imovel.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Imovel.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Caracteristica> Caracteristicas { get; set; }

    public virtual DbSet<Domicilio> Domicilios { get; set; }

    public virtual DbSet<DomicilioTipoCompra> DomicilioTipoCompras { get; set; }

    public virtual DbSet<DomicilioTipoImovel> DomicilioTipoImovels { get; set; }

    public virtual DbSet<DomicilioUsuario> DomicilioUsuarios { get; set; }

    public virtual DbSet<TipoCompra> TipoCompras { get; set; }

    public virtual DbSet<TipoImovel> TipoImovels { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Domicilio>(entity =>
        {
            entity.Property(e => e.Publicacao).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Caracteristica).WithMany(p => p.Domicilios).HasConstraintName("FK_Domicilio_Caracteristica");
        });

        modelBuilder.Entity<DomicilioTipoCompra>(entity =>
        {
            entity.HasOne(d => d.Domicilio).WithMany()
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DTC_Domicilio");

            entity.HasOne(d => d.TipoCompra).WithMany()
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DTC_TipoCompra");
        });

        modelBuilder.Entity<DomicilioTipoImovel>(entity =>
        {
            entity.HasOne(d => d.Domicilio).WithMany()
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DTI_Domicilio");

            entity.HasOne(d => d.TipoImovel).WithMany()
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DTI_TipoImovel");
        });

        modelBuilder.Entity<DomicilioUsuario>(entity =>
        {
            entity.HasOne(d => d.Domicilio).WithMany()
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DU_Domicilio");

            entity.HasOne(d => d.Usuario).WithMany()
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DU_Usuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.Property(e => e.CriadoEM).HasDefaultValueSql("(sysutcdatetime())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
