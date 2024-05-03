using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EsercizioEventi.Models;

public partial class AccLez28EventiContext : DbContext
{
    public AccLez28EventiContext()
    {
    }

    public AccLez28EventiContext(DbContextOptions<AccLez28EventiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Eventi> Eventis { get; set; }

    public virtual DbSet<Partecipanti> Partecipantis { get; set; }

    public virtual DbSet<Risorse> Risorses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ACADEMY2024-08\\SQLEXPRESS;Database=acc_lez28_eventi;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Eventi>(entity =>
        {
            entity.HasKey(e => e.EventiId).HasName("PK__Eventi__0FF5441EF6DAB746");

            entity.ToTable("Eventi");

            entity.Property(e => e.EventiId).HasColumnName("EventiID");
            entity.Property(e => e.DataEvento).HasColumnType("datetime");
            entity.Property(e => e.Descrizione)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Luogo)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.NomeEvento)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PartecipanteRif).HasColumnName("PartecipanteRIF");
            entity.Property(e => e.RisorseRif).HasColumnName("RisorseRIF");

            entity.HasOne(d => d.PartecipanteRifNavigation).WithMany(p => p.Eventis)
                .HasForeignKey(d => d.PartecipanteRif)
                .HasConstraintName("FK__Eventi__Capacita__3C69FB99");

            entity.HasOne(d => d.RisorseRifNavigation).WithMany(p => p.Eventis)
                .HasForeignKey(d => d.RisorseRif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Eventi__RisorseR__3D5E1FD2");
        });

        modelBuilder.Entity<Partecipanti>(entity =>
        {
            entity.HasKey(e => e.PartecipanteId).HasName("PK__Partecip__B7AAD0FD5FA4190B");

            entity.ToTable("Partecipanti");

            entity.HasIndex(e => e.Contatto, "UQ__Partecip__B34F8819C01F8439").IsUnique();

            entity.Property(e => e.PartecipanteId).HasColumnName("PartecipanteID");
            entity.Property(e => e.Contatto)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Risorse>(entity =>
        {
            entity.HasKey(e => e.RisorsaId).HasName("PK__Risorse__82675AB09DFA1E79");

            entity.ToTable("Risorse");

            entity.Property(e => e.RisorsaId).HasColumnName("RisorsaID");
            entity.Property(e => e.Fornitore)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.NomeRisorsa)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
