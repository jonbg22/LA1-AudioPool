namespace AudioPool.Models.Dtos;

public class SongDetailsDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public TimeSpan Duration { get; set; }
    public AlbumDto Album { get; set; } = null!;
    public int TrackNumberOnAlbum { get; set; }    
}