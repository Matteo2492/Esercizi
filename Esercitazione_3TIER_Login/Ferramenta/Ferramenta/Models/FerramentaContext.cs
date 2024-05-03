using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Ferramenta.Models;

public partial class FerramentaContext : DbContext
{
    public FerramentaContext()
    {
    }

    public FerramentaContext(DbContextOptions<FerramentaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Prodotti> Prodottis { get; set; }

    public virtual DbSet<Utente> Utentes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ACADEMY2024-08\\SQLEXPRESS;Database=Ferramenta;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Prodotti>(entity =>
        {
            entity.HasKey(e => e.ProdottoId).HasName("PK__Prodotti__3AB659750B49FBDC");

            entity.ToTable("Prodotti");

            entity.HasIndex(e => e.Nome, "UQ__Prodotti__6F71C0DC6FEB706D").IsUnique();

            entity.Property(e => e.ProdottoId).HasColumnName("prodottoID");
            entity.Property(e => e.Categoria)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("categoria");
            entity.Property(e => e.CodiceProdotto)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("codice_prodotto");
            entity.Property(e => e.Descrizione)
                .HasColumnType("text")
                .HasColumnName("descrizione");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Prezzo)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("prezzo");
            entity.Property(e => e.Quantita)
                .HasDefaultValue(0)
                .HasColumnName("quantita");
        });

        modelBuilder.Entity<Utente>(entity =>
        {
            entity.HasKey(e => e.UtenteId).HasName("PK__Utente__CA5C22534D79F789");

            entity.ToTable("Utente");

            entity.HasIndex(e => e.Username, "UQ__Utente__F3DBC572F0FCBAE9").IsUnique();

            entity.Property(e => e.UtenteId).HasColumnName("utenteID");
            entity.Property(e => e.Nominativo)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nominativo");
            entity.Property(e => e.PasswordUtente)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("password_utente");
            entity.Property(e => e.Username)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
