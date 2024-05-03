using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Chattero.Models;

public partial class ChatteroContext : DbContext
{
    public ChatteroContext()
    {
    }

    public ChatteroContext(DbContextOptions<ChatteroContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Utente> Utentes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Utente>(entity =>
        {
            entity.HasKey(e => e.UtenteId).HasName("PK__Utente__CA5C2253CFF28057");

            entity.ToTable("Utente");

            entity.HasIndex(e => e.Username, "UQ__Utente__F3DBC572EFC28FEC").IsUnique();

            entity.Property(e => e.UtenteId).HasColumnName("utenteID");
            entity.Property(e => e.CodiceUtente)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("codice_utente");
            entity.Property(e => e.IsDeleted)
                .HasColumnType("datetime")
                .HasColumnName("isDeleted");
            entity.Property(e => e.Passw)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("passw");
            entity.Property(e => e.Username)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
