using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WpfAvecScaffold.Models;

public partial class PersonnesDbContext : DbContext
{
    public PersonnesDbContext()
    {
    }

    public PersonnesDbContext(DbContextOptions<PersonnesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Personne> Personnes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseMySQL("server=localhost;user=root;port=3306;database=personnesdb;ssl mode=none");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Personne>(entity =>
        {
            entity.HasKey(e => e.IdPersonne).HasName("PRIMARY");

            entity.ToTable("personnes");

            entity.Property(e => e.IdPersonne)
                .HasColumnType("int(11)")
                .HasColumnName("idPersonne");
            entity.Property(e => e.Adresse)
                .HasMaxLength(100)
                .HasColumnName("adresse");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .HasColumnName("nom");
            entity.Property(e => e.Prenom)
                .HasMaxLength(50)
                .HasColumnName("prenom");
            entity.Property(e => e.Ville)
                .HasMaxLength(50)
                .HasColumnName("ville");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
