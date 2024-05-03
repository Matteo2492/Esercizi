using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GestioneRistorante.Models;

public partial class DeliveryoContext : DbContext
{
    public DeliveryoContext()
    {
    }

    public DeliveryoContext(DbContextOptions<DeliveryoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Ordini> Ordinis { get; set; }

    public virtual DbSet<Piatto> Piattos { get; set; }

    public virtual DbSet<Ristorante> Ristorantes { get; set; }

    public virtual DbSet<Utente> Utentes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ACADEMY2024-08\\SQLEXPRESS;Database=Deliveryo;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.MenuId).HasName("PK__Menu__3B407E94389C93F7");

            entity.ToTable("Menu");

            entity.HasIndex(e => e.Codice, "UQ__Menu__40F9C18BB097A943").IsUnique();

            entity.Property(e => e.MenuId).HasColumnName("menuID");
            entity.Property(e => e.Codice)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("codice");
            entity.Property(e => e.RistoranteRif).HasColumnName("ristoranteRIF");

            entity.HasOne(d => d.RistoranteRifNavigation).WithMany(p => p.Menus)
                .HasForeignKey(d => d.RistoranteRif)
                .HasConstraintName("FK__Menu__ristorante__5DCAEF64");
        });

        modelBuilder.Entity<Ordini>(entity =>
        {
            entity.HasKey(e => e.OrdineId).HasName("PK__Ordini__8F87D0E5EDAAA7B5");

            entity.ToTable("Ordini");

            entity.HasIndex(e => e.Codice, "UQ__Ordini__40F9C18BC38B33D3").IsUnique();

            entity.Property(e => e.OrdineId).HasColumnName("ordineID");
            entity.Property(e => e.Codice)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("codice");
            entity.Property(e => e.DataOraConsegnaPrevista)
                .HasColumnType("datetime")
                .HasColumnName("dataOraConsegnaPrevista");
            entity.Property(e => e.DataOrdine)
                .HasColumnType("datetime")
                .HasColumnName("dataOrdine");
            entity.Property(e => e.UtenteRif).HasColumnName("utenteRIF");

            entity.HasOne(d => d.UtenteRifNavigation).WithMany(p => p.Ordinis)
                .HasForeignKey(d => d.UtenteRif)
                .HasConstraintName("FK__Ordini__utenteRI__6477ECF3");

            entity.HasMany(d => d.PiattoRifs).WithMany(p => p.OrdineRifs)
                .UsingEntity<Dictionary<string, object>>(
                    "OrdiniPiatti",
                    r => r.HasOne<Piatto>().WithMany()
                        .HasForeignKey("PiattoRif")
                        .HasConstraintName("FK__OrdiniPia__piatt__70DDC3D8"),
                    l => l.HasOne<Ordini>().WithMany()
                        .HasForeignKey("OrdineRif")
                        .HasConstraintName("FK__OrdiniPia__ordin__6FE99F9F"),
                    j =>
                    {
                        j.HasKey("OrdineRif", "PiattoRif").HasName("PK__OrdiniPi__DD97F32D8A3CCD6D");
                        j.ToTable("OrdiniPiatti");
                        j.IndexerProperty<int>("OrdineRif").HasColumnName("ordineRIF");
                        j.IndexerProperty<int>("PiattoRif").HasColumnName("piattoRIF");
                    });
        });

        modelBuilder.Entity<Piatto>(entity =>
        {
            entity.HasKey(e => e.PiattoId).HasName("PK__Piatto__BF1702A936A8254A");

            entity.ToTable("Piatto");

            entity.Property(e => e.PiattoId).HasColumnName("piattoID");
            entity.Property(e => e.Descrizione)
                .HasColumnType("text")
                .HasColumnName("descrizione");
            entity.Property(e => e.MenuRif).HasColumnName("menuRIF");
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

            entity.HasOne(d => d.MenuRifNavigation).WithMany(p => p.Piattos)
                .HasForeignKey(d => d.MenuRif)
                .HasConstraintName("FK__Piatto__menuRIF__6D0D32F4");
        });

        modelBuilder.Entity<Ristorante>(entity =>
        {
            entity.HasKey(e => e.RistoranteId).HasName("PK__Ristoran__5EBF5F9A13787A43");

            entity.ToTable("Ristorante");

            entity.HasIndex(e => e.Codice, "UQ__Ristoran__40F9C18B6B71A2F7").IsUnique();

            entity.Property(e => e.RistoranteId).HasColumnName("ristoranteID");
            entity.Property(e => e.Codice)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("codice");
            entity.Property(e => e.Descrizione)
                .HasColumnType("text")
                .HasColumnName("descrizione");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.OrarioApertura).HasColumnName("orarioApertura");
            entity.Property(e => e.OrarioChiusura).HasColumnName("orarioChiusura");
            entity.Property(e => e.TipoCucina)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("tipoCucina");
        });

        modelBuilder.Entity<Utente>(entity =>
        {
            entity.HasKey(e => e.UtenteId).HasName("PK__Utente__CA5C2253E29AC5A8");

            entity.ToTable("Utente");

            entity.HasIndex(e => e.Email, "UQ__Utente__AB6E61641F96278B").IsUnique();

            entity.Property(e => e.UtenteId).HasColumnName("utenteID");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.PasswordUtente)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("passwordUtente");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
