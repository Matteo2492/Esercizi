using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GestioneImpiegati.Models;

public partial class AccLez35GestioneImpiegatiContext : DbContext
{
    public AccLez35GestioneImpiegatiContext()
    {
    }

    public AccLez35GestioneImpiegatiContext(DbContextOptions<AccLez35GestioneImpiegatiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cittum> Citta { get; set; }

    public virtual DbSet<Impiegato> Impiegatos { get; set; }

    public virtual DbSet<Provincium> Provincia { get; set; }

    public virtual DbSet<Reparto> Repartos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ACADEMY2024-08\\SQLEXPRESS;Database=acc_lez35_gestione_impiegati;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cittum>(entity =>
        {
            entity.HasKey(e => e.CittaId).HasName("PK__Citta__B733443C71AC6B35");

            entity.HasIndex(e => e.Nome, "UQ__Citta__7D8FE3B2224E5A04").IsUnique();

            entity.Property(e => e.CittaId).HasColumnName("CittaID");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ProvinciaRif).HasColumnName("ProvinciaRIF");

            entity.HasOne(d => d.ProvinciaRifNavigation).WithMany(p => p.Citta)
                .HasForeignKey(d => d.ProvinciaRif)
                .HasConstraintName("FK__Citta__Provincia__3B75D760");
        });

        modelBuilder.Entity<Impiegato>(entity =>
        {
            entity.HasKey(e => e.ImpiegatoId).HasName("PK__Impiegat__660B907FC57E07FB");

            entity.ToTable("Impiegato");

            entity.HasIndex(e => e.Matricola, "UQ__Impiegat__062C805730DBC06B").IsUnique();

            entity.Property(e => e.ImpiegatoId).HasColumnName("ImpiegatoID");
            entity.Property(e => e.CittaRif)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("CittaRIF");
            entity.Property(e => e.Cognome)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.DataNasc).HasColumnType("datetime");
            entity.Property(e => e.Indirizzo)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Matricola)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ProvinciaRif)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("ProvinciaRIF");
            entity.Property(e => e.RepartoRif).HasColumnName("RepartoRIF");
            entity.Property(e => e.Ruolo)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.RepartoRifNavigation).WithMany(p => p.Impiegatos)
                .HasForeignKey(d => d.RepartoRif)
                .HasConstraintName("FK__Impiegato__Repar__52593CB8");
        });

        modelBuilder.Entity<Provincium>(entity =>
        {
            entity.HasKey(e => e.ProvinciaId).HasName("PK__Provinci__F7CBC7571AD0381E");

            entity.HasIndex(e => e.Sigla, "UQ__Provinci__3199C5ED7A3B38CC").IsUnique();

            entity.Property(e => e.ProvinciaId).HasColumnName("ProvinciaID");
            entity.Property(e => e.Sigla)
                .HasMaxLength(2)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Reparto>(entity =>
        {
            entity.HasKey(e => e.RepartoId).HasName("PK__Reparto__100BEE152C87AB45");

            entity.ToTable("Reparto");

            entity.HasIndex(e => e.Nome, "UQ__Reparto__7D8FE3B23D613591").IsUnique();

            entity.Property(e => e.RepartoId).HasColumnName("RepartoID");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
