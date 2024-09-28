using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace AudioPool.Models.InputModels;

public class AlbumInputModel
{
    [Required]
    [MinLength(3)]
    public string Name { get; set; } = "";
    [Required]
    public DateTime ReleaseDate { get; set; }
    [Required]
    public IEnumerable<int> ArtistIds { get; set; } = null!;
    [Url]
    public string CoverImageUrl { get; set; } = "";
    [MinLength(10)]
    public string Description { get; set; } = "";
}