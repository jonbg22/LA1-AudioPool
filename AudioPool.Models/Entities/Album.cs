namespace AudioPool.Models.Entities
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";        
        public DateTime ReleaseDate { get; set; }
        public string? CoverImageUrl { get; set; }
        public string? Description { get; set; }
        // Automatically generated fields
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime? DateModified { get; set; }
        public string? ModifiedBy { get; set; } = "AudioPoolAdmin";

        // Navigation properties
        
        // Many-to-many relationship with Artists
        public ICollection<Artist> Artists { get; set; } = new List<Artist>();

        // One-to-many relationship with Song
        public ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}