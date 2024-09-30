using AudioPool.Models.Entities;
using AudioPool.Models.InputModels;
using Microsoft.EntityFrameworkCore;

namespace AudioPool.Repository.Contexts
{
    public class MusicDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Album>()
                .Property(e => e.ModifiedBy)
                .HasDefaultValue("AudioPoolAdmin");

            modelBuilder.Entity<Artist>()
            .Property(e => e.ModifiedBy)
            .HasDefaultValue("AudioPoolAdmin");

            modelBuilder.Entity<Genre>()
            .Property(e => e.ModifiedBy)
            .HasDefaultValue("AudioPoolAdmin");

            modelBuilder.Entity<Song>()
                .Property(e => e.ModifiedBy)
                .HasDefaultValue("AudioPoolAdmin");
        }

        public MusicDbContext(DbContextOptions<MusicDbContext> options) : base(options) { }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}