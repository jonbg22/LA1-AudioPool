using AudioPool.Models.Dtos;
using AudioPool.Models.InputModels;
using AudioPool.Repository.Implimentations;
using AudioPool.Repository.Interfaces;
using AudioPool.Services.Interfaces;

namespace AudioPool.Services.Implimentations
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public AlbumDetailsDto GetAlbumById(int id)
        {
            return _albumRepository.GetAlbumById(id);
        }

        public int CreateNewAlbum(AlbumInputModel album)
        {
            throw new NotImplementedException();
        }

        public int DeleteAlbum(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SongDto> GetSongsByAlbumId(int albumId)
        {
            throw new NotImplementedException();
        }
    }
}