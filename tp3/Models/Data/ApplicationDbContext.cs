using Microsoft.EntityFrameworkCore;
using tp3.Models.EntityFramework;

namespace tp3.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Serie> Series { get; set; }
        public DbSet<Notation> Notations { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }

        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("YourConnectionString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Entity<Notation>()
                .HasKey(n => new { n.UtilisateurId, n.SerieId });

            // Configuration des index
            modelBuilder.Entity<Serie>()
                .HasIndex(s => s.Titre)
                .IsUnique(false);

            modelBuilder.Entity<Utilisateur>()
                .HasIndex(u => u.Mail)
                .IsUnique(true);
        }
    }
}
