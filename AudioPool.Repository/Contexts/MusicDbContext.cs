using AudioPool.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AudioPool.Repository.Contexts
{
    public class MusicDbContext : DbContext
    {
        public MusicDbContext(DbContextOptions<MusicDbContext> options) : base(options) {}
    
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}