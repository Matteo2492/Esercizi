using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Gestione_Palestra.Models;

public partial class GestionePalestraContext : DbContext
{
    public GestionePalestraContext()
    {
    }

    public GestionePalestraContext(DbContextOptions<GestionePalestraContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Corsi> Corsis { get; set; }

    public virtual DbSet<Prenotazioni> Prenotazionis { get; set; }

    public virtual DbSet<PrenotazioniUtenti> PrenotazioniUtentis { get; set; }

    public virtual DbSet<Utenti> Utentis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ACADEMY2024-08\\SQLEXPRESS;Database=Gestione_Palestra;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Corsi>(entity =>
        {
            entity.HasKey(e => e.CorsoId).HasName("PK__Corsi__9F217D0BB5DA2AE3");

            entity.ToTable("Corsi");

            entity.HasIndex(e => e.Codice, "UQ__Corsi__0636EC1D078FD16F").IsUnique();

            entity.HasIndex(e => e.Nome, "UQ__Corsi__7D8FE3B2C714E7A0").IsUnique();

            entity.Property(e => e.CorsoId).HasColumnName("CorsoID");
            entity.Property(e => e.Codice)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValueSql("(concat('CORSO_',CONVERT([varchar](36),newid())))");
            entity.Property(e => e.DataInizioCorso).HasColumnType("datetime");
            entity.Property(e => e.Descrizione)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Prenotazioni>(entity =>
        {
            entity.HasKey(e => e.PrenotazioneId).HasName("PK__Prenotaz__BCF1F26D0DF4E6C9");

            entity.ToTable("Prenotazioni");

            entity.HasIndex(e => e.Codice, "UQ__Prenotaz__0636EC1D4BD0BCEE").IsUnique();

            entity.Property(e => e.PrenotazioneId).HasColumnName("PrenotazioneID");
            entity.Property(e => e.Codice)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValueSql("(concat('PRENOTAZIONE_',CONVERT([varchar](36),newid())))");
            entity.Property(e => e.CorsoRif).HasColumnName("CorsoRIF");
            entity.Property(e => e.DataPrenotazione)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.CorsoRifNavigation).WithMany(p => p.Prenotazionis)
                .HasForeignKey(d => d.CorsoRif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Prenotazi__Corso__656C112C");
        });

        modelBuilder.Entity<PrenotazioniUtenti>(entity =>
        {
            entity.HasKey(e => e.PrenotazioneUtenteId).HasName("PK__Prenotaz__7B52980811222C1D");

            entity.ToTable("PrenotazioniUtenti");

            entity.HasIndex(e => new { e.PrenotazioneId, e.UtenteId }, "UQ_PrenotazioneUtente").IsUnique();

            entity.Property(e => e.PrenotazioneUtenteId).HasColumnName("PrenotazioneUtenteID");
            entity.Property(e => e.PrenotazioneId).HasColumnName("PrenotazioneID");
            entity.Property(e => e.UtenteId).HasColumnName("UtenteID");

            entity.HasOne(d => d.Prenotazione).WithMany(p => p.PrenotazioniUtentis)
                .HasForeignKey(d => d.PrenotazioneId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Prenotazi__Preno__693CA210");

            entity.HasOne(d => d.Utente).WithMany(p => p.PrenotazioniUtentis)
                .HasForeignKey(d => d.UtenteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Prenotazi__Utent__6A30C649");
        });

        modelBuilder.Entity<Utenti>(entity =>
        {
            entity.HasKey(e => e.UtenteId).HasName("PK__Utenti__489EA72A23743697");

            entity.ToTable("Utenti");

            entity.HasIndex(e => e.Codice, "UQ__Utenti__0636EC1DD5389640").IsUnique();

            entity.HasIndex(e => e.Nominativo, "UQ__Utenti__B51ABBBA66F5ED57").IsUnique();

            entity.Property(e => e.UtenteId).HasColumnName("UtenteID");
            entity.Property(e => e.Codice)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Nominativo)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PasswordUtente)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
