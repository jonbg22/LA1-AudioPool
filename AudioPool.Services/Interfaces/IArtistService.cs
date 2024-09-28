using AudioPool.Models.Dtos;
using AudioPool.Models.InputModels;

namespace AudioPool.Services.Interfaces;

public interface IArtistService
{
    IEnumerable<ArtistDto> GetAllArtist();
    ArtistDetailsDto GetArtistById(int id);
    int CreateNewArtist(ArtistInputModel artist);
    int UpdateArtist(int id, ArtistInputModel artist);
    void LinkArtistToGenre(int artistId, int genreId);
}