using AudioPool.Models.Dtos;
using AudioPool.Models.InputModels;

namespace AudioPool.Repository.Interfaces
{
    public interface IArtistRepository
    {
        IEnumerable<ArtistDto> GetAllArtist();
        ArtistDetailsDto GetArtistById(int id);
        int CreateNewArtist(ArtistInputModel artist);
        void UpdateArtist(int id, ArtistInputModel artist);
        void LinkArtistToGenre(int artistId, int genreId);
    }
}