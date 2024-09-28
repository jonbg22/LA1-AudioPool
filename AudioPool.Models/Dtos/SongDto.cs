namespace AudioPool.Models.Dtos;

public class SongDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public TimeSpan Duration { get; set; }    
}