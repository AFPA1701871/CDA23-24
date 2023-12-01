using System;
using System.Collections.Generic;
using ClientsArticles.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace ClientsArticles.Models;

public partial class ClientsArticlesDbContext : DbContext
{
    public ClientsArticlesDbContext()
    {
    }

    public ClientsArticlesDbContext(DbContextOptions<ClientsArticlesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<Categorie> Categories { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Commande> Commandes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("name=default");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.IdArticle).HasName("PRIMARY");

            entity.ToTable("articles");

            entity.HasIndex(e => e.IdCategorie, "fk_articles_categories");

            entity.Property(e => e.IdArticle)
                .HasColumnType("int(11)")
                .HasColumnName("idArticle");
            entity.Property(e => e.DescriptionArticle)
                .HasMaxLength(50)
                .HasColumnName("descriptionArticle");
            entity.Property(e => e.IdCategorie)
                .HasColumnType("int(11)")
                .HasColumnName("idCategorie");
            entity.Property(e => e.PrixArticle)
                .HasColumnType("int(11)")
                .HasColumnName("prixArticle");

            entity.HasOne(d => d.LaCategorie).WithMany(p => p.ListeArticles)
                .HasForeignKey(d => d.IdCategorie)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_articles_categories");
        });

        modelBuilder.Entity<Categorie>(entity =>
        {
            entity.HasKey(e => e.IdCategorie).HasName("PRIMARY");

            entity.ToTable("categories");

            entity.Property(e => e.IdCategorie)
                .HasColumnType("int(11)")
                .HasColumnName("idCategorie");
            entity.Property(e => e.LibelleCategorie)
                .HasMaxLength(50)
                .HasColumnName("libelleCategorie");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("PRIMARY");

            entity.ToTable("clients");

            entity.Property(e => e.IdClient)
                .HasColumnType("int(11)")
                .HasColumnName("idClient");
            entity.Property(e => e.DateEntreeClient)
                .HasColumnType("date")
                .HasColumnName("dateEntreeClient");
            entity.Property(e => e.NomClient)
                .HasMaxLength(50)
                .HasColumnName("nomClient");
            entity.Property(e => e.PrenomClient)
                .HasMaxLength(50)
                .HasColumnName("prenomClient");
        });

        modelBuilder.Entity<Commande>(entity =>
        {
            entity.HasKey(e => e.IdCommande).HasName("PRIMARY");

            entity.ToTable("commandes");

            entity.HasIndex(e => e.IdArticle, "FK_Articles");

            entity.HasIndex(e => e.IdClient, "FK_Clients");

            entity.Property(e => e.IdCommande)
                .HasColumnType("int(11)")
                .HasColumnName("idCommande");
            entity.Property(e => e.DateCommande)
                .HasColumnType("date")
                .HasColumnName("dateCommande");
            entity.Property(e => e.IdArticle)
                .HasColumnType("int(11)")
                .HasColumnName("idArticle");
            entity.Property(e => e.IdClient)
                .HasColumnType("int(11)")
                .HasColumnName("idClient");
            entity.Property(e => e.QuantiteCommande)
                .HasColumnType("int(11)")
                .HasColumnName("quantiteCommande");

            entity.HasOne(d => d.LArticle).WithMany(p => p.ListeCommandes)
                .HasForeignKey(d => d.IdArticle)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Articles");

            entity.HasOne(d => d.LeClient).WithMany(p => p.ListeCommandes)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Clients");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
