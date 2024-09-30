using AudioPool.Models.Dtos;
using AudioPool.Models.InputModels;

namespace AudioPool.Services.Interfaces;

public interface IArtistService
{
    IEnumerable<ArtistDto> GetAllArtist();
    ArtistDetailsDto GetArtistById(int id);
    IEnumerable<AlbumDto> GetArtistAlbums(int id);
    int CreateNewArtist(ArtistInputModel artist);
    void UpdateArtist(int id, ArtistInputModel artist);
    void LinkArtistToGenre(int artistId, int genreId);
}