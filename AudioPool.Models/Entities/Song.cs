namespace AudioPool.Models.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public TimeSpan Duration { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime? DateModified { get; set; }
        public string? ModifiedBy { get; set; } = "AudioPoolAdmin";
        public int AlbumId { get; set; }

        // Navigation properties
        public Album Album { get; set; } = null!;
    }
}