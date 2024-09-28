using AudioPool.Models.Dtos;
using AudioPool.Models.InputModels;
using AudioPool.Services.Interfaces;

namespace AudioPool.Services.Implimentations
{
    public class ArtistService : IArtistService
    {
        public int CreateNewArtist(ArtistInputModel artist)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArtistDto> GetAllArtist()
        {
            throw new NotImplementedException();
        }

        public ArtistDetailsDto GetArtistById(int id)
        {
            throw new NotImplementedException();
        }

        public void LinkArtistToGenre(int artistId, int genreId)
        {
            throw new NotImplementedException();
        }

        public int UpdateArtist(int id, ArtistInputModel artist)
        {
            throw new NotImplementedException();
        }
    }
}