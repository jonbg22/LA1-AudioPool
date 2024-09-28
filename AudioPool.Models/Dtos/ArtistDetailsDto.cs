namespace AudioPool.Models.Dtos;

public class ArtistDetailsDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Bio { get; set; } = "";
    public string CoverImageUrl { get; set; } = "";
    public DateTime DateOfStart { get; set; }
    public IEnumerable<AlbumDto> Albums { get; set; } = null!;
    public IEnumerable<GenreDto> Genres { get; set; } = null!;
}