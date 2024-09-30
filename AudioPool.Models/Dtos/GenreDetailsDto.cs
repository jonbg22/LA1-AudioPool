namespace AudioPool.Models.Dtos;

public class GenreDetailsDto : HyperMediaModel
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int NumberOfArtists { get; set; }
}