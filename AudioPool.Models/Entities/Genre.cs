namespace AudioPool.Models.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime? DateModified { get; set; }
        public string? ModifiedBy { get; set; } = "AudioPoolAdmin";

        // Navigation properties
        public ICollection<Artist> Artists { get; set; } = new List<Artist>();
    }
}