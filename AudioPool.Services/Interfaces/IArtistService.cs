using AudioPool.Models.Dtos;
using AudioPool.Models.InputModels;

namespace AudioPool.Services.Interfaces;

public interface IArtistService
{
    IEnumerable<ArtistDto> GetAllArtists();
    ArtistDetailsDto GetArtistById(int id);
    IEnumerable<ArtistDto> GetArtistAlbums(int artistId);
    int CreateNewArtist(ArtistInputModel artist);
    void UpdateArtist(int id, ArtistInputModel artist);
    void LinkArtistToGenre(int artistId, int genreId);
}