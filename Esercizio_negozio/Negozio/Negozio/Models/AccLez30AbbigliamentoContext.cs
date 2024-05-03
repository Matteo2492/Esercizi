using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PURIFICAMI_SIGNORE.Models;

public partial class AccLez30AbbigliamentoContext : DbContext
{
    public AccLez30AbbigliamentoContext()
    {
    }

    public AccLez30AbbigliamentoContext(DbContextOptions<AccLez30AbbigliamentoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Ordine> Ordines { get; set; }

    public virtual DbSet<OrdineVariazione> OrdineVariaziones { get; set; }

    public virtual DbSet<Prodotto> Prodottos { get; set; }

    public virtual DbSet<Utente> Utentes { get; set; }

    public virtual DbSet<Variazione> Variaziones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ACADEMY2024-08\\SQLEXPRESS;Database=acc_lez30_abbigliamento;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categori__F353C1C55E7D3B78");

            entity.HasIndex(e => e.Nome, "UQ__Categori__7D8FE3B2A985C83B").IsUnique();

            entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ordine>(entity =>
        {
            entity.HasKey(e => e.OrdineId).HasName("PK__Ordine__0CD3AE503CE0AAAE");

            entity.ToTable("Ordine");

            entity.Property(e => e.OrdineId).HasColumnName("OrdineID");
            entity.Property(e => e.DataOrdine).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.PrezzoTotale).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Stato)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.UtenteRif).HasColumnName("UtenteRIF");

            entity.HasOne(d => d.UtenteRifNavigation).WithMany(p => p.Ordines)
                .HasForeignKey(d => d.UtenteRif)
                .HasConstraintName("FK__Ordine__UtenteRI__619B8048");
        });

        modelBuilder.Entity<OrdineVariazione>(entity =>
        {
            entity.HasKey(e => e.OrdineVariazioneId).HasName("PK__OrdineVa__F303FAB495E5576E");

            entity.ToTable("OrdineVariazione");

            entity.Property(e => e.OrdineVariazioneId).HasColumnName("OrdineVariazioneID");
            entity.Property(e => e.OrdineRif).HasColumnName("OrdineRIF");
            entity.Property(e => e.VariazioneRif).HasColumnName("VariazioneRIF");

            entity.HasOne(d => d.OrdineRifNavigation).WithMany(p => p.OrdineVariaziones)
                .HasForeignKey(d => d.OrdineRif)
                .HasConstraintName("FK__OrdineVar__Ordin__6A30C649");

            entity.HasOne(d => d.VariazioneRifNavigation).WithMany(p => p.OrdineVariaziones)
                .HasForeignKey(d => d.VariazioneRif)
                .HasConstraintName("FK__OrdineVar__Varia__693CA210");
        });

        modelBuilder.Entity<Prodotto>(entity =>
        {
            entity.HasKey(e => e.ProdottoId).HasName("PK__Prodotto__9BE523B878A3849A");

            entity.ToTable("Prodotto");

            entity.HasIndex(e => e.Nome, "UQ__Prodotto__7D8FE3B28F728AF6").IsUnique();

            entity.Property(e => e.ProdottoId).HasColumnName("ProdottoID");
            entity.Property(e => e.CategoriaRif).HasColumnName("CategoriaRIF");
            entity.Property(e => e.Descrizione)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.CategoriaRifNavigation).WithMany(p => p.Prodottos)
                .HasForeignKey(d => d.CategoriaRif)
                .HasConstraintName("FK__Prodotto__Catego__5441852A");
        });

        modelBuilder.Entity<Utente>(entity =>
        {
            entity.HasKey(e => e.UtenteId).HasName("PK__Utente__489EA72AC604FD3E");

            entity.ToTable("Utente");

            entity.HasIndex(e => e.Email, "UQ__Utente__A9D10534843E8CC0").IsUnique();

            entity.Property(e => e.UtenteId).HasColumnName("UtenteID");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Indirizzo)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Nominativo)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Variazione>(entity =>
        {
            entity.HasKey(e => e.VariazioneId).HasName("PK__Variazio__3C5376B22D79F713");

            entity.ToTable("Variazione");

            entity.Property(e => e.VariazioneId).HasColumnName("VariazioneID");
            entity.Property(e => e.Colore)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ImmagineLink)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Prezzo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PrezzoOfferta).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProdottoRif).HasColumnName("ProdottoRIF");
            entity.Property(e => e.Taglia)
                .HasMaxLength(6)
                .IsUnicode(false);

            entity.HasOne(d => d.ProdottoRifNavigation).WithMany(p => p.Variaziones)
                .HasForeignKey(d => d.ProdottoRif)
                .HasConstraintName("FK__Variazion__Prodo__59FA5E80");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
