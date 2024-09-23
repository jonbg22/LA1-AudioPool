using System.ComponentModel.DataAnnotations;

namespace AudioPool.Models.Entities
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string? Bio { get; set; }
        public string? CoverImageUrl { get; set; }
        public string DateStarted { get; set; } = "";
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime? DateModified { get; set; }
        public string ModifiedBy { get; set; } = "AudioPoolAdmin";

        // Navigation properties

        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
        public ICollection<Album> Albums { get; set; } = new List<Album>();

    }
}