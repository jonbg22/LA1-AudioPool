namespace AudioPool.Models.Dtos;

public class AlbumDto : HyperMediaModel
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public DateTime ReleaseDate { get; set; }
    public string? CoverImageUrl { get; set; }
    public string? Description { get; set; }
}