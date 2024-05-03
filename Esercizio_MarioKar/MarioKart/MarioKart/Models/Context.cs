using Microsoft.EntityFrameworkCore;

namespace MarioKart.Models
{
    public class MarioContext : DbContext
    {
        public MarioContext(DbContextOptions<MarioContext> options) : base(options)
        {

        }
        
        public DbSet<Personaggio> Persionaggios { get; set; }
        public DbSet<Squadra> Squadras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Squadra>()
                .HasOne(s => s.PersonaggioCinquantaRIFNavigation)
                .WithMany()
                .HasForeignKey(s => s.PersonaggioCinquantaRIF);

            modelBuilder.Entity<Squadra>()
                .HasOne(s => s.PersonaggioCentoRIFNavigation)
                .WithMany()
                .HasForeignKey(s => s.PersonaggioCentoRIF);

            modelBuilder.Entity<Squadra>()
                .HasOne(s => s.PersonaggioCentoCinquantaRIFNavigation)
                .WithMany()
                .HasForeignKey(s => s.PersonaggioCentoCinquantaRIF);
        }
    }
}
