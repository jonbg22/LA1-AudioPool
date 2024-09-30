using AudioPool.Models.Dtos;
using AudioPool.Models.InputModels;

namespace AudioPool.Repository.Interfaces
{
    public interface IArtistRepository
    {
        IEnumerable<ArtistDto> GetAllArtist();
        ArtistDetailsDto? GetArtistById(int id);
        int CreateNewArtist(ArtistInputModel artist);
        bool UpdateArtist(int id, ArtistInputModel artist);
        bool LinkArtistToGenre(int artistId, int genreId);
        IEnumerable<AlbumDto>? GetArtistAlbums(int id);
    }
}