using AudioPool.Models.Dtos;
using AudioPool.Models.InputModels;
using AudioPool.Repository.Interfaces;
using AudioPool.Services.Interfaces;

namespace AudioPool.Services.Implimentations
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistService(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public int CreateNewArtist(ArtistInputModel artist)
        {
            return _artistRepository.CreateNewArtist(artist);
        }

        public IEnumerable<ArtistDto> GetAllArtist()
        {
            return _artistRepository.GetAllArtist();
        }

        public ArtistDetailsDto GetArtistById(int id)
        {
            return _artistRepository.GetArtistById(id);
        }

        public void LinkArtistToGenre(int artistId, int genreId)
        {
            _artistRepository.LinkArtistToGenre(artistId,genreId);
        }

        public void UpdateArtist(int id, ArtistInputModel artist)
        {
            _artistRepository.UpdateArtist(id,artist);
        }

        public IEnumerable<AlbumDto> GetArtistAlbums(int id) {
            return _artistRepository.getArtistAlbums(id);
        }

    }
}