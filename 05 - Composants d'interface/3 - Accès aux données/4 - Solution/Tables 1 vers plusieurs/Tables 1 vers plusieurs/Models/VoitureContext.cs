using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Tables_1_vers_plusieurs.Models.Data;

namespace Tables_1_vers_plusieurs.Models;

public partial class VoitureContext : DbContext
{
    public VoitureContext()
    {
    }

    public VoitureContext(DbContextOptions<VoitureContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Marque> Marques { get; set; }

    public virtual DbSet<Modele> Modeles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("name=default");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Marque>(entity =>
        {
            entity.HasKey(e => e.IdMarque).HasName("PRIMARY");

            entity.ToTable("marque");

            entity.Property(e => e.IdMarque)
                .HasColumnType("int(11)")
                .HasColumnName("idMarque");
            entity.Property(e => e.Libelle).HasMaxLength(50);
        });

        modelBuilder.Entity<Modele>(entity =>
        {
            entity.HasKey(e => e.IdModele).HasName("PRIMARY");

            entity.ToTable("modele");

            entity.HasIndex(e => e.MarqueId, "FK_Marque_IdMarque");

            entity.Property(e => e.IdModele)
                .HasColumnType("int(11)")
                .HasColumnName("idModele");
            entity.Property(e => e.Libelle)
                .HasMaxLength(50)
                .HasColumnName("libelle");
            entity.Property(e => e.MarqueId)
                .HasColumnType("int(11)")
                .HasColumnName("marqueID");
            /* RELATION */
            entity.HasOne(d => d.LaMarque)
                .WithMany(p => p.ListeModeles)
                .HasForeignKey(d => d.MarqueId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Marque_IdMarque");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
