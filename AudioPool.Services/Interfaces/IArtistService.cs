using AudioPool.Models;
using AudioPool.Models.Dtos;
using AudioPool.Models.InputModels;

namespace AudioPool.Services.Interfaces;

public interface IArtistService
{
    Envelope<ArtistDto> GetAllArtist(int pageSize, int pageNumber);
    ArtistDetailsDto? GetArtistById(int id);
    IEnumerable<AlbumDto>? GetArtistAlbums(int id);
    int CreateNewArtist(ArtistInputModel artist);
    bool UpdateArtist(int id, ArtistInputModel artist);
    bool LinkArtistToGenre(int artistId, int genreId);
}